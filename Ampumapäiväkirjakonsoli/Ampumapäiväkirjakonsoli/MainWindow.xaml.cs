using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Threading;

namespace Ampumapäiväkirjakonsoli
{
    public partial class MainWindow : Window
    {

        List<Ampuja> ampumapäiväkirja = [];

        public MainWindow()
        {
            {
                InitializeComponent();
                DispatcherTimer LiveTime = new DispatcherTimer();
                LiveTime.Interval = TimeSpan.FromSeconds(1);
                LiveTime.Tick += timer_Tick;
                LiveTime.Start();
            }
            void timer_Tick(object sender, EventArgs e)
            {
                Päivämäärä.Text = DateTime.Now.ToString("HH:mm - dddd,\ndd MMMM, yyyy");
            }
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

        private void RichTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
