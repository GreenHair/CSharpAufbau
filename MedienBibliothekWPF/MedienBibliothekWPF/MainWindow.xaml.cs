using MedienBibliothek;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            myLib.Bestand.CollectionChanged += Bestand_CollectionChanged;

        }

        private void Bestand_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            lstMedien.ItemsSource = SelectedList(cmbMedium.SelectedIndex);
        }

        //static void Anzeigen(List<Medien> bestand, TextBox tBox)
        //{
        //    var sortiert = from medium in bestand
        //                   group medium by medium.GetType() into medienGruppe
        //                   select (from medien in medienGruppe select medien).ToList();
        //    foreach (var item in sortiert)
        //    {
        //        foreach (var element in item)
        //        {
        //            tBox.AppendText(element.Anzeigen(element));
        //        }
        //    }
        //}

        private void lstMedien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnBearbeiten.IsEnabled = true;
            btnLoeschen.IsEnabled = true;
            btnAbbrechen.IsEnabled = true;
        }

        private void btnNeu_Click(object sender, RoutedEventArgs e)
        {
            stckListe.Visibility = Visibility.Collapsed;
            stckAendern.Visibility = Visibility.Collapsed;
            stckEingabe.Visibility = Visibility.Visible;
            btnAbbrechen.IsEnabled = true;
            btnSpeichern.IsEnabled = true;
            btnNeu.IsEnabled = false;
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
            stckAendern.Visibility = Visibility.Collapsed;
            btnAbbrechen.IsEnabled = false;
            btnSpeichern.IsEnabled = false;
            btnBearbeiten.IsEnabled = false;
            btnLoeschen.IsEnabled = false;
            btnNeu.IsEnabled = true;
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
            stckListe.Visibility = Visibility.Collapsed;
            stckAendern.Visibility = Visibility.Visible;
            btnLoeschen.IsEnabled = false;
            btnBearbeiten.IsEnabled = false;
            btnAbbrechen.IsEnabled = false;           
            if(lstMedien.SelectedItem.GetType() == typeof(Buch))
            {
                lblPublisher.Visibility = Visibility.Visible;
                txtPublisher.Visibility = Visibility.Visible;
                lblVerfasser.Content = "Autor";
                lblPublisher.Content = "Verlag";
                BearbeitenBuch((Buch)lstMedien.SelectedItem);
            }
            if (lstMedien.SelectedItem.GetType() == typeof(MusikCD))
            {
                lblPublisher.Visibility = Visibility.Collapsed;
                txtPublisher.Visibility = Visibility.Collapsed;
                lblVerfasser.Content = "Interpret";
                BearbeitenCD((MusikCD)lstMedien.SelectedItem);
            }
            if (lstMedien.SelectedItem.GetType() == typeof(FilmDVD))
            {
                lblPublisher.Visibility = Visibility.Collapsed;
                txtPublisher.Visibility = Visibility.Collapsed;
                lblVerfasser.Content = "Hauptdarsteller";
                BearbeitenDVD((FilmDVD)lstMedien.SelectedItem);
            }
            if (lstMedien.SelectedItem.GetType() == typeof(Zeitschrift))
            {
                lblPublisher.Visibility = Visibility.Visible;
                txtPublisher.Visibility = Visibility.Visible;
                lblVerfasser.Content = "Themen";
                lblPublisher.Content = "Nummer";
                BearbeitenZeitschrift((Zeitschrift)lstMedien.SelectedItem);
            }
            lstMedien.ItemsSource = SelectedList(cmbMedium.SelectedIndex);
        }

        private void BearbeitenBuch(Buch selectedItem)
        {
            Binding bind = new Binding("Titel");
            bind.Source = selectedItem;
            txtTitle.SetBinding(TextBox.TextProperty, bind);
            bind = new Binding("Erscheinungsjahr");
            bind.Source = selectedItem;
            txtYear.SetBinding(TextBox.TextProperty, bind);
            bind = new Binding("Verfasser");
            bind.Source = selectedItem;
            txtVerfasser.SetBinding(TextBox.TextProperty, bind);
            bind = new Binding("Verlag");
            bind.Source = selectedItem;
            txtPublisher.SetBinding(TextBox.TextProperty, bind);
        }

        private void BearbeitenCD(MusikCD selectedItem)
        {
            Binding bind = new Binding("Titel");
            bind.Source = selectedItem;
            txtTitle.SetBinding(TextBox.TextProperty, bind);
            bind = new Binding("Erscheinungsjahr");
            bind.Source = selectedItem;
            txtYear.SetBinding(TextBox.TextProperty, bind);
            bind = new Binding("Interpret");
            bind.Source = selectedItem;
            txtVerfasser.SetBinding(TextBox.TextProperty, bind);
        }

        private void BearbeitenDVD(FilmDVD selectedItem)
        {
            Binding bind = new Binding("Titel");
            bind.Source = selectedItem;
            txtTitle.SetBinding(TextBox.TextProperty, bind);
            bind = new Binding("Erscheinungsjahr");
            bind.Source = selectedItem;
            txtYear.SetBinding(TextBox.TextProperty, bind);
            bind = new Binding("Hauptdarsteller");
            bind.Source = selectedItem;
            txtVerfasser.SetBinding(TextBox.TextProperty, bind);
        }

        private void BearbeitenZeitschrift(Zeitschrift selectedItem)
        {
            Binding bind = new Binding("Titel");
            bind.Source = selectedItem;
            txtTitle.SetBinding(TextBox.TextProperty, bind);
            bind = new Binding("Erscheinungsjahr");
            bind.Source = selectedItem;
            txtYear.SetBinding(TextBox.TextProperty, bind);
            bind = new Binding("Themen");
            bind.Source = selectedItem;
            txtVerfasser.SetBinding(TextBox.TextProperty, bind);
            bind = new Binding("Nr"); 
            bind.Source = selectedItem;
            txtPublisher.SetBinding(TextBox.TextProperty, bind);
        }

        private void btnLoeschen_Click(object sender, RoutedEventArgs e)
        {
            //lstMedien.ItemsSource = null;
            //myLib.Bestand.Remove((Medien)lstMedien.SelectedItem);            
            Window loeschen = new MediumLoeschen(lstMedien.SelectedItem,myLib.Bestand);
            loeschen.Owner = this;
            loeschen.ShowDialog();
            btnBearbeiten.IsEnabled = false;
            btnLoeschen.IsEnabled = false;
            btnAbbrechen.IsEnabled = false;
        }

        private void cmbMedium_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstMedien != null)
            {
                lstMedien.ItemsSource = SelectedList(cmbMedium.SelectedIndex);
                btnBearbeiten.IsEnabled = false;
                btnLoeschen.IsEnabled = false;
                btnAbbrechen.IsEnabled = false;
            }           
        }

        private List<Medien> SelectedList(int index)
        {
            List<Medien> temp = null;
            switch (index)
            {
                case 0:
                    temp = myLib.SortiertNachTypListe();
                    break;
                case 1:
                    temp = (from book in myLib.Bestand
                            where book.GetType() == typeof(Buch)
                            orderby book.Titel
                            select book).ToList();
                    break;
                case 2:
                    temp = (from cd in myLib.Bestand where cd.GetType() == typeof(MusikCD)
                            orderby cd.Titel select cd).ToList();
                    break;
                case 3:
                    temp = (from dvd in myLib.Bestand where dvd.GetType() == typeof(FilmDVD)
                            orderby dvd.Titel select dvd).ToList();
                    break;
                case 4:
                    temp = (from mag in myLib.Bestand where mag.GetType() == typeof(Zeitschrift)
                            orderby mag.Titel select mag).ToList();
                    break;
            }
            return temp;
        }

        private void Zurueck_Click(object sender, RoutedEventArgs e)
        {
            btnAbbrechen_Click(sender, e);
        }
    }
}
