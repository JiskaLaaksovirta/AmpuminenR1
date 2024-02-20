class TulostenTarkastelu
{
    //Tämä printtaa rivin 2. valinnassa jokaiselle ampujalle jokaisesta ammutusta ammunnasta

    public static void NäytäTulokset(List<Ampuja> päiväkirja)
    {
        Console.WriteLine("Tulokset:");
        foreach (var ampuja in päiväkirja)
        {
            TulostaTulos(ampuja);
            Console.WriteLine();
        }
    }

    public static void HaeTulokset(List<Ampuja> päiväkirja, string etunimi, string sukunimi)
    {
        bool löytyi = false;
        foreach (var ampuja in päiväkirja)
        {
            if (ampuja.Etunimi.Equals(etunimi, StringComparison.OrdinalIgnoreCase) &&
                ampuja.Sukunimi.Equals(sukunimi, StringComparison.OrdinalIgnoreCase))
            {
                TulostaTulos(ampuja);
                löytyi = true;
            }
        }

        if (!löytyi)
        {
            Console.WriteLine($"Tuloksia ei löytynyt henkilölle: {etunimi} {sukunimi}");
        }
    }

    private static void TulostaTulos(Ampuja ampuja)
    {
        Console.WriteLine($"Ampuja: {ampuja.Etunimi} {ampuja.Sukunimi}, Päivämäärä: {ampuja.Päivämäärä.ToShortDateString()}" +
                          $"\nRadan pituus: {ampuja.RataPituus}m, " +
                          $"Laukausten määrä: {ampuja.LaukaustenMäärä}, Kokonaistulos: {ampuja.Kokonaistulos} \n");

        if (!string.IsNullOrWhiteSpace(ampuja.AmmunnanKuvaus))
        {
            Console.WriteLine($"Ammunnan kuvaus: {ampuja.AmmunnanKuvaus}\n");
        }
    }
}
