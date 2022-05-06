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
                    try
                    {
                        kat = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        kat = 1;
                        Print.WriteLine("1 seçildi.", ConsoleColor.Green);
                    }

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

                    WriteToSQLTableVila(cephe, bahce, banyo, balkon, sauna, sumine, numberOfChimney, fitness, kat, fiyat);

                    break;
                case 2: // Daire

                    GeneralQuestions(out cephe, out banyo, out balkon);

                    Console.Write("Evin kaç katli olsun? ");
                    try
                    {
                        kat = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        kat = 1;
                        Print.WriteLine("1 seçildi.", ConsoleColor.Green);
                    }
                   
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
                    fiyat = daire.DaireFiyatHesaplama();
                    Print.WriteLine($"\n*** İstanbul'da benzer daireler ortalama {fiyat:C2} dir. ***", ConsoleColor.Blue);

                    WriteToSQLTableDaire(cephe, banyo, balkon, kat, fiyat);

                    break;
                case 3: // Mustakil

                    GeneralQuestions(out cephe, out banyo, out balkon);
                    MustakilSpecificQuestions(out bahce);

                    Console.Write("Evin kaç katli olsun? ");
                    try
                    {
                        kat = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        kat = 1;
                        Print.WriteLine("1 seçildi.", ConsoleColor.Green);
                    }

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
                    fiyat = mustakil.MustakilFiyatHesaplama();
                    Print.WriteLine($"\n*** İstanbul'da benzer Mustakil evler ortalama {fiyat:C2} dir. ***", ConsoleColor.Blue);

                    WriteToSQLTableMustakil(cephe, bahce, banyo, balkon, kat, fiyat);

                    break;
                case 4: // Dubleks

                    GeneralQuestions(out cephe, out banyo, out balkon);
                    VillaSpecificQuestions(out bahce, out sauna, out sumine, out numberOfChimney, out fitness);
                    
                    kat = 2;

                    var dubleks = new Dubleks(cephe, banyo, balkon, bahce, sauna, sumine, numberOfChimney, fitness);
                    fiyat = dubleks.VillaFiyatHesaplama();
                    Print.WriteLine($"\n*** İstanbul'da benzer dubleks evler ortalama {fiyat:C2} dir. ***", ConsoleColor.Blue);

                    WriteToSQLTableDubleks(kat, cephe, bahce, banyo, balkon, sauna, sumine, numberOfChimney, fitness, fiyat);
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
            try
            {
                cephe = Console.ReadLine();
            }
            catch (Exception)
            {
                cephe = "South";
                Print.WriteLine("'kuzey' seçildi.", ConsoleColor.Green);
            }

            if (cephe.ToLower().StartsWith("g"))
                cephe = "North";
            else if (cephe.ToLower().StartsWith("k"))
                cephe = "South";
            else
                cephe = "Unknown";

            Console.Write("Evinde kaç tane banyo olsun? ");
            try
            {
                banyo = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                banyo = 1;
                Print.WriteLine("1 seçildi.", ConsoleColor.Green);
            }

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
            try
            {
                balkon = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                balkon = 0;
                Print.WriteLine("0 seçildi.", ConsoleColor.Green);
            }

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
            try
            {
                bahce = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                bahce = 15;
                Print.WriteLine("15 m2 seçildi.", ConsoleColor.Green);
            }

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
                int kacSumine = default;
                Console.Write("kaç tane? ");
                try
                {
                    kacSumine = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    numberOfChimney = 1;
                    Print.WriteLine("1 seçildi.", ConsoleColor.Green);
                }
                
                if (kacSumine > 0)
                    numberOfChimney = kacSumine;
                else
                    numberOfChimney = 1;
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
            else if(string.IsNullOrEmpty(anotherAnswer))
                fitness = false;
            else
                fitness = false;
        }

        private static void MustakilSpecificQuestions(out int bahce)
        {
            Console.Write("Mustakil Evinizin bahçesi kaç m2 olsun? ");
            try
            {
                bahce = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                bahce = 0;
                Print.WriteLine("Hiç Bahçe m2 Seçilmedi!", ConsoleColor.Green);
            }
            
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
            else
            {
                dataSource = @"(localdb)\SQLEXPRESS";
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
        /// Normal daire için, veritabanilar farkli
        /// </summary>
        /// <param name="cephe"></param>
        /// <param name="banyo"></param>
        /// <param name="balkon"></param>
        /// <param name="kat"></param>
        /// <param name="fiyat"></param>
        private static void WriteToSQLTableDaire(params object[] elements)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Insert into Daire (Direction,Bath,Balcony,Floor,Price) Values");
            stringBuilder.Append($"(N'{elements[0]}',N'{elements[1]}',N'{elements[2]}',N'{elements[3]}',N'{elements[4]}')");
            string sqlQuery = stringBuilder.ToString();

            using (SqlCommand command = new SqlCommand(sqlQuery, SetSQLConnection()))
            {
                command.ExecuteNonQuery();
                Print.WriteLine("verileriniz başarıyla veritabanına eklendi", ConsoleColor.Yellow);
            }
        }

        /// <summary>
        /// Villa için, veritabanilar farkli
        /// </summary>
        /// <param name="bahce"></param>
        /// <param name="banyo"></param>
        /// <param name="balkon"></param>
        /// <param name="sumine"></param>
        /// <param name="fitness"></param>
        /// <param name="kat"></param>
        /// <param name="fiyat"></param>
        private static void WriteToSQLTableVila(params object[] elements)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Insert into Vila (Direction,Size,Bath,Balcony,Sauna,Chimney,NumberOfChimney,Fitness,Floor,Price) Values");
            stringBuilder.Append($"(N'{elements[0]}',N'{elements[1]}',N'{elements[2]}',N'{elements[3]}',N'{elements[4]}',N'{elements[5]}',N'{elements[6]}',N'{elements[7]}',N'{elements[8]}',N'{elements[9]}')");
            string sqlQuery = stringBuilder.ToString();

            using (SqlCommand command = new SqlCommand(sqlQuery, SetSQLConnection()))
            {
                command.ExecuteNonQuery();
                Print.WriteLine("verileriniz başarıyla veritabanına eklendi", ConsoleColor.Yellow);
            }
        }

        /// <summary>
        /// Mustakil için, veritabanilar farkli
        /// </summary>
        /// <param name="elements"></param>
        private static void WriteToSQLTableMustakil(params object[] elements)
        {
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Insert into Mustakil (Direction,Size,Bath,Balcony,Floor,Price) Values");
                stringBuilder.Append($"(N'{elements[0]}',N'{elements[1]}',N'{elements[2]}',N'{elements[3]}',N'{elements[4]}',N'{elements[5]}')");
                string sqlQuery = stringBuilder.ToString();

                using (SqlCommand command = new SqlCommand(sqlQuery, SetSQLConnection()))
                {
                    command.ExecuteNonQuery();
                    Print.WriteLine("verileriniz başarıyla veritabanına eklendi", ConsoleColor.Yellow);
                }
            }
        }

        /// <summary>
        /// Dubleks için, veritabanilar farkli
        /// </summary>
        /// <param name="kat"></param>
        /// <param name="elements"></param>
        private static void WriteToSQLTableDubleks(params object[] elements)
        {
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Insert into Dubleks (Floor,Direction,Size,Bath,Balcony,Sauna,Chimney,NumberOfChimney,Fitness,Price) Values");
                stringBuilder.Append($"(N'{elements[0]}',N'{elements[1]}',N'{elements[2]}',N'{elements[3]}',N'{elements[4]}',N'{elements[5]}',N'{elements[6]}',N'{elements[7]}',N'{elements[8]}',N'{elements[9]}')");
                string sqlQuery = stringBuilder.ToString();

                using (SqlCommand command = new SqlCommand(sqlQuery, SetSQLConnection()))
                {
                    command.ExecuteNonQuery();
                    Print.WriteLine("verileriniz başarıyla veritabanına eklendi", ConsoleColor.Yellow);
                }
            }
        }
    }
}
