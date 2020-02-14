using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Nobel
{
    class Nobel
    {
        public int evszam = 0;
        public string tipus = "";
        public string keresztnev = "";
        public string vezeteknev = "";

        public Nobel(string sor)
        {
            string[] m = sor.Split(';');
            evszam = int.Parse(m[0]);
            tipus = m[1];
            keresztnev = m[2];
            vezeteknev = m[3];
        }
    }

    class Program
    {

        //2. feladat
        static void Main(string[] args)
        {
            List<Nobel> nobeldij = new List<Nobel>();
            string sor;
            StreamReader sr = File.OpenText("nobel.csv");

            int k = 0;
            while ((sor = sr.ReadLine()) != null)
            {
                if (k == 0)
                    k++;
                else
                    nobeldij.Add(new Nobel(sor));
            }

            //3. feladat

            string ntipus = "";
            for(int i = 0; i < nobeldij.Count; i++)
            {
                if ((nobeldij[i].keresztnev == "Artur B.") || (nobeldij[i].vezeteknev == "McDonald"))

                    ntipus = nobeldij[i].tipus;
            }
            Console.WriteLine("3. feladat: Arthur B. McDonald " + ntipus + " Nobel-díjat kapott;");

            //4. feladat

            string irodalmi17 = "";

            for (int i = 0; i < nobeldij.Count; i++)
            {
                if (nobeldij[i].evszam == 2017 && nobeldij[i].tipus == "irodalmi")

                    irodalmi17 = nobeldij[i].keresztnev + " " + nobeldij[i].vezeteknev;
            }

            Console.WriteLine("4. feladat: " + irodalmi17 + " kapott 2017-ben irodalmi Nobel-díjat;");

            //5. feladat

            Console.WriteLine("5. feladat: ");
            string beke = "";
            for (int i = 0; i < nobeldij.Count; i++)
            {
                if (nobeldij[i].evszam > 1990 && nobeldij[i].tipus == "béke" && nobeldij[i].vezeteknev=="")
                {
                    beke =nobeldij[i].evszam + ":  " + nobeldij[i].keresztnev;
                    
                    Console.WriteLine(beke.ToString());
                }

            }

            //6. feladat

            Console.WriteLine("6. feladat: ");
            string curie = "";
            for (int i = 0; i < nobeldij.Count; i++)
            {
                if (nobeldij[i].vezeteknev.Contains("Curie"))
                {
                    curie = nobeldij[i].evszam + ":  " + nobeldij[i].keresztnev + " " + nobeldij[i].vezeteknev + "(" +nobeldij[i].tipus + ")";

                    Console.WriteLine(curie.ToString());
                }

            }

            //7. feladat

            int fiz = 0;
            int kem = 0;
            int orv = 0;
            int irod = 0;
            int bek = 0;
            int kozg = 0;

            for (int i = 0; i < nobeldij.Count(); i++)

                if (nobeldij[i].tipus == "fizikai")
                    fiz++;
                else if (nobeldij[i].tipus == "kémiai")
                    kem++;
                else if (nobeldij[i].tipus == "orvosi")
                    orv++;
                else if (nobeldij[i].tipus == "irodalmi")
                    irod++;
                else if (nobeldij[i].tipus == "béke")
                    bek++;
                else if (nobeldij[i].tipus == "közgazdaságtani")
                    kozg++;




            Console.WriteLine("7. feladat: ");
            Console.WriteLine("     -Fizikai: " + fiz.ToString() + " db;");
            Console.WriteLine("     -Kémiai: " + kem.ToString() + " db;");
            Console.WriteLine("     -Orvosi: " + orv.ToString() + " db;");
            Console.WriteLine("     -Irodalmi: " + irod.ToString() + " db;");
            Console.WriteLine("     -Béke: " + bek.ToString() + " db;");
            Console.WriteLine("     -Közgazdaságtani: " + kozg.ToString() + " db;");

            //8. feladat

            List<string> orvosi = new List<string>();


            for (int i = 0; i < nobeldij.Count(); i++)
            {
                if (nobeldij[i].tipus == "orvosi")
                {

                    orvosi.Add(nobeldij[i].evszam + ";" + nobeldij[i].keresztnev + ";" + nobeldij[i].vezeteknev);

                    orvosi.Sort();

                }
            }
            File.WriteAllLines("orvosi.txt", orvosi, Encoding.UTF8);
            Console.WriteLine("8. feladat: orvosi.txt létrehozva ");

            Console.ReadLine();

        }
    }
}
