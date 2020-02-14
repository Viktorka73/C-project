using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace balkezesek
{
    class Balkezesek
    {
        public string nev;
        public string elso;
        public string utolso;
        public int suly;
        public int magassag;

        public Balkezesek(string sor)
        {
            string[] m = sor.Split(';');
            nev = m[0];
            elso = m[1];
            utolso = m[2];
            suly = int.Parse(m[3]);
            magassag = int.Parse(m[4]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //2.feladat

            List<Balkezesek > balkezes = new List<Balkezesek>();
            string sor;
            StreamReader sr = File.OpenText("balkezesek.csv");

            int k = 0;
            while ((sor = sr.ReadLine()) != null)
            {
                if (k == 0)
                    k++;
                else
                    balkezes.Add(new Balkezesek(sor));
            }
            // 3.feladat

            Console.WriteLine("3. feladat: " + balkezes.Count());

            //4.feladat

            Console.WriteLine("4. feladat: ");

            string utoljara = "";
            double utoljara_magassag = 0;
            for (int i = 0; i < balkezes.Count; i++)
            {
                if (balkezes[i].utolso.Contains("1999-10"))
                {

                    utoljara = balkezes[i].nev;
                    utoljara_magassag = balkezes[i].magassag;
                    Console.WriteLine(utoljara + " " + utoljara_magassag*2.54 + " cm");
                }
            }
            // 5.feladat
            int evszam = 0;
            if ((evszam >= 1990) || (evszam <= 1999))
            {
                Console.Write("5. feladat: Kérek egy évszámot 1990 és 1999 között: ");
                evszam = Convert.ToInt32(Console.ReadLine());
            }
            if ((evszam < 1990) || (evszam > 1999))
            {
                do
                {
                    Console.Write("Hibás adat! Kérek egy évszámot 1990 és 1999 között: ");
                    evszam = Convert.ToInt32(Console.ReadLine());
                }
                while ((evszam < 1990) || (evszam > 1999));
            }

           
            //6. feladat
            int darab = 0;
            double suly = 0;
            double atlag_suly = 0;
            for (int i = 0; i < balkezes.Count(); i++)
            {
                if (balkezes[i].elso.Contains(evszam.ToString()) || balkezes[i].utolso.Contains(evszam.ToString()))
                {
                    darab++;
                    suly += balkezes[i].suly;
                }
            }
            atlag_suly = Math.Round(suly / darab, 2);
            Console.WriteLine("6. feladat: " + atlag_suly.ToString() + " font");
            Console.ReadLine();
        }
    }
}
