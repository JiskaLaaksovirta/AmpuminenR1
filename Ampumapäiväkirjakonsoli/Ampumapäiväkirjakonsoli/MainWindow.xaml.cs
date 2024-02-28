using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace Ampumapäiväkirjakonsoli
{
    public partial class MainWindow : Window
    {

        List<Ampuja> ampumapäiväkirja = new List<Ampuja>();

        public MainWindow()
        {
            InitializeComponent();
            txtNykyinenAika.Text = DateTime.Now.ToString();
        }

        private void AloitaKirjaaminen_Click(object sender, RoutedEventArgs e)
        {
            Ampujataulukko ampujataulukko = new Ampujataulukko(ampumapäiväkirja, this); // Välitä lista konstruktorille
            this.Hide();
            ampujataulukko.Show();
            
        }

        private void NäytäTulokset_Click(object sender, RoutedEventArgs e)
        {
            TulostenTarkastelu tulostenTarkasteluIkkuna = new TulostenTarkastelu(ampumapäiväkirja, this);
            this.Hide();
            tulostenTarkasteluIkkuna.Show();
            
        }


        private void SuljeOhjelma_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private string InputBox(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}
