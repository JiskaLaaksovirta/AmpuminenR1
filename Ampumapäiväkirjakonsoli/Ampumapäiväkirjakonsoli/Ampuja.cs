using System;
using System.ComponentModel;

namespace Ampumapäiväkirjakonsoli
{
    public class Ampuja : INotifyPropertyChanged
    {
        private bool OnChekattu;
        private string? etunimi;
        private string? sukunimi;
        private int laukaustenMäärä;
        private double kokonaistulos;
        private DateTime päivämäärä;
        private double ampumaradanPituus;
        private string? ammunnanKuvaus;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Etunimi
        {
            get { return etunimi; }
            set
            {
                if (etunimi != value)
                {
                    etunimi = value;
                    OnPropertyChanged(nameof(Etunimi));
                }
            }
        }
        public bool onChekattu
        {
            get { return OnChekattu; }
            set
            {
                if (OnChekattu != value)
                {
                    OnChekattu = value;
                    OnPropertyChanged(nameof(onChekattu));
                }
            }
        }

        public string Sukunimi
        {
            get { return sukunimi; }
            set
            {
                if (sukunimi != value)
                {
                    sukunimi = value;
                    OnPropertyChanged(nameof(Sukunimi));
                }
            }
        }

        public int LaukaustenMäärä
        {
            get { return laukaustenMäärä; }
            set
            {
                if (laukaustenMäärä != value)
                {
                    laukaustenMäärä = value;
                    OnPropertyChanged(nameof(LaukaustenMäärä));
                }
            }
        }

        public double Kokonaistulos
        {
            get { return kokonaistulos; }
            set
            {
                if (kokonaistulos != value)
                {
                    kokonaistulos = value;
                    OnPropertyChanged(nameof(Kokonaistulos));
                }
            }
        }

        public DateTime Päivämäärä
        {
            get { return päivämäärä; }
            set
            {
                if (päivämäärä != value)
                {
                    päivämäärä = value;
                    OnPropertyChanged(nameof(Päivämäärä));
                }
            }
        }

        public double AmpumaradanPituus
        {
            get { return ampumaradanPituus; }
            set
            {
                if (ampumaradanPituus != value)
                {
                    ampumaradanPituus = value;
                    OnPropertyChanged(nameof(AmpumaradanPituus));
                }
            }
        }

        public string AmmunnanKuvaus
        {
            get { return ammunnanKuvaus; }
            set
            {
                if (ammunnanKuvaus != value)
                {
                    ammunnanKuvaus = value;
                    OnPropertyChanged(nameof(AmmunnanKuvaus));
                }
            }
        }
    }
}
