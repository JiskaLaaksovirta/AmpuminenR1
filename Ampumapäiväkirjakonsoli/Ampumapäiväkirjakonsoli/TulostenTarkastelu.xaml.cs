using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

            // Suodatetaan nimet
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

        private void TulostaAmpumatiedot_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // Aseta DataGridin kokoonpano tulostusta varten
                dgAmmunnat.LayoutTransform = new ScaleTransform(1, 1);
                Size pageSize = new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);
                dgAmmunnat.Measure(pageSize);
                dgAmmunnat.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));

                // Tulosta DataGrid
                printDialog.PrintVisual(dgAmmunnat, "Ampumatiedot");

                // Palauta DataGridin alkuperäinen kokoonpano
                dgAmmunnat.LayoutTransform = null;
            }
        }

        private void PoistuPäävalikkoon_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }
    }
}
