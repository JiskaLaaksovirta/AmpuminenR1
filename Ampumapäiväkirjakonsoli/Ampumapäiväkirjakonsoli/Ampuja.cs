using System;

namespace Ampumapäiväkirjakonsoli
{
    public class Ampuja
    {
        // Ominaisuudet ampujan tiedoille
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public DateTime Päivämäärä { get; set; }
        public double AmpumaradanPituus { get; set; }
        public int LaukaustenMäärä { get; set; }
        public double Kokonaistulos { get; set; }
        public string AmmunnanKuvaus { get; set; }

        // Parametriton konstruktori
        public Ampuja()
        {
            // Voit lisätä tarvittaessa lisätoimintoja tähän
        }

        // Konstruktori, joka ottaa parametreina ampujan tiedot
        public Ampuja(string etunimi, string sukunimi, DateTime päivämäärä, double ampumaradanPituus, int laukaustenMäärä, double kokonaistulos, string ammunnankuvaus)
        {
            Etunimi = etunimi;
            Sukunimi = sukunimi;
            Päivämäärä = päivämäärä;
            AmpumaradanPituus = ampumaradanPituus;
            LaukaustenMäärä = laukaustenMäärä;
            Kokonaistulos = kokonaistulos;
            AmmunnanKuvaus = ammunnankuvaus;
        }
    }
}
