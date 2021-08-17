
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileApplication
{
    class Program
    {
        static List<String> listCauTho = new List<string>();
        static void docTho()
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("C:/Users/ADMIN/source/repos/FileApplication/GiotNang.txt"))
                {
                    string line;

                    // Read and display lines from the file until 
                    // the end of the file is reached. 
                    while ((line = sr.ReadLine()) != null)
                    {
                        listCauTho.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        static void hienthi()
        {
            foreach (String i in listCauTho)
            {
                Console.WriteLine(i);
            }
        }

        static int sotu(string chuoi)
        {
            string[] parts = chuoi.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return parts.Length;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            docTho();
            hienthi();
            foreach (String i in listCauTho)
            {
                Console.WriteLine(sotu(i)); 
            }
        }
    }
}