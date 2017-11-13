using LookAtApi.Interfaces;
using LookAtCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LookAt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IEnumerable<IPlugin> plugins =
                PluginLoader.LoadPlugins(@"c:\projects\LookAt\Plugins\Smartcards\bin\Debug\netstandard2.0\", "*.dll");
        }

        private void RichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            RichTextBox textBox = sender as RichTextBox;
            Catalog catalog = new Catalog();
            catalog.Add(new Item(textBox.Selection.Text));
            catalog.Add(new Item(textBox.Selection.Text));
            propertyGrid.SelectedObject = catalog;
        }
    }
}
