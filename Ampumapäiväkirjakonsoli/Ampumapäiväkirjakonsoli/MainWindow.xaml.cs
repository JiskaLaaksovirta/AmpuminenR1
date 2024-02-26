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
        List<Ampuja> ampumapäiväkirja = new List<Ampuja>();

        private void AloitaKirjaaminen_Click(object sender, RoutedEventArgs e)
        {
            Arvojenkysyntä arvojenkysyntä = new Arvojenkysyntä();
            arvojenkysyntä.ShowDialog(); // Avaa uuden ikkunan modaalina
        }

        private void NäytäTulokset_Click(object sender, RoutedEventArgs e)
        {
            string etunimi = InputBox("Syötä ampujan etunimi:");
            string sukunimi = InputBox("Syötä ampujan sukunimi:");
            TulostenTarkastelu.HaeTulokset(ampumapäiväkirja, etunimi, sukunimi);
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
