using System.Windows;

namespace Ampumapäiväkirjakonsoli
{
    public partial class Arvojenkysyntä : Window
    {
        private int kysymysIndeksi = 0;
        private string[] kysymykset = {
            "Syötä ampumaradan pituus (m):",
            "Syötä laukausten määrä per ampuja:",
            "Syötä ampujien määrä:",
            "Kuvaus suoritettavasta ammunnasta (valinnainen):"
        };

        public Arvojenkysyntä()
        {
            InitializeComponent();
            NäytäSeuraavaKysymys();
        }

        private void NäytäSeuraavaKysymys()
        {
            if (kysymysIndeksi < kysymykset.Length)
            {
                lblKysymys.Content = kysymykset[kysymysIndeksi];
                kysymysIndeksi++;
            }
            else
            {
                MessageBox.Show("Kaikki kysymykset on käyty läpi.");
            }
        }

        private void Valmis_Click(object sender, RoutedEventArgs e)
        {
            NäytäSeuraavaKysymys();
        }

        private void SeuraavaButton_Click(object sender, RoutedEventArgs e)
        {
            Ampujataulukko ampujataulukko = new Ampujataulukko();
            ampujataulukko.Show();
            this.Close();

        }
    }
}
