using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Ampumapäiväkirjakonsoli
{
    public partial class TulostenTarkastelu : Window
    {
        List<Ampuja> ampumapäiväkirja = [];

        private MainWindow mainWindow;

        public TulostenTarkastelu(List<Ampuja> ampumapäiväkirja, MainWindow mainWindow)
        {
            InitializeComponent();
            this.ampumapäiväkirja = ampumapäiväkirja;
            this.mainWindow = mainWindow;

            // Suodatetaan uniikit nimet
            var uniikitNimet = ampumapäiväkirja
                .Select(ampuja => ampuja.Etunimi + " " + ampuja.Sukunimi)
                .Distinct()
                .ToList();

            // Lisätään uniikit nimet ComboBoxiin
            foreach (var nimi in uniikitNimet)
            {
                cmbAmpujat.Items.Add(nimi);
            }
        }

        private void cmbAmpujat_SelectionChanged(object sender, SelectionChangedEventArgs e)
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


        private void PoistuPäävalikkoon_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }
    }
}
