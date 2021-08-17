using System;

namespace ConsoleApp4
{
    class SinhvienCNTT : Sinhvien
    {
        double dtoan;
        double dtin;

        public override void setSV()
        {
            base.setSV();
            Console.WriteLine("Moi ban nhap vao diem toan cua sinh vien");
            dtoan = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Moi ban nhap vao diem tin cua sinh vien");
            dtin = Convert.ToDouble(Console.ReadLine());
        }
        public double tongdiem() => dtin + dtoan;  

        public override void viewSV()
        {
            base.viewSV();
            Console.WriteLine("Diem toan : " + dtoan);
            Console.WriteLine("Diem tin : " + dtin);
        }
    }
}
