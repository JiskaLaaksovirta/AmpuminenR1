using System;
using System.ComponentModel;

namespace Ampumapäiväkirjakonsoli
{
    public class Ampuja : INotifyPropertyChanged
    {
        private string etunimi;
        private string sukunimi;
        private DateTime päivämäärä;
        private double ampumaradanPituus;
        private int laukaustenMäärä;
        private double kokonaistulos;
        private string ammunnanKuvaus;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Etunimi
        {
            get => etunimi;
            set
            {
                if (etunimi != value)
                {
                    etunimi = value;
                    OnPropertyChanged(nameof(Etunimi));
                }
            }
        }

        public string Sukunimi
        {
            get => sukunimi;
            set
            {
                if (sukunimi != value)
                {
                    sukunimi = value;
                    OnPropertyChanged(nameof(Sukunimi));
                }
            }
        }

        public DateTime Päivämäärä
        {
            get => päivämäärä;
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
            get => ampumaradanPituus;
            set
            {
                if (ampumaradanPituus != value)
                {
                    ampumaradanPituus = value;
                    OnPropertyChanged(nameof(AmpumaradanPituus));
                }
            }
        }

        public int LaukaustenMäärä
        {
            get => laukaustenMäärä;
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
            get => kokonaistulos;
            set
            {
                if (kokonaistulos != value)
                {
                    kokonaistulos = value;
                    OnPropertyChanged(nameof(Kokonaistulos));
                }
            }
        }

        public string AmmunnanKuvaus
        {
            get => ammunnanKuvaus;
            set
            {
                if (ammunnanKuvaus != value)
                {
                    ammunnanKuvaus = value;
                    OnPropertyChanged(nameof(AmmunnanKuvaus));
                }
            }
        }

        public string KokoNimi => $"{Etunimi} {Sukunimi}";
    }
}
