using System;
using System.Text;

namespace ConsoleApp7
{
    class Program
    {
        static string[] a = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');

        static string convertToWord(int n)
        {
            string s = "";
            int units, tens, hundreds;

            units = n % 10;
            n /= 10;
            tens = n % 10;
            hundreds = n / 10;
            //hundreds
            if (hundreds > 0)
            {
                s += a[hundreds];
                s += " trăm ";
            }
            //dozens
            if (tens > 0)
            {
                if (tens == 1)
                    s += "mười ";
                else
                {
                    s += a[tens];
                    s += " mươi ";
                }
            }
            //per unit
            if (units > 0)
            {
                if (tens == 0 && hundreds != 0)
                {
                    s += "linh ";
                }
                if (units == 1)
                {
                    s += "một";
                }
                else if (units == 5 && (tens == 0 || hundreds != 0))
                {
                    s += "lăm";
                }
                else
                {
                    s += a[units];
                }

            }
            return s;
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            int thousands, millions, billions, units, n;

            Console.WriteLine("Nhập một số : ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Đọc bằng chữ : ");

            units = n % 1000;
            n /= 1000;
            thousands = n % 1000;
            n /= 1000;
            millions = n % 1000;
            billions = n / 1000;
            if (billions > 0)
                Console.Write(convertToWord(billions) + " tỷ ");
            if (millions > 0)
                Console.Write(convertToWord(millions) + " triệu ");
            if (thousands > 0)
                Console.Write(convertToWord(thousands) + " ngàn ");
            if (units > 0)
                Console.Write(convertToWord(units));
        }
    }
}
