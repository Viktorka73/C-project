using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kutyak
{
    class Program
    {
        //2. feladat
        struct KutyaNevek
        {
            public int kutyanev_id;
            public string kutya_nev;

        }
        static KutyaNevek[] knevadatok = new KutyaNevek[600];

        //4. feladat

        struct KutyaFajtak
        {
            public int fajta_id;
            public string fajta_nev;
            public string eredeti_nev;

        }
        static KutyaFajtak[] kfajtaadatok = new KutyaFajtak[600];

        //5. feladat
        struct Kutyak
        {
            public int kutyak_id;
            public int fajta_id2;
            public int kutyanev_id2;
            public int eletkor;
            public string ut_orv_ell;

        }
        static Kutyak[] kadatok = new Kutyak[600];


        static void Main(string[] args)

        {
            //2. feladat
            string[] rl1 = File.ReadAllLines("KutyaNevek.csv");

            int sorokszama1 = 0;

            for (int k = 1; k < rl1.Count(); k++)
            {
                string[] darabolt_sor1 = rl1[k].Split(';');

                knevadatok[sorokszama1].kutyanev_id = Convert.ToInt32(darabolt_sor1[0]);
                knevadatok[sorokszama1].kutya_nev = darabolt_sor1[1];
                sorokszama1++;
            }
            int elemekszama1 = sorokszama1;

            //3. feladat

            Console.WriteLine("3. feladat: Kutyanevek száma: " + elemekszama1 + " db");

            //4. feladat

            string[] rl2 = File.ReadAllLines("KutyaFajtak.csv");

            int sorokszama2 = 0;

            for (int k = 1; k < rl2.Count(); k++)
            {
                string[] darabolt_sor2 = rl2[k].Split(';');

                kfajtaadatok[sorokszama2].fajta_id = Convert.ToInt32(darabolt_sor2[0]);
                kfajtaadatok[sorokszama2].fajta_nev = darabolt_sor2[1];
                kfajtaadatok[sorokszama2].eredeti_nev = darabolt_sor2[2];
                sorokszama2++;
            }
            int elemekszama2 = sorokszama2;

            //5. feladat

            string[] rl3 = File.ReadAllLines("Kutyak.csv");

            int sorokszama3 = 0;

            for (int k = 1; k < rl3.Count(); k++)
            {
                string[] darabolt_sor3 = rl3[k].Split(';');

                kadatok[sorokszama3].kutyak_id = Convert.ToInt32(darabolt_sor3[0]);
                kadatok[sorokszama3].fajta_id2 = Convert.ToInt32(darabolt_sor3[1]);
                kadatok[sorokszama3].kutyanev_id2 = Convert.ToInt32(darabolt_sor3[2]);
                kadatok[sorokszama3].eletkor = Convert.ToInt32(darabolt_sor3[3]);
                kadatok[sorokszama3].ut_orv_ell = darabolt_sor3[4];


                sorokszama3++;
            }
            int elemekszama3 = sorokszama3;

            //6.feladat
            double osszeletkor = 0;
            double atlag_eletkor = 0;

            for (int i = 0; i < elemekszama3; i++)
            {
                osszeletkor += kadatok[i].eletkor;
            }


            atlag_eletkor = Math.Round(osszeletkor / sorokszama3, 2);

            Console.WriteLine("6. feladat: Kutyák átlag életkora: " + atlag_eletkor.ToString() + " év");

            //7. feladat

            int max = 0;
            int maxfajtaid = 0;
            int maxnevid = 0;
            int maxelet = kadatok[3].eletkor;
            for (int i = 0; i < elemekszama3; i++)
            {
                if (kadatok[i].eletkor > maxelet)
                {
                    maxelet = kadatok[i].eletkor;
                    maxnevid = kadatok[i].kutyanev_id2;
                    maxfajtaid = kadatok[i].fajta_id2;

                    max = i;
                }
            }

            string maxnev = "";
            for (int i = 0; i < elemekszama1; i++)
            {
                if (knevadatok[i].kutyanev_id == maxnevid)
                    maxnev = knevadatok[i].kutya_nev;
            }


            string maxfajta = "";
            for (int i = 0; i < elemekszama2; i++)
            {
                if (kfajtaadatok[i].fajta_id == maxfajtaid)
                    maxfajta = kfajtaadatok[i].fajta_nev;
            }


            Console.WriteLine("7. feladat: A legidősebb kutya neve és fajtája: " + maxnev.ToString() + ", " + maxfajta.ToString() + " (" + maxelet.ToString() + " éves)");

            //8. feladat

            
 
            int fajtadb = 0;
            int fajtadb2 = 0;
            int fajtadb3 = 0;
            int fajtadb4 = 0;
            int vizsgaltdb = 0;

            for (int i = 0; i < elemekszama3; i++)
            {
                if (kadatok[i].ut_orv_ell == "2018.01.10")
                {                    
                    fajtadb = kadatok[i].fajta_id2;
                    vizsgaltdb++;
                }
            }

            for (int i = 0; i < elemekszama3; i++)
            {
                if (kadatok[i].ut_orv_ell == "2018.01.10" && kadatok[i].fajta_id2 != fajtadb)
                {

                    fajtadb2 = kadatok[i].fajta_id2;
                }
            }

            for (int i = 0; i < elemekszama3; i++)
            {
                if (kadatok[i].ut_orv_ell == "2018.01.10" && kadatok[i].fajta_id2 != fajtadb && kadatok[i].fajta_id2 != fajtadb2)
                {

                    fajtadb3 = kadatok[i].fajta_id2;
                }
            }

            for (int i = 0; i < elemekszama3; i++)
            {
                if (kadatok[i].ut_orv_ell == "2018.01.10" && kadatok[i].fajta_id2 != fajtadb && kadatok[i].fajta_id2 != fajtadb2 && kadatok[i].fajta_id2 != fajtadb3)
                {

                    fajtadb4 = kadatok[i].fajta_id2;
                }               
            }

            int db = 0;
            int db2 = 0;
            int db3 = 0;
            int db4 = 0;
            string vizsgalt_fajta = "";
            string vizsgalt_fajta2 = "";
            string vizsgalt_fajta3 = "";
            string vizsgalt_fajta4 = "";

            for (int i = 0; i < elemekszama2; i++)
            {
                if (kfajtaadatok[i].fajta_id == fajtadb)
                {
                    vizsgalt_fajta = kfajtaadatok[i].fajta_nev;
                    db++;
                }               
            }
           
            for (int i = 0; i < elemekszama2; i++)
            {
                if (kfajtaadatok[i].fajta_id == fajtadb2)
                {
                    vizsgalt_fajta2 = kfajtaadatok[i].fajta_nev;
                    db2++;
                }
            }

            for (int i = 0; i < elemekszama2; i++)
            {
                if (kfajtaadatok[i].fajta_id == fajtadb3)
                {
                    vizsgalt_fajta3 = kfajtaadatok[i].fajta_nev;
                    db3++;
                }
            }

            for (int i = 0; i < elemekszama2; i++)
            {
                if (kfajtaadatok[i].fajta_id == fajtadb4)
                {
                    vizsgalt_fajta4 = kfajtaadatok[i].fajta_nev;
                    db4++;
                }
            }

            Console.WriteLine("8. feladat: 2018 január 10-én vizsgált kutyafajták " +"(" + vizsgaltdb + " db):");
            Console.WriteLine("-" + vizsgalt_fajta.ToString() + " " +  db.ToString() + " db");
            Console.WriteLine("-" + vizsgalt_fajta2.ToString() + " " + db2.ToString() + " db");
            Console.WriteLine("-" + vizsgalt_fajta3.ToString() + " " + db3.ToString() + " db");
            Console.WriteLine("-" + vizsgalt_fajta4.ToString() + " " + db4.ToString() + " db");

            //9. feladat
            

            int datumdb = 0;
            int maxdatumdb = 0;
            String leterhelt_nap = "";

            for (int i = 0; i < elemekszama3; i++)
            {
                datumdb = 1;

                for (int j = i + 1; j < elemekszama3; j++)
                {
                    if (kadatok[i].ut_orv_ell.Equals(kadatok[j].ut_orv_ell))
                    {
                        datumdb++;
                        
                    }
                }  
                if (datumdb > maxdatumdb)
                {
                    maxdatumdb = datumdb;
                    leterhelt_nap = (String)kadatok[i].ut_orv_ell;
                    
                }
            }

            Console.WriteLine("9. feladat: Legjobban leterhelt nap: " + leterhelt_nap + ": " + maxdatumdb + " kutya" );

            //10. feladat


            Console.ReadLine();
        }
    }
}
