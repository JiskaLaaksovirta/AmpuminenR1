
// Täällä kaikki mitä me halutaan ampujalta kysyä

class Ampuja(string etunimi, string sukunimi,
    DateTime päivämäärä, double rataPituus,
    int laukaustenMäärä, double kokonaistulos,
    string ammunnankuvaus)
{
    public string Etunimi { get; } = etunimi;
    public string Sukunimi { get; } = sukunimi;
    public DateTime Päivämäärä { get; } = päivämäärä;
    public double RataPituus { get; } = rataPituus;
    public int LaukaustenMäärä { get; } = laukaustenMäärä;
    public double Kokonaistulos { get; } = kokonaistulos;
    public string AmmunnanKuvaus { get; } = ammunnankuvaus;
}
