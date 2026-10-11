using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;




namespace RealEstate
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }


        public Seller(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }
    }
    class Ad
    {
        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeOfCharge { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }
        
        
        
        public Ad(
        int id,
        string description,
        int rooms,
        int area,
        int floors,
        Category category,
        Seller seller,
        bool freeOfCharge,
        string imageUrl,
        string latLong,
        DateTime createAt)

        {
            Id = id;
            Description = description;
            Rooms = rooms;
            Area = area;
            Floors = floors;

            Category = category;
            Seller = seller;

            FreeOfCharge = freeOfCharge;

            ImageUrl = imageUrl;
            LatLong = latLong;

            CreateAt = createAt;
        }

        public static List<Ad> LoadFromCsv(string fileName)
        {
            List<Ad> ads = new List<Ad>();

            string[] sorok =
                File.ReadAllLines(fileName);

            foreach (string sor in sorok.Skip(1))
            {
                string[] m = sor.Split(';');

                Category category =
                    new Category(
                        int.Parse(m[5]),
                        m[6]);

                Seller seller =
                    new Seller(
                        int.Parse(m[7]),
                        m[8],
                        m[9]);

                Ad ad = new Ad(
                    int.Parse(m[0]),
                    m[1],
                    int.Parse(m[2]),
                    int.Parse(m[3]),
                    int.Parse(m[4]),
                    category,
                    seller,
                    bool.Parse(m[10]),
                    m[11],
                    m[12],
                    DateTime.Parse(m[13])
                );

                ads.Add(ad);
            }

            return ads;
        }

        public double DistanceTo(double lat, double lon)
        {
            string[] koordinata =
                LatLong.Split(',');

            double sajatLat =
                double.Parse(koordinata[0]);

            double sajatLon =
                double.Parse(koordinata[1]);

            double kulonbsegX =
                sajatLat - lat;

            double kulonbsegY =
                sajatLon - lon;

            double tavolsag =
                Math.Sqrt(
                    kulonbsegX * kulonbsegX +
                    kulonbsegY * kulonbsegY);

            return tavolsag;
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ad> ads = Ad.LoadFromCsv("realestates.csv");

            Console.WriteLine("1. feladat:");

            Console.WriteLine(
                $"Hirdetések száma: {ads.Count}");

            Console.WriteLine("2. feladat:");

            double osszeg = 0;
            int db = 0;

            foreach (Ad ad in ads)
            {
                if (ad.Floors == 0)
                {
                    osszeg += ad.Area;
                    db++;
                }
            }

            double atlag = osszeg / db;


            Console.WriteLine(
                $"A földszinti ingatlanok átlagos alapterülete: {atlag:F2} m2");


            Console.WriteLine("3. feladat:");

            Ad legkozelebbi = null;

            double minTavolsag = double.MaxValue;

            foreach (Ad ad in ads)
            {
                if (ad.FreeOfCharge)
                {
                    double tavolsag =
                        ad.DistanceTo(
                            47.4164220114023,
                            19.066342425796986);

                    if (tavolsag < minTavolsag)
                    {
                        minTavolsag = tavolsag;
                        legkozelebbi = ad;
                    }
                }
            }

            Console.WriteLine(
                $"Azonosító: {legkozelebbi.Id}");

            Console.WriteLine(
                $"Alapterület: {legkozelebbi.Area} m2");

            Console.WriteLine(
                $"Szobák száma: {legkozelebbi.Rooms}");
        }
    }
}
