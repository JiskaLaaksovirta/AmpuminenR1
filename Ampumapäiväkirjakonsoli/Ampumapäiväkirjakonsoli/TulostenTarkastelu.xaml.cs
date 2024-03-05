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

            // Lisätään "uniikit" nimet ComboBoxiin
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

            // Määritellään tulostuksen sivun koko ja suunta
            printDialog.PrintTicket.PageOrientation = System.Printing.PageOrientation.Portrait;
            printDialog.PrintTicket.PageMediaSize = new System.Printing.PageMediaSize(System.Printing.PageMediaSizeName.ISOA4);

            if (printDialog.ShowDialog() == true)
            {
                // Asetetaan sarakkeiden leveydet uudelleen ennen tulostusta
                foreach (var column in dgAmmunnat.Columns)
                {
                    if (column.Header.ToString() == "Ammunnan kuvaus")
                    {
                        column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    else
                    {
                        column.Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                    }
                }

                // Skaalaa DataGrid sopimaan tulostusalueelle
                double scale = Math.Min(printDialog.PrintableAreaWidth / dgAmmunnat.ActualWidth, printDialog.PrintableAreaHeight / dgAmmunnat.ActualHeight);
                var transform = new TransformGroup();
                transform.Children.Add(new ScaleTransform(scale, scale));
                transform.Children.Add(new TranslateTransform(0, 0));
                dgAmmunnat.LayoutTransform = transform;

                Size pageSize = new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);

                // Asetetaan DataGridin sijainti ja koko
                dgAmmunnat.Measure(pageSize);
                dgAmmunnat.Arrange(new Rect(new Point(0, 0), pageSize));

                // Tulostetaan DataGrid
                printDialog.PrintVisual(dgAmmunnat, "Ampumapäiväkirja");

                // Palautetaan DataGridin ja sarakkeiden alkuperäinen kokoonpano tulostuksen jälkeen
                dgAmmunnat.LayoutTransform = null;
                dgAmmunnat.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                dgAmmunnat.Arrange(new Rect(dgAmmunnat.DesiredSize));
                foreach (var column in dgAmmunnat.Columns)
                {
                    column.Width = DataGridLength.Auto;
                }
            }
        }



        private void PoistuPäävalikkoon_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }
    }
}
