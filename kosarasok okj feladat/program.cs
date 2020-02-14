using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kosarasok
{

    class Kosarasok
    {
        public int id = 0;
        public string nev = "";
        public string nemzetiseg = "";
        public string szulhely = "";
        public string szulido = "";

        public Kosarasok(string sor)
        {
            string[] m = sor.Split(';');
            id = int.Parse(m[0]);
            nev = m[1];
            nemzetiseg = m[2];
            szulhely = m[3];
            szulido = m[4];
        }
    }
    class Program
    {


        static void Main(string[] args)
        {
            //2.feladat

            List<Kosarasok> kosaras = new List<Kosarasok>();
            string sor;
            StreamReader sr = File.OpenText("kosarasok.csv");

            int k = 0;
            while ((sor = sr.ReadLine()) != null)
            {
                if (k == 0)
                    k++;
                else
                    kosaras.Add(new Kosarasok(sor));
            }

            // 3.feladat

            Console.WriteLine("3. feladat: " + kosaras.Count()+ " fő");

            //4.feladat

            Console.WriteLine("4. feladat: ");

            string nem_ism = "";
            for (int i = 0; i < kosaras.Count; i++)
            {
                if (kosaras[i].nemzetiseg == "USA" && kosaras[i].szulhely == "")
                {
                    
                    nem_ism = kosaras[i].nev;
                    Console.WriteLine( nem_ism );
                }                 
            }


            // 5.feladat
            
            int evszam=0;
            if ((evszam > 1970) || (evszam < 2000))
            {
                Console.Write("5. feladat: Kérek egy évszámot 1970 és 2000 között: ");
                evszam = Convert.ToInt32(Console.ReadLine());
            }
            if ((evszam < 1970) || (evszam > 2000))
            {
                do
                {
                    Console.Write("Hibás adat! Kérek egy évszámot 1970 és 2000 között: ");
                    evszam = Convert.ToInt32(Console.ReadLine());
                }
                while ((evszam < 1970) || (evszam > 2000));
            }

                
            //6. feladat
            int darab = 0;
                for(int j=0; j<kosaras.Count(); j++)
                {
                    if (kosaras[j].szulido.Contains(evszam.ToString()))
                    {
                        darab++;
                    }
                }
            Console.WriteLine("Helyes, az évszám a kért intervallumban van!");
            Console.WriteLine("6. feladat: A megadott évszámban születettek száma: " + darab + " fő");

            Console.ReadLine();
        }

    }
}
