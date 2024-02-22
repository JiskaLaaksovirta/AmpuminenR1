
using System.Text.Json;
string fileName = "Ampumatulokset.json";
List<Ampuja> ampumapäiväkirja = File.Exists(fileName)?JsonSerializer.Deserialize<List<Ampuja>>(File.ReadAllText(fileName)):[];


int KäyttäjäValinta = 0;
    //Aloitusvalikko
    do
    {
        Console.WriteLine("Valitse toiminto:");
        Console.WriteLine("1. Aloita tulosten kirjaaminen");
        Console.WriteLine("2. Näytä tulokset");
        Console.WriteLine("3. Lopeta");

        if (int.TryParse(Console.ReadLine(), out KäyttäjäValinta))
        {
            switch (KäyttäjäValinta)
            {   //Siirrytään Kirjaus-luokkaan
                case 1:
                    Kirjaus.AloitaKirjaaminen(ampumapäiväkirja);
                    break;
                //Siirrytään TulostenTarkastelu-luokkaan
                case 2:
                    Console.WriteLine("Syötä ampujan etunimi: ");
                    string etunimi = Console.ReadLine();
                    Console.WriteLine("Syötä ampujan sukunimi: ");
                    string sukunimi = Console.ReadLine();
                    TulostenTarkastelu.HaeTulokset(ampumapäiväkirja, etunimi, sukunimi);
                    break;
                //Sammutetaan ohjelma
                case 3:
                    Console.WriteLine("Ohjelma sulkeutuu.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Virheellinen valinta. Yritä uudelleen.");
        }
    
    //Tämä sammuttaa sovelluksen
    } while (KäyttäjäValinta != 3);

string jsonString = JsonSerializer.Serialize(ampumapäiväkirja);
File.WriteAllText(fileName, jsonString);
