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
            Console.WriteLine("Anna ampujien määrä: ");
            int ampujienMaara = int.Parse(Console.ReadLine());

            Console.WriteLine("Anna kierrosten määrä: ");
            int kierrostenMaara = int.Parse(Console.ReadLine());

            Console.WriteLine("Ampujia on: " + ampujienMaara);
            Console.WriteLine("Kierroksia: " + kierrostenMaara);

            //Luo taulukko pisteiden tallentamiseen
            int[,] pisteet = new int[ampujienMaara, kierrostenMaara];

            for (int i = 0; i < ampujienMaara; i++)
            {
                Console.WriteLine($"Ampujalla {i + 1}:");
                for (int j = 0; j < kierrostenMaara; j++)
                {
                    Console.Write($"Anna tulokset kierrokselle {j + 1}: ");
                    pisteet[i, j] = int.Parse(Console.ReadLine());
                }
            }

            //Tulostaisi pisteet
            Console.WriteLine("Ampujien pisteet:");
            for (int i = 0; i < ampujienMaara; i++)
            {
                Console.Write($"Ampuja {i + 1}: ");
                for (int j = 0; j < kierrostenMaara; j++)
                {
                    Console.Write($"{pisteet[i, j]} ");
                }
                Console.WriteLine();

            }
        }
    }
}