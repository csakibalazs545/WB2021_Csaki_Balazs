using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keresztrejtveny
{


    class KeresztrejtvenyRacs
    {


        public int OszlopokDb { get; set; }
        public int SorokDb { get; set; }

        public char[,] Racs { get; set; }

        public int[,] Sorszamok { get; set; }

        public List<string> Adatsorok { get; set; }

        public void BeolvasAdatsorok(string forras)
        {
            Adatsorok = new List<string>();

            using (var olvaso = new System.IO.StreamReader(forras))
            {
                while (!olvaso.EndOfStream)
                {
                    Adatsorok.Add(olvaso.ReadLine());


                }
            }
            OszlopokDb = Adatsorok[0].Length;
            SorokDb = Adatsorok.Count;
            Console.WriteLine($"Sorok száma: {SorokDb}");
            Console.WriteLine($"Oszlopok száma: {OszlopokDb}");

            Racs = new char[SorokDb, OszlopokDb];
            Sorszamok = new int[SorokDb, OszlopokDb];

            Adatsorok.ForEach(x => Console.WriteLine(x));


        }

        public void FeltoltRacs()
        {
            for (int i = 0; i < SorokDb; i++)
            {
                for (int j = 0; j < OszlopokDb; j++)
                {
                    Racs[i, j] = Adatsorok[i][j];

                }
            }
        }
    }


    internal class Program
    {
      

        static void Main(string[] args)
        {
           KeresztrejtvenyRacs racs = new KeresztrejtvenyRacs();
           racs.BeolvasAdatsorok("kr1.txt");
           racs.FeltoltRacs();
            

        }
    }
}
