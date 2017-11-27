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
        private readonly LookUpViewModel _lookUpViewModel;
        public MainWindow()
        {
            InitializeComponent();
            _lookUpViewModel = new LookUpViewModel(new Transformation(null));
            base.DataContext = _lookUpViewModel;
        }

        private void RichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            RichTextBox textBox = sender as RichTextBox;
            _lookUpViewModel.SelectedText = textBox?.Selection.Text;
            _lookUpViewModel?.SearchCommand.Execute(null);
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            _lookUpViewModel?.SearchCommand.Execute(null);
        }

        private void _propertyGrid_OnSelectedObjectChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            _propertyGrid.ExpandAllProperties();
        }
    }
}
