using System;
using Dagboksappen.Services;
using Dagboksappen;

namespace Dagboksappen
{
    internal class Program
    {
        private static DagboksRepository repo = new DagboksRepository();

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

            Console.Write("Text: ");
            string text = Console.ReadLine() ?? "";

            repo.LäggTill(new DagboksPost(DateTime.Now, titel, text));

            Console.WriteLine("\nSparat! Tryck valfri tangent för att återgå till menyn.");
            Console.ReadKey();
        }




        
        private static void SökAnteckning() => Console.WriteLine("SökAnteckning");
        private static void SparaTillFil() => Console.WriteLine("SparaTillFil");
        private static void LäsFrånFil() => Console.WriteLine("LäsFrånFil");




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
