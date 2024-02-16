class TulostenTarkastelu
{   
    //Tämä printtaa rivin 2. valinnassa jokaiselle ampujalle jokaisesta ammutusta ammunnasta
    public static void NäytäTulokset(List<Ampuja> päiväkirja)
    {
        Console.WriteLine("Tulokset:");
        foreach (var ampuja in päiväkirja)
        {
            Console.WriteLine($"Ampuja: {ampuja.Etunimi} {ampuja.Sukunimi}, Päivämäärä: {ampuja.Päivämäärä.ToShortDateString()}" +
            $"\nAmmunnan kuvaus: {ampuja.AmmunnanKuvaus}, Radan pituus: {ampuja.RataPituus}m, " +
            $"Laukausten määrä: {ampuja.LaukaustenMäärä}, Kokonaistulos: {ampuja.Kokonaistulos}");

            Console.WriteLine();
        }
    }
}
