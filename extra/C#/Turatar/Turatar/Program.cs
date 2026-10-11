using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Turatar
{
    class Vezeto {
        public int id {  get; set; }
        public string nev { get; set; }
        public string tel { get; set; }
    }
    class Kategoria
    {
        public int id { get; set; }
        public string nev { get; set; }
    }
    class Turak
    {
        public int id { get; set; }
        public string leiras { get; set; }
        public int tav {  get; set; }
        public int emelkedes { get; set; }
        public int lejtes { get; set; }
        public Kategoria kategoria { get; set; }
        public Vezeto vezeto { get; set; }
        public bool aktiv {  get; set; }
        public DateTime indulas { get; set; }
        public DateTime erkezes { get; set; }

        public Turak (string sor)
        {
            string[] adatok = sor.Split(';');
            this.id = int.Parse(adatok[0]);
            this.leiras = adatok[1];
            this.tav = int.Parse(adatok[2]);
            this.emelkedes = int.Parse(adatok[3]);
            this.lejtes = int.Parse(adatok[4]);
            this.kategoria = new Kategoria();
            this.kategoria.id = int.Parse(adatok[5]);
            this.kategoria.nev = adatok[6];
            this.vezeto = new Vezeto();
            this.vezeto.id = int.Parse(adatok[7]);
            this.vezeto.nev = adatok[8];
            this.vezeto.tel = adatok[9];
            this.aktiv = adatok[10] == "1";
            this.indulas = DateTime.Parse(adatok[11]);
            this.erkezes = DateTime.Parse(adatok[12]);
        }
        public double Meredekseg()
        {
            // A Math.Max beépített függvény visszaadja a két szám közül a nagyobbat
            int maxSzint = Math.Max(emelkedes, lejtes);

            // A tav (km) * 1000 = méter. Fontos a (double) konverzió, hogy tizedestörtet kapjunk!
            return (double)maxSzint / (tav * 1000);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var tura = LoadFromCsv("turak.csv");

            Console.WriteLine($"6. feladat: Aktí túrák átlagos hossza: {AtlagSzamitas(tura):F2} km");
            
            // 8. feladat: Függvény meghívása és az eredmény eltárolása
            Turak legmeredekebb = Legmeredekebb(tura);

            // Kiíratás a Main-ben
            if (legmeredekebb != null)
            {
                Console.WriteLine("8. feladat: Legnagyobb meredekségű túra:");
                Console.WriteLine($"\tA túra típusa: {legmeredekebb.kategoria.nev}");
                Console.WriteLine($"\tTáv: {legmeredekebb.tav} km");
                Console.WriteLine($"\tEmelkedés: {legmeredekebb.emelkedes} m");
                Console.WriteLine($"\tLejtés: {legmeredekebb.lejtes} m");
                Console.WriteLine($"\tTúravezető: {legmeredekebb.vezeto.nev}");
                Console.WriteLine($"\tTelefonszám: {legmeredekebb.vezeto.tel}");
            }



            Console.WriteLine("\n9. feladat: Thálész-tétel ellenőrzése");

            // Tesztadatok: Képzeljük el, hogy a túra 3 egyenes szakaszból áll (pl. egy tó körül)
            double szakasz1 = 3.0;
            double szakasz2 = 4.0;
            double szakasz3 = 5.0; // Ez egy klasszikus Pitagoraszi számhármas

            bool thaleszKoronVan = ThalesTetelEllenorzes(szakasz1, szakasz2, szakasz3);

            if (thaleszKoronVan)
            {
                Console.WriteLine($"\tA {szakasz1}, {szakasz2} és {szakasz3} km hosszú szakaszok derékszöget zárnak be, így a csúcspont a Thálész-körön van!");
            }
            else
            {
                Console.WriteLine("\tAz útvonal pontjai nem felelnek meg a Thálész-tételnek.");
            }

            Console.ReadKey();
        }
        static List<Turak> LoadFromCsv(string fajlnev)
        {
            List<Turak> lista = new List<Turak>();

            var sorok = File.ReadAllLines(fajlnev).Skip(1);

            foreach (var sor in sorok)
            {
                lista.Add(new Turak(sor));
            }
            return lista;
        }
        static double AtlagSzamitas(List<Turak> lista)
        {
            int db = 0;
            int osszeg = 0;

            foreach (var r in lista)
            {
                if (r.aktiv == true)
                {
                    osszeg += r.tav;
                    db++;
                }
            }
            return (double)osszeg / db;
        }
        static Turak Legmeredekebb(List<Turak> lista)
        {
            double maxMeredekseg = -1;
            Turak legmeredekebbTura = null;

            foreach (var t in lista)
            {
                double aktualisMeredekseg = t.Meredekseg();

                if (aktualisMeredekseg > maxMeredekseg)
                {
                    maxMeredekseg = aktualisMeredekseg;
                    legmeredekebbTura = t;
                }
            }

            return legmeredekebbTura;
        }
        static bool ThalesTetelEllenorzes(double a, double b, double c)
        {
            // 1. Szükségünk van a leghosszabb oldalra (ez lenne az átmérő/átfogó)
            double[] oldalak = { a, b, c };
            Array.Sort(oldalak); // Rendezzük, így biztosan az utolsó elem lesz a legnagyobb

            double befogo1 = oldalak[0];
            double befogo2 = oldalak[1];
            double atmero = oldalak[2];

            // 2. Thálész/Pitagorasz képlet: a^2 + b^2 = c^2
            double balOldal = Math.Pow(befogo1, 2) + Math.Pow(befogo2, 2);
            double jobbOldal = Math.Pow(atmero, 2);

            // 3. Vizsgatrükk: Lebegőpontos (double) számokat SOHA nem hasonlítunk == jellel!
            // Helyette a különbségük abszolútértékét nézzük egy nagyon pici hibahatárral.
            return Math.Abs(balOldal - jobbOldal) < 0.01;
        }
    }
}
