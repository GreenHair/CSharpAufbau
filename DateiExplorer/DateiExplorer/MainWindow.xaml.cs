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
using System.IO;

namespace DateiExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static StackPanel Dateiname, Ordner, Groesse, Attributes;
        public MainWindow()
        {
            InitializeComponent();
            Dateiname = name;
            Ordner = ordner;
            Groesse = groesse;
            Attributes = attributes;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            inhaltAnzeigen(input.Text);
        }

        static void inhaltAnzeigen(string dateiPfad)
        {
            FileInfo meineDatei;
            string pfad = Pfadeingabe(dateiPfad);
            int laenge = pfad.Length;

            if (Directory.Exists(pfad))
            {
                Dateiname.Children.Clear();
                Ordner.Children.Clear();
                Groesse.Children.Clear();
                Attributes.Children.Clear();
                string[] inhalt = Directory.GetFileSystemEntries(pfad);

                for (int i = 0; i <= inhalt.GetUpperBound(0); i++)
                {
                    //prüfen ob der eintrarg ein verzeichnis oder eine datei ist
                    if (0 == (File.GetAttributes(inhalt[i]) & FileAttributes.Directory))
                    {
                        meineDatei = new FileInfo(inhalt[i]);
                        string dateiAttribut = HoleDateiAttribute(meineDatei);
                        Dateiname.Children.Add(new Label { Content = String.Format( "{0:-30}",inhalt[i].Substring(laenge - 1)) });
                        Ordner.Children.Add(new Label { Content = "Datei" });
                        Groesse.Children.Add(new Label { Content = meineDatei.Length / 1024 });
                        Attributes.Children.Add(new Label { Content = dateiAttribut });
                    }
                    else
                    {
                        meineDatei = new FileInfo(inhalt[i]);
                        Label btn = new Label { Content = inhalt[i].Substring(laenge - 1), Tag = meineDatei.FullName };
                        btn.MouseDoubleClick += Btn_Click;
                        Dateiname.Children.Add(btn);
                        Ordner.Children.Add(new Label { Content = "Dateiordner" });
                        Groesse.Children.Add(new Label { Content = " " });
                        Attributes.Children.Add(new Label { Content = " " });
                    }
                }
            }
            else
            {
                MessageBox.Show("Pfad nicht gefunden.");
            }
        }

        private static void Btn_Click(object sender, RoutedEventArgs e)
        {
            string pfad = ((Label)sender).Tag.ToString();
            inhaltAnzeigen(pfad);
        }

        static string Pfadeingabe(string suchMuster)
        {            
            //Wenn die Benutzereingabe als letztes Zeichen kein '\' enthält muss dieses angehängt werden
            if (suchMuster.Substring(suchMuster.Length - 1) != "\\")
            {
                suchMuster += "\\";
            }
            return suchMuster;
        }

        static string HoleDateiAttribute(FileInfo file)
        {
            string attribute;
            if (0 != (file.Attributes & FileAttributes.Archive))
            {
                attribute = "A ";
            }
            else
            {
                attribute = "  ";
            }
            if (0 != (file.Attributes & FileAttributes.Hidden))
            {
                attribute += "H ";
            }
            else
            {
                attribute += "  ";
            }
            if (0 != (file.Attributes & FileAttributes.ReadOnly))
            {
                attribute += "R ";
            }
            else
            {
                attribute += "  ";
            }
            return attribute;
        }
    }
}
