using EvAlmak.ColorConsole;
using EvAlmak.Evler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvAlmak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            Console.WriteLine("Ev netur olsun ");
            Console.WriteLine("\t1. Villa");
            Console.WriteLine("\t2. Daire");
            Console.WriteLine("\t3. Mustakil");
            Console.WriteLine("\t4. Dubleks");
            Console.Write("Hangi? ");
            byte evModel = default;
            try
            {
                evModel = Convert.ToByte(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Print.WriteLine(ex.Message, ConsoleColor.Red);
            }
            switch (evModel)
            {
                case 1: // Villa
                    string cephe;
                    int banyo, kat, balkon, bahce, numberOfChimney;
                    bool sauna, sumine, fitness;
                    GeneralQuestions(out cephe, out banyo, out kat, out balkon);
                    VillaSpecificQuestions(out bahce, out sauna, out sumine, out numberOfChimney, out fitness);

                    var villa = new Villa(cephe, banyo, balkon, kat, bahce, sauna, sumine, numberOfChimney, fitness);

                    Print.WriteLine($"\n*** İstanbul'da benzer villalar ortalama {villa.VillaFiyatHesaplama():C2} dir. ***", ConsoleColor.Blue);

                    break;
                case 2: // Daire
                    
                    GeneralQuestions(out cephe, out banyo, out kat, out balkon);

                    var daire = new Daire(cephe, banyo, kat, balkon);

                    Print.WriteLine($"\n*** İstanbul'da benzer daireler ortalama {daire.DaireFiyatHesaplama():C2} dir. ***", ConsoleColor.Blue);

                    break;
                case 3: // Mustakil
                 
                    GeneralQuestions(out cephe, out banyo, out kat, out balkon);
                    MustakilSpecificQuestions(out bahce);

                    var mustakil = new Mustakil(cephe, banyo, balkon, kat, bahce);

                    Print.WriteLine($"\n*** İstanbul'da benzer Mustakil evler ortalama {mustakil.MustakilFiyatHesaplama():C2} dir. ***", ConsoleColor.Blue);

                    break;
                case 4: // Dubleks

                    GeneralQuestions(out cephe, out banyo, out kat, out balkon);
                    DubleksSpecificQuestions(out bahce);

                    var dubleks = new Dubleks(cephe, banyo, balkon, kat = 2, bahce);

                    Print.WriteLine($"\n*** İstanbul'da benzer dubleks evler ortalama {dubleks.DubleksFiyatHesaplama():C2} dir. ***", ConsoleColor.Blue);

                    break;
                default:
                    break;
            }

        }

        private static void GeneralQuestions(out string cephe, out int banyo, out int kat, out int balkon)
        {
            Console.Write("Evin hangı cephe'de olsun (guney/kuzey)? ");
            cephe = Console.ReadLine();

            Console.Write("Evinde kaç tane banyo olsun? ");
            banyo = Convert.ToInt32(Console.ReadLine());
            if (banyo > 5)
            {
                Print.WriteLine("Bu kadar banyo bir evde bulamaz mı?!", ConsoleColor.Red);
                Print.WriteLine("3 seçildi.", ConsoleColor.Green);
                banyo = 3;
            }
            else if(banyo <= 0)
            {
                Print.WriteLine("1 seçildi.", ConsoleColor.Green);
                banyo = 1;
            }

            
            Console.Write("Evin kaç katli olsun? ");
            kat = Convert.ToInt32(Console.ReadLine());
            if (kat > 3)
            {
                Print.WriteLine("Bir tane ev mi almak istiyorsunuz?", ConsoleColor.Red);
                Print.WriteLine("3 seçildi.", ConsoleColor.Green);
                kat = 3;
            }
            else if (kat <= 0)
            {
                Print.WriteLine("Kot seçildi.", ConsoleColor.Green);
                kat = 0;
            }

            Console.Write("Evinde kaç tane balkon olsun? ");
            balkon = Convert.ToInt32(Console.ReadLine());
            if (balkon > 5)
            {
                Print.WriteLine("Bu kadar balkon bir evde bulamaz mı?!", ConsoleColor.Red);
                Print.WriteLine("3 tane balkon seçildi.", ConsoleColor.Green);
                balkon = 3;
            }
            else if (balkon < 0)
            {
                Print.WriteLine("Hiç balkon seçilmedi.", ConsoleColor.Green);
                balkon = 0;
            }

        }

        private static void VillaSpecificQuestions(out int bahce, out bool sauna, out bool sumine, out int numberOfChimney, out bool fitness)
        {
            Console.Write("Villaniz bahçesi kaç m2 olsun? ");
            bahce = Convert.ToInt32(Console.ReadLine());

            Console.Write("Villanız içerde Sauna olsun mu? (Evet/Hayır) ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "evet")
                sauna = true;
            else
                sauna = false;

            Console.Write("Villanız içerde Şumine olsun mu? (Evet/Hayır) ");
            string nextAnswer = Console.ReadLine();
            if (nextAnswer.ToLower() == "evet")
            {
                sumine = true;
                Console.Write("kaç tane? ");
                int kacSumine = Convert.ToInt32(Console.ReadLine());
                if (kacSumine > 0)
                    numberOfChimney = kacSumine;
                else
                    numberOfChimney = 0;
            }
            else
            {
                sumine = false;
                numberOfChimney = 0;
            }

            Console.Write("Villanız içerde Fitness Salonu olsun mu? (Evet/Hayır) ");
            string anotherAnswer = Console.ReadLine();
            if (anotherAnswer.ToLower() == "evet")
                fitness = true;
            else
                fitness = false;
        }

        private static void MustakilSpecificQuestions(out int bahce)
        {
            Console.Write("Mustakil Evlerinizin bahçesi kaç m2 olsun? ");
            bahce = Convert.ToInt32(Console.ReadLine());
        }

        private static void DubleksSpecificQuestions(out int bahce)
        {
            Console.Write("Dubleks Evlerinizin bahçesi kaç m2 olsun? ");
            bahce = Convert.ToInt32(Console.ReadLine());
        }
    }
}
