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
using System.Windows.Shapes;

namespace MedienBibliothekWPF
{
    /// <summary>
    /// Interaktionslogik für MediumLoeschen.xaml
    /// </summary>
    public partial class MediumLoeschen : Window
    {
        List<MedienBibliothek.Medien> liste;
        MedienBibliothek.Medien medium;
        public MediumLoeschen(object _medium, List<MedienBibliothek.Medien> _liste)
        {
            InitializeComponent();
            liste = _liste;
            medium = _medium as MedienBibliothek.Medien;
            message.Text = "Möchten Sie " + medium + "\nwirklich löschen?";
        }

        private void abbrechen_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void loeschen_Click(object sender, RoutedEventArgs e)
        {
            liste.Remove(medium);
            Close();
        }
    }
}
