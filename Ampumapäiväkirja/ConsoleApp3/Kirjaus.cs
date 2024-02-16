class Kirjaus
{   
    //Täällä on kaikki ehdot ja metodit joilla kerätään ammunan ja ampujan tietoja
    public static void AloitaKirjaaminen(List<Ampuja> päiväkirja)
    {
        Console.WriteLine("Syötä ampumaradan pituus (m):");
        double rataPituus = SyöteVarmennus.ReadDoubleFromConsole();

        Console.WriteLine("Syötä laukausten määrä per ampuja:");
        int laukaustenMäärä = SyöteVarmennus.ReadIntegerFromConsole();

        Console.WriteLine("Syötä ampujien määrä:");
        int ampujienMäärä = SyöteVarmennus.ReadIntegerFromConsole();

        Console.WriteLine("Kuvaus suoritettavasta ammunnasta (valinnainen):");
        string ammunnankuvaus = Console.ReadLine();

        DateTime päivämäärä = DateTime.Now;

        for (int i = 0; i < ampujienMäärä; i++)
        {
            Console.WriteLine($"Syötä {i + 1}. ampujan etunimi:");
            string etunimi = SyöteVarmennus.NimenTarkistus("etunimi");

            Console.WriteLine($"Syötä {i + 1}. ampujan sukunimi:");
            string sukunimi = SyöteVarmennus.NimenTarkistus("sukunimi");

            Console.WriteLine($"Syötä kokonaistulos ampujalle {etunimi} {sukunimi}:");
            double kokonaistulos = SyöteVarmennus.ReadDoubleFromConsole();

            Ampuja ampuja = new(etunimi, sukunimi, 
                päivämäärä, rataPituus, 
                laukaustenMäärä, kokonaistulos, 
                ammunnankuvaus);
                päiväkirja.Add(ampuja);
        }
    }
}