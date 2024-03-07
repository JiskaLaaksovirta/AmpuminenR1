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

        private List<Ampuja> ampumapäiväkirja = [];

        public MainWindow()
        {
            {
                InitializeComponent();
                DispatcherTimer LiveTime = new()
                {
                    Interval = TimeSpan.FromSeconds(1)
                };
                LiveTime.Tick += timer_Tick;
                LiveTime.Start();
            }
            void timer_Tick(object sender, EventArgs e)
            {
                Päivämäärä.Text = DateTime.Now.ToString("HH:mm - dddd,\ndd MMMM, yyyy");
            }

            LataaTiedot();
        }

        private void LataaTiedot()
        {
        ampumapäiväkirja = AmpumapäiväkirjaJsonToiminnot.Lataa();
        }

        private void AloitaKirjaaminen_Click(object sender, RoutedEventArgs e)
        {
            Ampujataulukko ampujataulukko = new(ampumapäiväkirja, this);
            this.Hide();
            ampujataulukko.Show();
            
        }

        private void NäytäTulokset_Click(object sender, RoutedEventArgs e)
        {
            TulostenTarkastelu tulostenTarkasteluIkkuna = new(ampumapäiväkirja, this);
            this.Hide();
            tulostenTarkasteluIkkuna.Show();
            
        }


        private void SuljeOhjelma_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void VihreäThemeClick(object sender, RoutedEventArgs e)
        {
            OhjelmaTeema.ChangeTheme(new Uri("Teemat/vihreä.xaml",UriKind.Relative));
        }
        private void SininenThemeClick(object sender, RoutedEventArgs e)
        {
            OhjelmaTeema.ChangeTheme(new Uri("Teemat/sininen.xaml", UriKind.Relative));
        }
        private void VaaleanpunainenThemeClick(object sender, RoutedEventArgs e)
        {
            OhjelmaTeema.ChangeTheme(new Uri("Teemat/vaaleanpunainen.xaml", UriKind.Relative));
        }
        private void PelkistettyThemeClick(object sender, RoutedEventArgs e)
        {
            OhjelmaTeema.ChangeTheme(new Uri("Teemat/pelkistetty.xaml", UriKind.Relative));
        }
    }
}
