using System.Collections.Generic;
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

            // Käy läpi kaikki DataGrid-komponentissa olevat rivit
            foreach (var item in dataGrid.Items)
            {
                if (item is Ampuja ampujaDataGridista)
                {
                    // Luo uusi Ampuja-olio jokaiselle riville
                    var uusiAmpuja = new Ampuja
                    {
                        Etunimi = ampujaDataGridista.Etunimi,
                        Sukunimi = ampujaDataGridista.Sukunimi,
                        Päivämäärä = DateTime.Now, // Aseta nykyinen päivämäärä ampumakerralle
                        AmpumaradanPituus = ampumaradanPituus,
                        LaukaustenMäärä = ampujaDataGridista.LaukaustenMäärä,
                        Kokonaistulos = ampujaDataGridista.Kokonaistulos,
                        AmmunnanKuvaus = ampujaDataGridista.AmmunnanKuvaus
                    };

                    // Lisää uusi ampuja ampumapäiväkirja-listaan
                    ampumapäiväkirja.Add(uusiAmpuja);
                }
            }

            MessageBox.Show("Ammunnan tiedot tallennettu!");
            TyhjennäKentät(); // Tyhjennä kentät tallennuksen jälkeen
        }

        private void TyhjennäKentät()
        {
            // Tyhjennä kaikki kentät tallennuksen jälkeen
            txtAmpumaradanPituus.Text = string.Empty;
            txtAmpujienMäärä.Text = string.Empty;
            txtKuvaus.Text = string.Empty;
            dataGrid.Items.Clear(); // Tyhjennä DataGridin rivit
        }


    }
}