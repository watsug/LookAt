using System;
using System.Windows;
using System.Windows.Controls;
using LookAtCore;
using System.Collections;
using LookAtApi.Interfaces;
using System.Collections.Generic;
using LookAtApi.Core;

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
            List<IVisibleObject> results = new List<IVisibleObject>();
            foreach (var plugin in _plugins)
            {
                foreach (var t in plugin.Transformations)
                {
                    try
                    {
                        IVisibleObject tmp = t.DoTransformation(baseObject);
                        if (tmp != null)
                        {
                            results.Add(tmp);
                        }
                    }
                    catch (Exception)
                    {
                        // TODO: add warning here
                    }
                }
            }
            propertyGrid.SelectedObject = results;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _plugins = PluginLoader.LoadPlugins();
            }
            catch (Exception)
            {
                // TODO: add warning here
            }
        }
    }
}
