using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Ampumapäiväkirjakonsoli
{

    public partial class Ampujataulukko : Window
    {

        List<Ampuja> ampumapäiväkirja = new List<Ampuja>();

        public Ampujataulukko()
        {
            InitializeComponent();
            txtNykyinenAika.Text = DateTime.Now.ToString();
        }

        private void AloitaKirjaaminen_Click(object sender, RoutedEventArgs e)
        {
            LisääRivejäDataGridiin();
        }

        private void LisääRivejäDataGridiin()
        {
            dataGrid.Items.Clear();

            // Tarkista, että txtAmpujienMäärä-kenttässä on syöte ja että se voidaan muuntaa kokonaisluvuksi
            if (int.TryParse(txtAmpujienMäärä.Text, out int ampumäärä))
            {
                // Lisää rivejä DataGridiin ampumäärän mukaan
                for (int i = 0; i < ampumäärä; i++)
                {
                    // Luo uusi Ampuja-olio ja lisää se DataGridiin
                    var uusiAmpuja = new Ampuja();
                    dataGrid.Items.Add(uusiAmpuja);
                }
            }
            else
            {
                // Jos syöte ei ole kelvollinen, näytä virheviesti
                MessageBox.Show("Syötä kokonaisluku ampujien määrä-kenttään.");
            }
        }
        private void TallennaTiedot_Click(object sender, RoutedEventArgs e)
        {
            TallennaAmpujat();
        }

        private void TallennaAmpujat()
        {
            // Tarkista, että kaikki tarvittavat tiedot on annettu
            if (!string.IsNullOrEmpty(txtAmpumaradanPituus.Text) &&
                !string.IsNullOrEmpty(txtAmpujienMäärä.Text) &&
                !string.IsNullOrEmpty(txtLaukaustenMäärä.Text))
            {
                // Muunna tekstilaatikoiden sisältö sopiviksi tyypeiksi ja tallenna ne ampumapäiväkirjaan
                double ampumaradanPituus = double.Parse(txtAmpumaradanPituus.Text);
                int laukaustenMäärä = int.Parse(txtLaukaustenMäärä.Text);

                var uusiAmpuja = new Ampuja
                {
                    AmpumaradanPituus = ampumaradanPituus,
                    LaukaustenMäärä = laukaustenMäärä,
                    Päivämäärä = DateTime.Now,
                };
                
            foreach (var item in dataGrid.Items)
            {
                if (item is Ampuja)
                {
                    var ampuma = (Ampuja)item;

                    // Täytä etunimen tallennus DataGridistä
                    if (dataGrid.Columns[0].GetCellContent(item) is TextBox etunimiGridi)
                    {
                        ampuma.Etunimi = etunimiGridi.Text;
                    }

                    // Täytä sukunimen tallennus DataGridistä
                    if (dataGrid.Columns[1].GetCellContent(item) is TextBox sukunimiGridi)
                    {
                        ampuma.Sukunimi = sukunimiGridi.Text;
                    }

                    // Täytä kokonaistuloksen tallennus DataGridistä
                    if (dataGrid.Columns[2].GetCellContent(item) is TextBox KokonaistulosGridi)
                    {
                        if (double.TryParse(KokonaistulosGridi.Text, out double kokonaistulos))
                        {
                            ampuma.Kokonaistulos = kokonaistulos;
                        }
                        else
                        {
                            MessageBox.Show("Virheellinen kokonaistulos.");
                            return;
                        }
                    }
                }
            }

            // Lisää uusi Ampuja-olio ampumapäiväkirjaan
            ampumapäiväkirja.Add(uusiAmpuja);

            // Ilmoitus käyttäjälle, että tiedot tallennettiin
            MessageBox.Show("Ammunnan tiedot tallennettu!");

            // Tyhjennä tekstikentät tallennuksen jälkeen
            txtAmpumaradanPituus.Text = "";
            txtLaukaustenMäärä.Text = "";
            txtAmpujienMäärä.Text = "";

            // Tyhjennä DataGrid
            dataGrid.Items.Clear();

            }
        }
    }
}