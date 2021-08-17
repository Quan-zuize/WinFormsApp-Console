using System;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.OutputEncoding = Encoding.Unicode;
			Console.InputEncoding = Encoding.Unicode;
			string value = "Môi tìm môi tim môi em tím đỏ";

			// Use a new char array of two characters (\r and \n).
			// ... Breaks lines into separate strings.
			// ... Use RemoveEntryEntries to make sure not empty strings are added.
			char[] delimiters = { ' ' };
			string[] parts = value.Split(delimiters,
							 StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < parts.Length; i++)
			{
				Console.WriteLine(parts[i]);
			}

			// Same as the previous example, but uses a string of 2 characters.
			parts = value.Split(new string[] { " " }, StringSplitOptions.None);
			for (int i = 0; i < parts.Length; i++)
			{
				Console.WriteLine(parts[i]);
			}
		}
    }
}
