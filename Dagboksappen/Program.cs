using Dagboksappen;
using Dagboksappen.Services;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Dagboksappen
{
    internal class Program
    {
        private static DagboksRepository repo = new DagboksRepository();
        private static readonly string SavePath = Path.Combine(AppContext.BaseDirectory, "dagbok.json");

        static void Main(string[] args)
        {
            
            while (true)
            {
                VisaMeny();
                var input = Console.ReadLine();
                if (!int.TryParse(input, out int val))
                {
                    Console.WriteLine("Ogiltig inmatning. Tryck valfri tangent för att återgå till menyn");
                    Console.ReadKey();
                    continue;
                }
                switch (val)
                {
                    case 1: LäggTillAnteckning(); break;
                    case 2: ListaAnteckningar(); break;
                    case 3: SökAnteckning(); break;
                    case 4: SparaTillFil(); break;
                    case 5: LäsFrånFil(); break;
                    case 0: return;
                    default: Console.WriteLine("Ogiltigt val."); break;
                }
                

                
                

            }




        }

        private static void SökAnteckning()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Sök anteckning på datum ===");
            Console.ResetColor();

            Console.Write("Ange datum (yyyy-MM-dd): ");
            string input = Console.ReadLine() ?? "";

            if (DateTime.TryParseExact(input, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime sökDatum))
            {
                var träffar = repo.HämtaAlla()
                                  .Where(p => p.Datum.Date == sökDatum.Date)
                                  .ToList();

                if (träffar.Count == 0)
                {
                    Console.WriteLine("Inga anteckningar hittades för det datumet.");
                }
                else
                {
                    foreach (var post in träffar)
                    {
                        Console.WriteLine($"{post.Datum:yyyy-MM-dd HH:mm} - {post.Titel}");
                        Console.WriteLine(post.Text);
                        Console.WriteLine(new string('-', 40));
                    }
                }
            }
            else
            {
                Console.WriteLine("Felaktigt datumformat. Använd yyyy-MM-dd (t.ex. 2025-10-01).");
            }

            Console.WriteLine("\nTryck valfri tangent för att återgå till menyn.");
            Console.ReadKey();
        }


        private static void ListaAnteckningar()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Alla anteckningar ===");
            Console.ResetColor();

            var alla = repo.HämtaAlla();
            if (alla.Count == 0)
            {
                Console.WriteLine("(Inga anteckningar ännu.)");
            }
            else
            {
                foreach (var post in alla)
                {
                    Console.WriteLine($"{post.Datum:yyyy-MM-dd HH:mm} - {post.Titel}");
                    Console.WriteLine(post.Text);
                    Console.WriteLine(new string('-', 40));
                }
            }

            Console.WriteLine("\nTryck valfri tangent för att återgå till menyn.");
            Console.ReadKey();
        }

        private static void LäggTillAnteckning()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Ny anteckning ===");
            Console.ResetColor();

            Console.Write("Titel: ");
            string titel = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(titel))
            {
                Console.WriteLine("Titel får inte vara tom.");
                Console.ReadKey();
                return;
            }

            Console.Write("Text: ");
            string text = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Text får inte vara tom.");
                Console.ReadKey();
                return;
            }

            repo.LäggTill(new DagboksPost(DateTime.Now, titel, text));

            Console.WriteLine("\nSparat! Tryck valfri tangent för att återgå till menyn.");
            Console.ReadKey();
        }

        private static void SparaTillFil()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Spara till fil (JSON) ===");
            Console.ResetColor();

            try
            {
                var data = repo.HämtaAlla();
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(data, options);

                File.WriteAllText(SavePath, json);

                Console.WriteLine($"Sparat {data.Count} anteckning(ar) till:\n{SavePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kunde inte spara filen.");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nTryck valfri tangent för att återgå till menyn.");
            Console.ReadKey();
        }

        private static void LäsFrånFil()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Läs från fil (JSON) ===");
            Console.ResetColor();

            if (!File.Exists(SavePath))
            {
                Console.WriteLine("Ingen fil hittades att läsa från:");
                Console.WriteLine(SavePath);
                Console.WriteLine("\nTryck valfri tangent för att återgå till menyn.");
                Console.ReadKey();
                return;
            }

            try
            {
                var json = File.ReadAllText(SavePath);
                var lista = JsonSerializer.Deserialize<List<DagboksPost>>(json)
                            ?? new List<DagboksPost>();

                
                repo = new DagboksRepository();
                foreach (var p in lista)
                    repo.LäggTill(p);

                Console.WriteLine($"Läste in {lista.Count} anteckning(ar) från fil.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kunde inte läsa från filen.");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nTryck valfri tangent för att återgå till menyn.");
            Console.ReadKey();
        }

        private static void VisaMeny()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*************************");
            Console.WriteLine("*      DAGBOKSAPPEN     *");
            Console.WriteLine("*************************");
            Console.WriteLine();
            Console.WriteLine("Vänligen gör ett val");
            Console.WriteLine();
            Console.WriteLine("(1) Skriv ny anteckning");
            Console.WriteLine("(2) Lista alla anteckningar");
            Console.WriteLine("(3) Sök anteckning på datum");
            Console.WriteLine("(4) Spara till fil");
            Console.WriteLine("(5) Läs från fil");
            Console.WriteLine("(0) Avsluta");
        }




    }

}
