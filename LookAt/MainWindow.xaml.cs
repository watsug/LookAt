using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using LookAt.PropertyGrid;
using LookAtCore;
using LookAtApi.Interfaces;
using LookAtApi.VisibleObjects;

namespace LookAt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IEnumerable<IPlugin> _plugins;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            RichTextBox textBox = sender as RichTextBox;
            IVisibleObject baseObject = new StringVisibleObject(textBox.Selection.Text);
            IEnumerable<IVisibleObject> results = LookAtUtil.DoSearch(_plugins, baseObject, 5);

            _propertyGrid.SelectedObject = new LookupResult(textBox.Selection.Text, results);
            _propertyGrid.ExpandAllProperties();
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
    }
}
