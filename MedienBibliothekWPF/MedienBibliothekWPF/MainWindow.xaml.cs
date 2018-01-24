using MedienBibliothek;
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

namespace MedienBibliothekWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bibliothek myLib;
        public MainWindow()
        {
            InitializeComponent();
            myLib = new Bibliothek();
            myLib.Bestand = Datei.Laden();
            lstMedien.ItemsSource = myLib.SortiertNachTyp();
            

        }

        static void Anzeigen(List<Medien> bestand, TextBox tBox)
        {
            var sortiert = from medium in bestand group medium by medium.GetType();
            foreach (var item in sortiert)
            {
                foreach (var element in item)
                {
                    tBox.AppendText(element.Anzeigen(element));
                }
            }
        }

        private void lstMedien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnBearbeiten.IsEnabled = true;
            btnLoeschen.IsEnabled = true;
            btnAbbrechen.IsEnabled = true;
        }

        private void btnNeu_Click(object sender, RoutedEventArgs e)
        {
            stckListe.Visibility = Visibility.Collapsed;
            stckEingabe.Visibility = Visibility.Visible;
            btnAbbrechen.IsEnabled = true;
            btnSpeichern.IsEnabled = true;
            cmbItemBuch.IsSelected = true;
        }

        private void btnBeenden_Click(object sender, RoutedEventArgs e)
        {
            Datei.Speichern(myLib.Bestand);
            this.Close();
        }

        private void cmbTyp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTyp.SelectedIndex == 0)
            {
                txtVerlag.Visibility = Visibility.Visible;
                lblVerlag.Visibility = Visibility.Visible;
                lblAutor.Content = "Autor";
            }
            if (cmbTyp.SelectedIndex == 1)
            {
                txtVerlag.Visibility = Visibility.Collapsed;
                lblVerlag.Visibility = Visibility.Collapsed;
                lblAutor.Content = "Interpret";
            }
            if (cmbTyp.SelectedIndex == 2)
            {
                txtVerlag.Visibility = Visibility.Collapsed;
                lblVerlag.Visibility = Visibility.Collapsed;
                lblAutor.Content = "Hauptdarsteller";
            }
            if (cmbTyp.SelectedIndex == 3)
            {
                txtVerlag.Visibility = Visibility.Visible;
                lblVerlag.Visibility = Visibility.Visible;
                lblAutor.Content = "Themen";
                lblVerlag.Content = "Nummer";
            }
        }

        private void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            lstMedien.ItemsSource = null;
            if (cmbTyp.SelectedIndex == 0)
            {
                string titel = txtTitel.Text;
                int jahr = Convert.ToInt32(txtJahr.Text);
                string autor = txtAutor.Text;
                string verlag = txtVerlag.Text;
                myLib.Hinzufuegen(new Buch(autor, verlag, titel, jahr));
            }
            if (cmbTyp.SelectedIndex == 1)
            {
                string titel = txtTitel.Text;
                int jahr = Convert.ToInt32(txtJahr.Text);
                string interpret = txtAutor.Text;
                myLib.Hinzufuegen(new MusikCD(interpret, titel, jahr));
            }
            if (cmbTyp.SelectedIndex == 2)
            {
                string titel = txtTitel.Text;
                int jahr = Convert.ToInt32(txtJahr.Text);
                string actor = txtAutor.Text;
                string verlag = txtVerlag.Text;
                myLib.Hinzufuegen(new FilmDVD(actor, titel, jahr));
            }
            if (cmbTyp.SelectedIndex == 3)
            {
                string titel = txtTitel.Text;
                int jahr = Convert.ToInt32(txtJahr.Text);
                string themen = txtAutor.Text;
                int nummer = Convert.ToInt32(txtVerlag.Text);
                myLib.Hinzufuegen(new Zeitschrift(themen, nummer, titel, jahr));
            }
            lstMedien.ItemsSource = SelectedList(cmbMedium.SelectedIndex);
            btnAbbrechen_Click(sender, e);
        }

        private void btnAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            stckListe.Visibility = Visibility.Visible;
            stckEingabe.Visibility = Visibility.Collapsed;
            btnAbbrechen.IsEnabled = false;
            btnSpeichern.IsEnabled = false;
            btnBearbeiten.IsEnabled = false;
            btnLoeschen.IsEnabled = false;
            TextfelderLoeschen(sender, e);
        }

        private void TextfelderLoeschen(object sender, RoutedEventArgs e)
        {
            txtAutor.Text = "";
            txtJahr.Text = "";
            txtTitel.Text = "";
            txtVerlag.Text = "";
        }

        private void btnBearbeiten_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoeschen_Click(object sender, RoutedEventArgs e)
        {
            //lstMedien.ItemsSource = null;
            //myLib.Bestand.Remove((Medien)lstMedien.SelectedItem);            
            Window loeschen = new MediumLoeschen(lstMedien.SelectedItem,myLib.Bestand);
            loeschen.Show();
            lstMedien.ItemsSource = SelectedList(cmbMedium.SelectedIndex);
        }

        private void cmbMedium_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstMedien != null)
            {
                lstMedien.ItemsSource = SelectedList(cmbMedium.SelectedIndex);                
            }
        }

        private List<Medien> SelectedList(int index)
        {
            List<Medien> temp = null;
            switch (index)
            {
                case 0:
                    temp = myLib.SortiertNachTyp();
                    break;
                case 1:
                    temp = (from book in myLib.Bestand where book.GetType() == typeof(Buch) select book).ToList();
                    break;
                case 2:
                    temp = (from cd in myLib.Bestand where cd.GetType() == typeof(MusikCD) select cd).ToList();
                    break;
                case 3:
                    temp = (from dvd in myLib.Bestand where dvd.GetType() == typeof(FilmDVD) select dvd).ToList();
                    break;
                case 4:
                    temp = (from mag in myLib.Bestand where mag.GetType() == typeof(Zeitschrift) select mag).ToList();
                    break;
            }
            return temp;
        }
    }
}
