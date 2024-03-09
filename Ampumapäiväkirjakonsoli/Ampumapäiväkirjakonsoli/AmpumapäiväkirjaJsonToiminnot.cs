using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace Ampumapäiväkirjakonsoli
{
    public static class AmpumapäiväkirjaJsonToiminnot
    {
        private static readonly string fileName = "Ampumatulokset.json";

        public static void Tallenna(List<Ampuja> ampumapäiväkirja)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(ampumapäiväkirja);
                File.WriteAllText(fileName, jsonString);
            }
            catch
            {
                MessageBox.Show("Virhe tallennuksessa");
            }
        }

        public static List<Ampuja> Lataa()
        {
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                return JsonSerializer.Deserialize<List<Ampuja>>(jsonString);
            }

            return [];
        }
    }
}
