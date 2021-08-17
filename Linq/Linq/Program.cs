using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        public static void Testlinq_00()
        {
            List<int> ml1 = new List<int>() { 1, 5, 7, 8, 4, 5, 6, 0, 12, 23, 34, 56 };

            var b1 = from n in ml1 where n % 2 == 0 select n;
            foreach (var m in b1)
            {
                Console.WriteLine("Số chia hết cho 2: " + m);
            }
            Console.WriteLine("-----------------------------");
            var b2 = from n in ml1 where n % 3 == 0 select n;
            foreach (var m in b2)
            {
                Console.WriteLine("Số chia hết cho 3: " + m);
            }
            Console.WriteLine("-----------------------------");
            var b3 = from n in ml1 where n > 3 && n < 15 select n;
            foreach (var m in b3)
            {
                Console.WriteLine("Lớn hơn 3 và nhỏ hơn 15: " + m);
            }
        }

        static List<String> mls = new List<string>
        {
            "Nguyễn Văn Tú",
            "Nguyễn Văn Tâm",
            "Nguyễn Văn Minh",
            "Nguyễn Văn Long",
            "Nguyễn Văn Hải Anh",
            "Nguyễn Văn Trần",
            "Nguyễn Văn Trần",
            "Lý Văn Tâm",
            "Lý Văn Thanh",
            "Lý Văn Vân",
            "Mai Tú",
            "Mai Văn Tâm", "Mai n Minh","Chu Văn Long",
            "Chu Văn Hải Anh","Lý Tú","Chu An","Yến Nhi","Linh Cao"
        };

        public static void Testlinq_11()
        {
            var b = from m in mls where m.Contains("Lý") select m;
            foreach (var m in b)
            {
                Console.WriteLine("Chọn họ Lý: " + m);
            }

            var b2 = from m in mls where m.Contains("Lý") select m.Replace("Lý", "Lý Khắc");
            foreach (var m in b2)
            {
                Console.WriteLine("Đổi họ Lý-> Lý Khắc: " + m);
            }

            var b3 = from m in mls where m.Contains("Lý") select m.ToUpper();
            foreach (var m in b3)
            {
                Console.WriteLine("Đổi họ Lý-> Lý Khắc: " + m);
            }

            var b4 = from m in mls where m.Length >= 11 select m.ToUpper();
            foreach (var m in b4)
            {
                Console.WriteLine("c: " + m);
            }
        }

        public static void Testlinq_22()
        {
            List<Customer> listCust = new List<Customer>();
            Customer c1 = new Customer() { Id = 2, Age = 22, Name = "Lý Tú ", Email = "tu@gmail.com" };
            Customer c2 = new Customer() { Id = 3, Age = 22, Name = "Lý Tý ", Email = "ty@gmail.com" };
            Customer c3 = new Customer() { Id = 4, Age = 15, Name = "Lý Minh ", Email = "minh@gmail.com" };
            Customer c4 = new Customer() { Id = 5, Age = 22, Name = "Lý Lâm ", Email = "lam@gmail.com" };
            Customer c5 = new Customer() { Id = 6, Age = 33, Name = "Lý Mận ", Email = "man@gmail.com" };
            Customer c6 = new Customer() { Id = 7, Age = 21, Name = "Cao Tú ", Email = "tu@gmail.com" };
            Customer c7 = new Customer() { Id = 8, Age = 20, Name = "Cao Anh ", Email = "anh@gmail.com" };
            Customer c8 = new Customer() { Id = 9, Age = 19, Name = "Chu Tú ", Email = "chutu@gmail.com" };
            listCust.Add(c1); listCust.Add(c2); listCust.Add(c3); listCust.Add(c4);
            listCust.Add(c5); listCust.Add(c6); listCust.Add(c7); listCust.Add(c8);

            var b = from m in listCust where m.Age > 22 select m;
            foreach (var s in b)
            {
                Console.WriteLine("Sinh viên có tuổi > 22: " + s.Name + ", " + s.Age);
            }

            var b2 = from m in listCust where m.Name.Contains("Lý") select m;
            foreach (var s in b2)
            {
                Console.WriteLine("Những người có họ Lý: " + s.Name + ", " + s.Age + ", " + s.Email);
            }

            var b3 = from m in listCust where m.Name.Contains("Lý") select new { TenMoi = m.Name, EmailMoi = m.Email, Tuoi = m.Age, KKK = "Code_" + m.Name.GetHashCode() };
            foreach (var s in b3)
            {
                Console.WriteLine("Đối tượng mới: " + s.TenMoi + ", " + s.EmailMoi + ", " + s.KKK);
            }
        }
        public static void Testlinq_3()
        {
            IList<Student> studentList = new List<Student>(){
            new Student() { StudentID = 1, StudentName = "John", Age = 18 },
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 },
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 },
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 },
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }};

            var orderByResult = studentList.OrderBy(s => s.StudentName).ToList();

            var orderByDescendingResult = from s in studentList orderby s.Age descending select s;

            Console.WriteLine("Ascending Order:");
            foreach (var std in orderByResult)
            {
                Console.WriteLine($"Name: {std.StudentName},Age {std.Age}");
            }

            Console.WriteLine("Descending Order:");
            foreach (var std in orderByDescendingResult)
            {
                Console.WriteLine($"Name: {std.StudentName},Age {std.Age}");
            }
        }
        static void Main(string[] args)
        {
            //Testlinq_00();
            //Testlinq_11();
            //Testlinq_22();
            Testlinq_3();
        }
    }
}