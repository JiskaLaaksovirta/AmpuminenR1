using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Ampumapäiväkirjakonsoli
{

    public partial class Ampujataulukko : Window
    {
        List<Ampuja> ampumapäiväkirja = [];
        private MainWindow mainWindow;

        public Ampujataulukko( List<Ampuja> ampumapäiväkirja, MainWindow mainWindow)
        {
            InitializeComponent();
            this.ampumapäiväkirja = ampumapäiväkirja;
            this.mainWindow = mainWindow;

            this.DataContext = this.ampumapäiväkirja;
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }
        void timer_Tick(object sender, EventArgs e)
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

            bool tallennusOnnistui = true;

            // Käy läpi kaikki DataGrid-komponentissa olevat rivit
            foreach (var item in dataGrid.Items)
            {
                if (item is Ampuja ampujaDataGridista)
                {   // Tarkistetaan, että tiedot on syötetty datagridin kenttiin.
                    if (!string.IsNullOrWhiteSpace(ampujaDataGridista.Etunimi) &&
                        !string.IsNullOrWhiteSpace(ampujaDataGridista.Sukunimi) &&
                        ampujaDataGridista.LaukaustenMäärä > 0 &&
                        ampujaDataGridista.Kokonaistulos >= 0) // Estetään miinustulokset

                    {
                        // Luo uusi Ampuja-olio jokaiselta riviltä
                        var uusiAmpuja = new Ampuja
                        {
                            Etunimi = ampujaDataGridista.Etunimi,
                            Sukunimi = ampujaDataGridista.Sukunimi,
                            Päivämäärä = DateTime.Now,
                            AmpumaradanPituus = ampumaradanPituus,
                            LaukaustenMäärä = ampujaDataGridista.LaukaustenMäärä,
                            Kokonaistulos = ampujaDataGridista.Kokonaistulos,
                            AmmunnanKuvaus = txtKuvaus.Text,
                        };

                        // Lisää uusi ampuja ampumapäiväkirja-listaan
                        ampumapäiväkirja.Add(uusiAmpuja);
                    }
                    else
                    {
                        MessageBox.Show("Kaikkia pakollisia tietoja ei ole täytetty tai laukaustenmäärä on 0. Tarkista tiedot!");
                        tallennusOnnistui = false;
                        break;
                    }
                }
            }
            
            if (tallennusOnnistui)
            {
                MessageBox.Show("Ammunnan tiedot tallennettu!");
                TyhjennäKentät(); // Tyhjennä kentät tallennuksen jälkeen
            }       
        }

        private void TyhjennäKentät()
        {
            // Tyhjennä kaikki kentät tallennuksen jälkeen
            txtAmpumaradanPituus.Text = string.Empty;
            txtAmpujienMäärä.Text = string.Empty;
            txtKuvaus.Text = string.Empty;
            dataGrid.Items.Clear();
            txtOhje.Text = "Ohje: Aloita syöttämällä ampumaradan pituus sekä ampujien määrä.";
        }

        private void KeskeytaKirjaus_Click(object sender, RoutedEventArgs e)
        {
            // Keskeytä kirjaus- toiminto
            txtAmpumaradanPituus.Clear();
            txtAmpujienMäärä.Clear();
            txtKuvaus.Clear();
            dataGrid.Items.Clear();
            txtOhje.Text = "Ohje: Aloita syöttämällä ampumaradan pituus sekä ampujien määrä.";
        }

        private void txtAmpumaradanPituus_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOhje.Text = "Ohje: Syötä ampumaradan pituus metreinä.";
        }

        private void txtAmpujienMäärä_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOhje.Text = "Ohje: Syötä ampujien määrä lukuina.";
        }

        private void txtKuvaus_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOhje.Text = "Ohje: Tallenna tarvittaessa lisätietoja kierroksesta. Kuvaus tallentuu jokaiselle ampujalle. Max. 300 merkkiä.";
        }
        private void txtKuvaus_TextChanged(object sender, TextChangedEventArgs e)
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