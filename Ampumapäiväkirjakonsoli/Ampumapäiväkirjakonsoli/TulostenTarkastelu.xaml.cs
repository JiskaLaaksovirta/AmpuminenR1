using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using System.Windows.Documents;

namespace Ampumapäiväkirjakonsoli
{
    public partial class TulostenTarkastelu : Window
    {
        private List<Ampuja> ampumapäiväkirja = [];

        private readonly MainWindow mainWindow;


        public TulostenTarkastelu(List<Ampuja> ampumapäiväkirja, MainWindow mainWindow)
        {
            InitializeComponent();
            this.ampumapäiväkirja = AmpumapäiväkirjaJsonToiminnot.Lataa();
            this.mainWindow = mainWindow;
            
            PäivitäAmpujanNimetComboBoxiin();
        }
        private void PäivitäAmpujanNimetComboBoxiin()
        {
            cmbAmpujat.Items.Clear(); 

            var uniikitNimet = ampumapäiväkirja
                .Select(ampuja => ampuja.Etunimi + " " + ampuja.Sukunimi)
                .Distinct()
                .ToList();
            
            foreach (var nimi in uniikitNimet)
            {
                cmbAmpujat.Items.Add(nimi);
            }
        }

        private void CmbAmpujat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbAmpujat.SelectedItem != null)
                {
                    string selectedNimi = cmbAmpujat.SelectedItem.ToString();
                    var ampujanAmpumakerrat = ampumapäiväkirja
                        .Where(ampuja => (ampuja.Etunimi + " " + ampuja.Sukunimi) == selectedNimi)
                        .ToList();

                    dgAmmunnat.ItemsSource = ampujanAmpumakerrat;
                    cmbAmpujat.SelectedItem = selectedNimi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Odottamaton virhe: {ex.Message}", "Virhe", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TulostaAmpumatiedot_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new();

            if (printDialog.ShowDialog() == true)
            {
                FlowDocument document = new();
                string? selectedNimi = cmbAmpujat.SelectedItem?.ToString();

                // Otsikko ampujalle
                Paragraph otsikko = new(new Run($"Ampuja: {selectedNimi}"))
                {
                    FontSize = 16,
                    FontStyle = FontStyles.Italic
                };
                document.Blocks.Add(otsikko);

                // Luo taulukko ampumakerran perustiedoille
                Table ammuntaTaulukko = new();
                // Lisätään sarakkeet ja asetetaan niiden leveydet
                ammuntaTaulukko.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) });
                ammuntaTaulukko.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) });
                ammuntaTaulukko.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) });
                ammuntaTaulukko.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) });

                // Lisää otsikkorivi taulukkoon
                TableRowGroup headerRowGroup = new();
                TableRow headerRow = new();
                headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Päivämäärä"))));
                headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Laukausten määrä"))));
                headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Kokonaistulos"))));
                headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Radan pituus"))));
                headerRowGroup.Rows.Add(headerRow);
                ammuntaTaulukko.RowGroups.Add(headerRowGroup);

                // Lisää tietorivit taulukkoon
                TableRowGroup dataRowGroup = new();
                var ampujanAmpumakerrat = ampumapäiväkirja.Where(ampuja => (ampuja.Etunimi + " " + ampuja.Sukunimi) == selectedNimi).ToList();

                foreach (var ampuja in ampujanAmpumakerrat)
                {
                    TableRow dataRow = new();
                    dataRow.Cells.Add(new TableCell(new Paragraph(new Run(ampuja.Päivämäärä.ToShortDateString()))));
                    dataRow.Cells.Add(new TableCell(new Paragraph(new Run(ampuja.LaukaustenMäärä.ToString()))));
                    dataRow.Cells.Add(new TableCell(new Paragraph(new Run(ampuja.Kokonaistulos.ToString()))));
                    dataRow.Cells.Add(new TableCell(new Paragraph(new Run($"{ampuja.AmpumaradanPituus} m"))));
                    dataRowGroup.Rows.Add(dataRow);
                }
                ammuntaTaulukko.RowGroups.Add(dataRowGroup);
                document.Blocks.Add(ammuntaTaulukko);

                // Ammunnan kuvaus ja kuvauspäivämäärä taulukon jälkeen
                foreach (var ampuja in ampujanAmpumakerrat)
                {
                    // Kuvauspäivämäärä
                    Paragraph kuvausPäivämäärä = new(new Run($"Kuvaus ammunnasta {ampuja.Päivämäärä.ToShortDateString()}:"))
                    {
                        FontWeight = FontWeights.Bold
                    };
                    document.Blocks.Add(kuvausPäivämäärä);

                    // Ammunnan kuvaus
                    Paragraph ammunnanKuvaus = new(new Run(ampuja.AmmunnanKuvaus))
                    {
                        FontSize = 12
                    };
                    document.Blocks.Add(ammunnanKuvaus);

                    // Välilyönti kierrosten välille
                    document.Blocks.Add(new Paragraph(new Run(" ")));
                }

                // Tulostetaan tiedot
                IDocumentPaginatorSource idpSource = document;
                printDialog.PrintDocument(idpSource.DocumentPaginator, "Ampumapäiväkirja");
            }
        }




        private void PoistaValitutRivit_Click(object sender, RoutedEventArgs e)
        {
            // Tallennetaan valitun ampujan nimi ennen poistoa
            string valittuNimi = cmbAmpujat.SelectedItem?.ToString() ?? string.Empty;

            // Poistetaan valitut rivit ampumapäiväkirjasta
            ampumapäiväkirja = ampumapäiväkirja.Where(a => !a.onChekattu).ToList();

            // Päivitä DataGridin tietolähde
            dgAmmunnat.ItemsSource = null; 
            dgAmmunnat.ItemsSource = ampumapäiväkirja; 

            // Tallennetaan muutokset JSON-tiedostoon
            AmpumapäiväkirjaJsonToiminnot.Tallenna(ampumapäiväkirja);

            // Päivitetään Vetolaatikon sisältö vastaamaan muutoksia
            PäivitäAmpujanNimetComboBoxiin();

            // Katsotaan että ampujan nimi pysyy vetolaatikossa
            cmbAmpujat.SelectedItem = cmbAmpujat.Items.Cast<string>().FirstOrDefault(nimi => nimi.Equals(valittuNimi));
        }



        private void PoistuPäävalikkoon_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
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
