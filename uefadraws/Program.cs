using System;
using System.Collections.Generic;
using System.Text;

namespace uefadraws
{

    class Program
    {
        static void Main(string[] args)
        {
            String[] pot1 = { "Real Madrid (SPA) pot1", "Frankfurt (GER) pot1", "Man City (ENG) pot1",
                "Milan (ITA) pot1", "Bayern (GER) pot1", "Paris (FRA) pot1", "Porto (POR) pot1", "Ajax (NED) pot1" };
            String[] pot2 = { "Liverpool (ENG) pot2", "Chelsea (ENG) pot2", "Barcelona (SPA) pot2",
                "Juventus (ITA) pot2", "Atletico (SPA) pot2", "Sevilla (SPA) pot2", "Leipzig (GER) pot2", "Tottenham (ENG) pot2" };
            String[] pot3 = { "Dortmund (GER) pot3","Salzburg (AUS) pot3","Shakhtar (UKR) pot3",                    
                "Inter (ITA) pot3","Napoli (ITA) pot3","Benfica (POR) pot3","Sporting CP (POR) pot3","Leverkusen (GER) pot3"};
            String[] pot4 = { "Rangers (SCO) pot4", "Zagreb (CRO) pot4", "Marseille (FRA) pot4",
                "Copehnagen (DEN) pot4", "Club Brugge (BEL) pot4", "Celtic (SCO) pot4", "Plzen (CZE) pot4", "M.Haifa (ISR) pot4" };
            String[] Groups = new String[32];
            int sayac = 0;
            int potsayac = 0;
            int[] yerlestirilen= new int[1];
            yerlestirilen[0] = 8; 
            while (sayac < 32)
            {
                        Groups[sayac] = pot1[potsayac];
                        potsayac++;                           //pot 1 herhangi bir yere yerleştirilebileceği için sırayla dağıttım.
                        sayac += 4;
            }
            sayac = 1;                                       //sayac her bir gruptaki yerleştirilmiş takım sayısını belirtiyor.
            while (yerlestirilen[0]<16)                     //yerlestirilen sayısına göre mevcut sayıda takıma göre kontrol yapılıyor.
            {
            dagitim(pot2, Groups, sayac, yerlestirilen);
            }
            sayac++;
            while (yerlestirilen[0]< 24)
            {
                dagitim(pot3, Groups, sayac, yerlestirilen);
            }
            sayac++;
            while (yerlestirilen[0]< 32)
            {
                dagitim(pot4, Groups, sayac, yerlestirilen);
            }
            int bosluk = 0;
            String[] groupnames = { "A", "B", "C", "D", "E", "F", "G", "H" };
            int grupsayisi = 0;                                //yazdırma
            Console.WriteLine("GROUP" + " " + groupnames[grupsayisi]);
            for (int i = 0; i < Groups.Length; i++)
            {
                Console.WriteLine(Groups[i]);
                bosluk++;
                if (bosluk%4==0)
                {
                    grupsayisi++;
                    Console.WriteLine(" ");
                    if (grupsayisi<8)
                    {
                        Console.WriteLine("GROUP" + " " + groupnames[grupsayisi]);
                    }
                }
            }
            Console.ReadLine();
        }
        static void dagitim(String[] pot1, String[] Groups, int sayac,int[] yerlestirilen)
        {
           bool kontrol = false;
           int potsayac = 0;
           while (sayac < 32)
            {
                int parantez = pot1[potsayac].IndexOf("(");
                String takim = pot1[potsayac].ToCharArray()[parantez + 1].ToString() + pot1[potsayac].ToCharArray()[parantez + 2].  
                ToString() + pot1[potsayac].ToCharArray()[parantez + 3].ToString();
                while (kontrol==false &&Groups[sayac]==null)
                {
                    int minsayac = sayac - (sayac % 4);
                    for (int i = minsayac; i < sayac; i++)
                    {
                        int parantez2 = Groups[i].IndexOf("(");
                        String takim2 = Groups[i].ToCharArray()[parantez2 + 1].ToString() + Groups[i].ToCharArray()[parantez2 + 2].
                    ToString() + Groups[i].ToCharArray()[parantez2 + 3].ToString();
                        if (takim == takim2)
                        {
                            sayac += 4;
                            kontrol=false;
                            break;
                        }
                        kontrol = true;
                    }
                }
                kontrol = false;
                if (Groups[sayac] == null)
                {
                    Groups[sayac] = pot1[potsayac];
                    yerlestirilen[0]++;
                    potsayac++;
                    sayac += 4;
                }
                else
                    sayac += 4;
            }
            }
        }
    }

 

