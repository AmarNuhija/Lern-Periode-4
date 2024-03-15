using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace Arztneimittel
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, List<string>> Krankheit = new();

            Krankheit.Add("Kopfschmerzen", new List<string> { "Übelkeit", "Erbrechen", "Migräneanfälle" });
            Krankheit.Add("Bauchschmerzen", new List<string> { "Blähungen", "Durchfall", "Gewichtsverlust" });
            Krankheit.Add("Brustschmerzen", new List<string> { "Atemnot", "Angst", "Schweissausbrüche" });

            string beschwerden;

            do
            {
                Console.WriteLine("Welche Beschwerden haben Sie? (Kopfschmerzen, Bauchschmerzen, Brustschmerzen oder 'exit' zum Beenden)");
                beschwerden = Console.ReadLine();

                if (Krankheit.ContainsKey(beschwerden))
                {
                    Console.WriteLine($"Die potentiellen Symptome von {beschwerden} sind:");
                    foreach (var item in Krankheit[beschwerden])
                    {
                        Console.WriteLine($"\t{item}");
                    }

                    Console.WriteLine("Wollen Sie die Krankheit heilen? (Ja/Nein)");
                    string antwort = Console.ReadLine();

                    antwort = antwort.ToLower();

                    if (antwort == "ja")
                    {
                        Console.WriteLine("Nehmen Sie eine Tablette");
                        await SummonTabletteLocally(); // Hier wird die Funktion aufgerufen, um die Tablette anzuzeigen
                    }
                    else if (antwort == "nein")
                    {
                        Console.WriteLine("Dann selber schuld");
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte geben Sie Ja oder Nein ein");
                    }

                    break; // Beende die Schleife nachdem die Antwort auf die Frage erhalten wurde
                }
                else if (beschwerden.ToLower() == "exit")
                {
                    Console.WriteLine("Das Programm wurde beendet.");
                    break;
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe.");
                }

            } while (true);

        }

        static async Task SummonTabletteLocally()
        {
            Console.WriteLine($"Tablette wird erstellt...");
            string filePath = "C:\\Users\\AMAR\\OneDrive - Alte Kantonsschule Aarau\\Desktop\\Tablette.txt";

            string tabletteText = await File.ReadAllTextAsync(filePath);
            Console.WriteLine($"Erstellte Tablette:\n{tabletteText}");
        }
    }
}
