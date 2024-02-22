public class SyöteVarmennus
{
    // Näillä estetään kirjainsyötteet kentissä, joihin halutaan vaan nroita,
    // voidaan käyttää muuallakin kuin kirjauksissa näitä ehtoja jos on tarve tulevaisuudessa
    public static double ReadDoubleFromConsole()
    {
        double result;
        while (!double.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Virheellinen syöte. Syötä vain numeroita.");
        }
        return result;
    }

    public static int ReadIntegerFromConsole()
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Virheellinen syöte. Syötä vain numeroita.");
        }
        return result;
    }

    // Ja tällä sitten taas ettei nimessä voi olla numeroita
    public static string NimenTarkistus(string nameType)
    {
        string name;
        do
        {
            Console.WriteLine($"Syötä {nameType}:");
            name = Console.ReadLine();
            if (OnkoNumeroita(name))
            {
                Console.WriteLine($"Virheellinen syöte. {nameType} ei voi sisältää numeroita.");
            }
        } while (OnkoNumeroita(name));

        return name;
    }

    static bool OnkoNumeroita(string input)
    {
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }
}