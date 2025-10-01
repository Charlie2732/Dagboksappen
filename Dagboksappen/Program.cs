namespace Dagboksappen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                VisaMeny();
                int val = int.Parse(Console.ReadLine());
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




















        private static void LäggTillAnteckning() => Console.WriteLine(" LäggTillAnteckning");
        private static void ListaAnteckningar() => Console.WriteLine("ListaAnteckningar");
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
