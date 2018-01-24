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

namespace DatenbindungBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Binding bind = new Binding("Background");
            bind.ElementName = "lstBox";
            txtBox.SetBinding(TextBox.BackgroundProperty, bind);

            
        }

        private void lstBox_Selected(object sender, RoutedEventArgs e)
        {
            //txtBox.Text = lstBox.SelectedItem.ToString();
        }
    }
}
