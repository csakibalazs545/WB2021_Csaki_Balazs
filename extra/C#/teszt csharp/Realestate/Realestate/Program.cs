using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace Realestate
{
    class category
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    class seller
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }

    class ad
    {
        public int id { get; set; }
        public string description { get; set; }
        public int rooms { get; set; }
        public int area { get; set; }
        public int floors { get; set; }
        public category category { get; set; }
        public seller seller { get; set; }
        public bool freofcharge { get; set; }

        public string imageurl { get; set; }
        public string latlong { get; set; }
        public DateTime createat { get; set; }

        public ad(string sor)
        {
            string[] adatok = sor.Split(';');
            this.id = int.Parse(adatok[0]);
            this.rooms = int.Parse(adatok[1]);
            this.latlong = adatok[2];
            this.floors = int.Parse(adatok[3]);
            this.area = int.Parse(adatok[4]);
            this.description = adatok[5];
            this.freofcharge = adatok[6] == "1";
            this.imageurl = adatok[7];
            this.createat = DateTime.Parse(adatok[8]);
            this.seller = new seller();
            this.seller.id = int.Parse(adatok[9]);
            this.seller.name = adatok[10];
            this.seller.phone = adatok[11];
            this.category = new category();
            this.category.id = int.Parse(adatok[12]);
            this.category.name = adatok[13];
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var betolt = LoadfromCsv("realestates.csv");

            Console.WriteLine("1. feladat");
            Console.WriteLine($"alap terület : {atlag(betolt):F2}");
        }


        static List<ad> LoadfromCsv(string filename)
        {
            List<ad> lista = new List<ad>();
            var sorok = File.ReadAllLines(filename);

            foreach (var sor in sorok.Skip(1))
            {
                lista.Add(new ad(sor));
            }
            return lista;
        }

        static double atlag(List<ad> lista)
        {
            int db = 0;
            int ossz = 0;
            foreach (var ad in lista)
            {
                if (ad.floors == 0)
                {
                    db++;
                    ossz += ad.area;
                }
            }
            return (double)ossz / db;
        }
    }
}
