using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AnonfilesLinks
{
    class Program
    {
        private static Random random = new Random();
        public static int urlsChecked = 0;
        public static string path = @"Valid.txt";

        static void Main(string[] args)
        {
            Console.Title = "AnonBrute";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ANONBRUTE - ItsYeBoi2016");
            Console.ResetColor();
            Console.Write("\nEnter numbers of URLs to check: ");
            string numbersCheck = Console.ReadLine();

            urlsChecked = 0;
            int x = 0;
            Int32.TryParse(numbersCheck, out x);
            WebClient wb = new WebClient();
            Console.Clear();

            if (x == 0)
            {
                while(true)
                {
                    string getRandom = RandomString(10);

                    try
                    {
                        string checkValid = wb.DownloadString("https://anonfiles.com/" + getRandom);
                        if (!checkValid.Contains("The file you are looking for does not exist!"))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[VALID] https://anonfiles.com/" + getRandom);
                            Console.ResetColor();

                            #region WritetoFile

                            if (!File.Exists(path))
                            {
                                File.Create(path).Dispose();

                                using (TextWriter tw = new StreamWriter(path))
                                {
                                    tw.WriteLine("https://anonfiles.com/" + getRandom + Environment.NewLine);
                                }

                            }
                            else if (File.Exists(path))
                            {
                                File.AppendAllText(path, "https://anonfiles.com/" + getRandom + Environment.NewLine);
                            }

                            #endregion WritetoFile
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("[INVALID] https://anonfiles.com/" + getRandom);
                        Console.ResetColor();
                    }
                    urlsChecked++;
                    Console.Title = "AnonBrute | " + urlsChecked + " Checked";
                }
            }
            else
            {

                while (urlsChecked < x)
                {
                    string getRandom = RandomString(10);

                    try
                    {
                        string checkValid = wb.DownloadString("https://anonfiles.com/" + getRandom);
                        if (!checkValid.Contains("The file you are looking for does not exist!"))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[VALID] https://anonfiles.com/" + getRandom);
                            Console.ResetColor();

                            #region WritetoFile

                            if (!File.Exists(path))
                            {
                                File.Create(path).Dispose();

                                using (TextWriter tw = new StreamWriter(path))
                                {
                                    tw.WriteLine("https://anonfiles.com/" + getRandom + Environment.NewLine);
                                }

                            }
                            else if (File.Exists(path))
                            {
                                File.AppendAllText(path, "https://anonfiles.com/" + getRandom + Environment.NewLine);
                            }

                            #endregion WritetoFile
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("[INVALID] https://anonfiles.com/" + getRandom);
                        Console.ResetColor();
                    }
                    urlsChecked++;
                    Console.Title = "AnonBrute | " + urlsChecked + "/" + x + " Checked";
                }
            }
            Console.ReadLine();
        }

        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
