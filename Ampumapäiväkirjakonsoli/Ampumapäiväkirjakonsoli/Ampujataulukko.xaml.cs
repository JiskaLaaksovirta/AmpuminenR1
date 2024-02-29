﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            txtNykyinenAika.Text = DateTime.Now.ToString();
        }

        private void AloitaKirjaaminen_Click(object sender, RoutedEventArgs e)
        {
            LisääRivejäDataGridiin();
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
                        MessageBox.Show("Kaikki pakollisia tietoja ei ole täytetty tai laukaustenmäärä on 0. Tarkista tiedot!");
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
        }

        private void KeskeytaKirjaus_Click(object sender, RoutedEventArgs e)
        {
            // Keskeytä kirjaus- toiminto
            txtAmpumaradanPituus.Clear();
            txtAmpujienMäärä.Clear();
            txtKuvaus.Clear();
            dataGrid.Items.Clear();

        }
    }
}