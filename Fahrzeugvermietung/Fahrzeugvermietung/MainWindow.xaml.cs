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

namespace Fahrzeugvermietung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Fuhrpark Vermietung = new Fuhrpark();
        string dateipfad = @"..\..\Fahrzeuge.dat";
        public MainWindow()
        {
            InitializeComponent();
            //Vermietung.AlleFahrzeuge.Add(new Auto("NDH-ES 235", 85, 5));
            //Vermietung.AlleFahrzeuge.Add(new Kleinlaster("SDH-EL 684", 250, 2.5));
            //Vermietung.AlleFahrzeuge.Add(new Kraftrad("HAL-C 99", 108, false));
            Vermietung.AlleFahrzeuge = Datei.ListeEinlesen(dateipfad);
            lstBoxFahrzeuge.ItemsSource = Vermietung.AlleFahrzeuge;
        }

        private void btnBeenden_Click(object sender, RoutedEventArgs e)
        {
            Datei.ListeSpeichern(dateipfad, Vermietung.AlleFahrzeuge);
            Close();
        }

        private void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            lstBoxFahrzeuge.ItemsSource = null;
            string knzchn = txtKennzeichen.Text;
            int lstng = Convert.ToInt32(txtLeistung.Text);
            switch (cmbTyp.SelectedIndex)
            {
                case 0:
                    int tueren = Convert.ToInt32(txtTueren.Text);
                    Vermietung.AlleFahrzeuge.Add(new Auto(knzchn, lstng, tueren));
                    break;
                case 1:
                    double last = Convert.ToDouble(txtTueren.Text);
                    Vermietung.AlleFahrzeuge.Add(new Kleinlaster(knzchn, lstng, last));
                    break;
                case 2:                    
                    Vermietung.AlleFahrzeuge.Add(new Kraftrad(knzchn, lstng, (bool)chckBox.IsChecked));
                    break;
            }
            Datei.ListeSpeichern(dateipfad, Vermietung.AlleFahrzeuge);
            lstBoxFahrzeuge.ItemsSource = Vermietung.AlleFahrzeuge;
            btnAbbrechen_Click(sender, e);
        }

        private void btnNeu_Click(object sender, RoutedEventArgs e)
        {
            TextfelderLeeren();
            stckEingabe.Visibility = Visibility.Visible;
            dckListe.Visibility = Visibility.Collapsed;
            btnAbbrechen.IsEnabled = true;
            btnSpeichern.IsEnabled = true;
        }

        private void btnAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            stckEingabe.Visibility = Visibility.Collapsed;
            dckListe.Visibility = Visibility.Visible;
            btnAbbrechen.IsEnabled = false;
        }

        private void TextfelderLeeren()
        {
            txtKennzeichen.Text = "";
            txtLeistung.Text = "";
            txtTueren.Text = "";
        }

        private void cmbTyp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chckBox.Visibility = Visibility.Collapsed;
            txtTueren.Visibility = Visibility.Visible;
            switch (cmbTyp.SelectedIndex)
            {
                case 0:
                    lblEigenschaft.Content = "Anzahl Türen";
                    break;
                case 1:
                    lblEigenschaft.Content = "Nutzlast";
                    break;
                case 2:
                    lblEigenschaft.Content = "Beiwagen? (0=nein/1=ja)";
                    chckBox.Visibility = Visibility.Visible;
                    txtTueren.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void lstBoxFahrzeuge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstBoxFahrzeuge.SelectedItem != null)
            {
                dckListe.Visibility = Visibility.Collapsed;
                stckEingabe.Visibility = Visibility.Visible;
                btnAbbrechen.IsEnabled = true;
                btnSpeichern.IsEnabled = false;
                if (lstBoxFahrzeuge.SelectedItem.GetType() == typeof(Auto))
                {
                    cmbTyp.SelectedIndex = 0;
                    txtTueren.Text = ((Auto)lstBoxFahrzeuge.SelectedItem).AnzTueren.ToString();
                }
                if (lstBoxFahrzeuge.SelectedItem.GetType() == typeof(Kleinlaster))
                {
                    cmbTyp.SelectedIndex = 1;
                    txtTueren.Text = ((Kleinlaster)lstBoxFahrzeuge.SelectedItem).Nutzlast.ToString();
                }
                if (lstBoxFahrzeuge.SelectedItem.GetType() == typeof(Kraftrad))
                {
                    cmbTyp.SelectedIndex = 2;
                    txtTueren.Text = ((Kraftrad)lstBoxFahrzeuge.SelectedItem).HatBeiwagen.ToString();
                }
                cmbTyp_SelectionChanged(sender, e);
                txtKennzeichen.Text = ((Fahrzeug)lstBoxFahrzeuge.SelectedItem).Kennzeichen;
                txtLeistung.Text = ((Fahrzeug)lstBoxFahrzeuge.SelectedItem).Leistung.ToString();
            }
        }
    }
}
