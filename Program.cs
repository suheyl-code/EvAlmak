using EvAlmak.ColorConsole;
using EvAlmak.Evler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            Console.Write("Hangi numara? ");
            byte evModel = default;
            string cephe;
            int banyo, kat, balkon, bahce, numberOfChimney;
            bool sauna, sumine, fitness;
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

                    GeneralQuestions(out cephe, out banyo, out balkon);

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

                    VillaSpecificQuestions(out bahce, out sauna, out sumine, out numberOfChimney, out fitness);

                    var villa = new Villa(cephe, banyo, balkon, kat, bahce, sauna, sumine, numberOfChimney, fitness);
                    var fiyat = villa.VillaFiyatHesaplama();
                    Print.WriteLine($"\n*** İstanbul'da benzer villalar ortalama {fiyat:C2} dir. ***", ConsoleColor.Blue);

                    WriteToSQLTable(bahce, banyo, balkon, sumine, fitness, kat, fiyat);

                    break;
                case 2: // Daire

                    GeneralQuestions(out cephe, out banyo, out balkon);

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

                    var daire = new Daire(cephe, banyo, kat, balkon);

                    Print.WriteLine($"\n*** İstanbul'da benzer daireler ortalama {daire.DaireFiyatHesaplama():C2} dir. ***", ConsoleColor.Blue);

                    break;
                case 3: // Mustakil

                    GeneralQuestions(out cephe, out banyo, out balkon);
                    MustakilSpecificQuestions(out bahce);

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

                    var mustakil = new Mustakil(cephe, banyo, balkon, kat, bahce);

                    Print.WriteLine($"\n*** İstanbul'da benzer Mustakil evler ortalama {mustakil.MustakilFiyatHesaplama():C2} dir. ***", ConsoleColor.Blue);

                    break;
                case 4: // Dubleks

                    GeneralQuestions(out cephe, out banyo, out balkon);

                    VillaSpecificQuestions(out bahce, out sauna, out sumine, out numberOfChimney, out fitness);

                    var dubleks = new Dubleks(cephe, banyo, balkon, bahce, sauna, sumine, numberOfChimney, fitness);

                    Print.WriteLine($"\n*** İstanbul'da benzer dubleks evler ortalama {dubleks.VillaFiyatHesaplama():C2} dir. ***", ConsoleColor.Blue);

                    break;
                default:
                    break;


            }

        }

        private static void GeneralQuestions(out string cephe, out int banyo, out int balkon)
        {
            Console.Clear();
            Print.WriteLine("<- İstanbul'da ev fiyatları tahmin sistemine hoş geldiniz ->", ConsoleColor.Green);
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
            else if (banyo <= 0)
            {
                Print.WriteLine("1 seçildi.", ConsoleColor.Green);
                banyo = 1;
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
            Console.Write("Eviniz bahçesi kaç m2 olsun? ");
            bahce = Convert.ToInt32(Console.ReadLine());

            Console.Write("Eviniz içerde Sauna olsun mu? (Evet/Hayır) ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "evet")
                sauna = true;
            else
                sauna = false;

            Console.Write("Eviniz içerde Şumine olsun mu? (Evet/Hayır) ");
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

            Console.Write("Eviniz içerde Fitness Salonu olsun mu? (Evet/Hayır) ");
            string anotherAnswer = Console.ReadLine();
            if (anotherAnswer.ToLower() == "evet")
                fitness = true;
            else
                fitness = false;
        }

        private static void MustakilSpecificQuestions(out int bahce)
        {
            Console.Write("Mustakil Evinizin bahçesi kaç m2 olsun? ");
            bahce = Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// 
        /// </summary>
        private static SqlConnection SetSQLConnection()
        {
            var deviceName = Environment.MachineName.ToString();
            string dataSource = default;
            if (deviceName.ToLower().Equals("asus"))
            {
                dataSource = @"Asus\SQLEXPRESS";

            }
            else if (deviceName.ToLower().Equals("lenovothinkbook"))
            {
                dataSource = @"LenovoThinkbook\SQLEXPRESS";
            }
            string dataBase = "EvAlmak";
            string connectionString = @"Data Source=" + dataSource + ";Initial Catalog=" + dataBase + ";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                Print.WriteLine("\tSQL bağlantısı kuruldu...", ConsoleColor.Yellow);
            }
            catch (Exception e)
            {
                Print.WriteLine("SQL bağlantısında hata var!" + e.Message, ConsoleColor.Red);
            }
            return connection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bahce"></param>
        /// <param name="banyo"></param>
        /// <param name="balkon"></param>
        /// <param name="sumine"></param>
        /// <param name="fitness"></param>
        /// <param name="kat"></param>
        /// <param name="fiyat"></param>
        private static void WriteToSQLTable(int bahce, int banyo, int balkon, bool sumine, bool fitness, int kat, double fiyat)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Insert into Elements (Size,Bath,Balcony,Chimney,Fitness,Floor,Price) Values");
            stringBuilder.Append($"(N'{bahce}',N'{banyo}',N'{balkon}',N'{sumine}',N'{fitness}',N'{kat}',N'{fiyat}')");
            string sqlQuery = stringBuilder.ToString();

            using (SqlCommand command = new SqlCommand(sqlQuery, SetSQLConnection()))
            {
                command.ExecuteNonQuery();
                Print.WriteLine("verileriniz başarıyla veritabanına eklendi", ConsoleColor.Yellow);
            }
        }

    }
}
