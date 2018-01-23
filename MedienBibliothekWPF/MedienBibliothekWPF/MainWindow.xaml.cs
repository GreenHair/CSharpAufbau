﻿using MedienBibliothek;
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
        public MainWindow()
        {
            InitializeComponent();
            Bibliothek myLib = new Bibliothek();
            myLib.Bestand = Datei.Laden();
            
            //Anzeigen(myLib.Bestand, textBox);
            
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
    }
}
