using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.IO;
using System.Text.Json;

namespace Ampumapäiväkirjakonsoli
{

    public partial class Ampujataulukko : Window
    {
        private readonly List<Ampuja> ampumapäiväkirja = [];
        private readonly MainWindow mainWindow;

        public Ampujataulukko( List<Ampuja> ampumapäiväkirja, MainWindow mainWindow)
        {
            InitializeComponent();
            this.ampumapäiväkirja = ampumapäiväkirja;
            this.mainWindow = mainWindow;

            this.DataContext = this.ampumapäiväkirja;
            DispatcherTimer LiveTime = new()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            LiveTime.Tick += Timer_Tick;
            LiveTime.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Päivämäärä.Text = DateTime.Now.ToString("HH:mm - dddd,\ndd MMMM, yyyy");
        }

        private void AloitaKirjaaminen_Click(object sender, RoutedEventArgs e)
        {
            LisääRivejäDataGridiin();
            txtOhje.Text = "Ohje: Syötä kierroksen tiedot. Paina Tallenna tallentaaksesi tiedot tai Keskeytä kirjaus aloittaaksesi alusta.";
        }
        private void PoistuPäävalikkoon_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }

        private void LisääRivejäDataGridiin()
        {
            if (int.TryParse(txtAmpujienMäärä.Text, out int ampumäärä))
            {
                for (int i = 0; i < ampumäärä; i++)
                {
                    var uusiAmpuja = new Ampuja();
                    dataGrid.Items.Add(uusiAmpuja);
                }
            }
            else
            {
                MessageBox.Show("Syötä kelvollinen ampujien määrä.");
            }
        }

        private void TallennaTiedot_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtAmpumaradanPituus.Text, out double ampumaradanPituus))
            {
                MessageBox.Show("Syötä kelvollinen ampumaradan pituus.");
                return;
            }

            var olemassaOlevaAmpumapäiväkirja = AmpumapäiväkirjaJsonToiminnot.Lataa(); // Lataa olemassa olevat tiedot tiedostosta

            foreach (Ampuja ampujaDataGridista in dataGrid.Items)
            {
                if (!string.IsNullOrWhiteSpace(ampujaDataGridista.Etunimi) &&
                    !string.IsNullOrWhiteSpace(ampujaDataGridista.Sukunimi) &&
                    ampujaDataGridista.LaukaustenMäärä > 0 &&
                    ampujaDataGridista.Kokonaistulos >= 0)
                {
                    // Lisää uusi ampuja olemassa olevaan listaan
                    olemassaOlevaAmpumapäiväkirja.Add(new Ampuja
                    {
                        Etunimi = ampujaDataGridista.Etunimi,
                        Sukunimi = ampujaDataGridista.Sukunimi,
                        LaukaustenMäärä = ampujaDataGridista.LaukaustenMäärä,
                        Kokonaistulos = ampujaDataGridista.Kokonaistulos,
                        Päivämäärä = DateTime.Now,
                        AmpumaradanPituus = ampumaradanPituus,
                        AmmunnanKuvaus = txtKuvaus.Text
                    });
                }
                else
                {
                    MessageBox.Show("Kaikkia pakollisia tietoja ei ole täytetty tai laukausten määrä on 0. Tarkista tiedot!");
                    return;
                }
            }

            AmpumapäiväkirjaJsonToiminnot.Tallenna(olemassaOlevaAmpumapäiväkirja); // Tallennetaan päivitetty lista tiedostoon
            MessageBox.Show("Ammunnan tiedot tallennettu onnistuneesti!");
            TyhjennäKentät();
        }


        private void TyhjennäKentät()
        {
            // Tyhjennä kaikki kentät tallennuksen jälkeen
            txtAmpumaradanPituus.Clear();
            txtAmpujienMäärä.Clear();
            txtKuvaus.Clear();
            dataGrid.Items.Clear();
            txtOhje.Text = "Ohje: Aloita syöttämällä ampumaradan pituus sekä ampujien määrä.";
        }

        private void KeskeytaKirjaus_Click(object sender, RoutedEventArgs e)
        {
            // Keskeytetään kirjaus- toiminto
            txtAmpumaradanPituus.Clear();
            txtAmpujienMäärä.Clear();
            txtKuvaus.Clear();
            dataGrid.Items.Clear();
            txtOhje.Text = "Ohje: Aloita syöttämällä ampumaradan pituus.";
        }

        private void TxtAmpumaradanPituus_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOhje.Text = "Ohje: Syötä ampumaradan pituus metreinä.";
        }

        private void TxtAmpujienMäärä_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOhje.Text = "Ohje: Syötä ampujien määrä numeroina.";
        }

        private void TxtKuvaus_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOhje.Text = "Ohje: Tallenna tarvittaessa lisätietoja kierroksesta. Kuvaus tallentuu jokaiselle ampujalle. Max. 300 merkkiä.";
        }
        private void TxtKuvaus_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Päivitä merkkimäärä laskurin teksti
            int merkkimaara = txtKuvaus.Text.Length;
            Laskuri.Content = $"{merkkimaara} / 300";
     
        }
        private void VihreäThemeClick(object sender, RoutedEventArgs e)
        {
            OhjelmaTeema.ChangeTheme(new Uri("Teemat/vihreä.xaml", UriKind.Relative));
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
