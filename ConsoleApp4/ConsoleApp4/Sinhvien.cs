using System;

namespace ConsoleApp4
{
    abstract class Sinhvien
    {
        int maSV;
        string tenSV;
        public int MaSV
        {
            get { return maSV; }
            set { maSV = value; }
        }

        public string TenSV
        {
            get { return tenSV; }
            set { tenSV = value; }
        }

        virtual public void setSV()
        {
            Console.Write("Nhập mã sinh viên : ");
            maSV = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhập tên sinh viên : ");
            tenSV = Console.ReadLine();
        }

        virtual public void viewSV()
        {
            Console.WriteLine("Mã sinh viên : "+MaSV);
            Console.WriteLine("Tên sinh viên : " + TenSV);
        }
    }
}
