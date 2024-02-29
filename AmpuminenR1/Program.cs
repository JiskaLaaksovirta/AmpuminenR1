/// See https://aka.ms/new-console-template for more information
/*using System.Runtime.CompilerServices;

Console.WriteLine("Moikka maailma, tämä on Jiskan kirjoitus");
Console.WriteLine("Tervehdys kaikille tämä on Inkan testi kirjoitus");
Console.WriteLine("Terve! Eveliina testaa.");

Console.WriteLine("Tämä on testirivi - Jiska");

int isonro = 1000;
Console.WriteLine(isonro);

int numero = 130;
Console.WriteLine(numero);

Console.WriteLine(isonro + numero);
Console.WriteLine("Laskettu luvut.");
Console.WriteLine("Samanaikainen muutos");

int uusiNro = 2024;
Console.WriteLine("Tein tälle uuden luvun");

int numero2 = 24;
Console.WriteLine(uusiNro - numero2);
Console.WriteLine("Luku lisätty ja vähennetty edellisen kanssa");

Console.WriteLine("Tämä on testirivi -Inka");
Console.WriteLine("Testi -I");
Console.WriteLine("Tämä on testirivi selaimessa - Inka");
Console.WriteLine("Tämä on testirivi selaimessa2- Inka");

Console.WriteLine("Tämä on testirivi selaimessa - K");
*/

using System;

namespace AmmuntaTulokset
{
    class Program
    {
        static void Main(string[] args)
        {
            int ammuntaEtaisyys, ampujienMaara, kierrostenMaara;

            //Tarkistetaan, että arvot ovat kokonaislukuja.
            while (true)
            {
                Console.WriteLine("Anna ammuntaetäisyys: ");
                if (int.TryParse(Console.ReadLine(), out ammuntaEtaisyys))
                    break;
                else
                    Console.WriteLine("Virheellinen etäisyys. Anna kokonaisluku.");
            }

            while (true)
            {
                Console.WriteLine("Anna ampujien määrä: ");
                if (int.TryParse(Console.ReadLine(), out ampujienMaara))
                    break;
                else
                    Console.WriteLine("Virheellinen ampujien määrä. Anna kokonaisluku.");
            }
                                   
            while (true)
            {
                Console.WriteLine("Anna kierrosten määrä: ");
                if (int.TryParse(Console.ReadLine(), out kierrostenMaara))
                    break;
                else
                    Console.WriteLine("Virheellinen kierrosten määrä. Anna kokonaisluku.");
            }

            Console.WriteLine("Ammuntaetäisyys: " + ammuntaEtaisyys);
            Console.WriteLine("Ampujia on: " + ampujienMaara);
            Console.WriteLine("Kierroksia: " + kierrostenMaara);

            //Luo taulukko pisteiden tallentamiseen
            int[,,] pisteet = new int[ammuntaEtaisyys, ampujienMaara, kierrostenMaara];
            for (int i = 0; i < ampujienMaara; i++)
            {
                Console.WriteLine($"Ampujalla {i + 1}:");
                for (int j = 0; j < kierrostenMaara; j++)
                {
                    Console.Write($"Anna tulokset kierrokselle {j + 1}: ");
                    pisteet[ammuntaEtaisyys - 1, i, j] = int.Parse(Console.ReadLine());
                }
            }

            //Tulostaa pisteet
            Console.WriteLine("Ampujien pisteet:");
            for (int i = 0; i < ampujienMaara; i++)
            {
                Console.Write($"Ampuja {i + 1}: ");
                for (int j = 0; j < kierrostenMaara; j++)
                {
                    Console.Write($"{pisteet[ammuntaEtaisyys - 1, i, j]} ");
                }
                Console.WriteLine();

            }
        }
    }
}