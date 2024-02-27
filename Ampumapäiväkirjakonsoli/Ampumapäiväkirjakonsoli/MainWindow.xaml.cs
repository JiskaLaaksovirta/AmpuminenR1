using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace Ampumapäiväkirjakonsoli
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string fileName = "Ampumatulokset.json";
        List<Ampuja> ampumapäiväkirja = new();

        private void AloitaKirjaaminen_Click(object sender, RoutedEventArgs e)
        {
            Ampujataulukko ampujataulukko = new Ampujataulukko();
            ampujataulukko.Show();

            // Lähetetään ampumapäiväkirjan tiedot Ampujataulukko-ikkunaan
            ampujataulukko.DataContext = ampumapäiväkirja;
            this.Close();
        }

        private void NäytäTulokset_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SuljeOhjelma_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private string InputBox(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string jsonString = JsonSerializer.Serialize(ampumapäiväkirja);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
