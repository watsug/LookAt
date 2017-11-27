using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using LookAt.Model;
using LookAtCore;
using LookAtApi.Interfaces;
using LookAtApi.VisibleObjects;
using LookAt.ViewModel;

namespace LookAt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IEnumerable<IPlugin> _plugins;
        private LookupResultViewModel _lookUpTree;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            RichTextBox textBox = sender as RichTextBox;
            IVisibleObject root = new StringVisibleObject(textBox.Selection.Text);
            IEnumerable<IVisibleObject> results = LookAtUtil.DoSearch(_plugins, root, 5);
            if (_lookUpTree == null)
            {
                _lookUpTree = new LookupResultViewModel(new Transformation(results, root));
                base.DataContext = _lookUpTree;
            }
            else
            {
                _lookUpTree.Rebuild(new Transformation(results, root));
            }
            _lookUpTree?.SearchCommand.Execute(null);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _plugins = LookAtUtil.LoadPlugins();
            }
            catch (Exception)
            {
                // TODO: add warning here
            }
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            _lookUpTree?.SearchCommand.Execute(null);
        }

        private void _propertyGrid_OnSelectedObjectChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            _propertyGrid.ExpandAllProperties();
        }
    }
}
