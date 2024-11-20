using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Student
    {
        private int id;
        private string name;
        private int age;

        public Student() { }

        public Student(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
    class ct
    {
        //a.In Danh Sach Hoc Sinh
        public static void InDanhSach(List<Student> danhSachHocSinh)
        {
            Console.WriteLine("Danh sach hoc sinh:");
            Console.WriteLine("Id\tName\t\tAge");
            foreach (Student hocsinh in danhSachHocSinh)
            {
                Console.WriteLine($"{hocsinh.Id}\t{hocsinh.Name}\t{hocsinh.Age}");
            }
        }
        //b.tim va in danh sach hs co do tuoi tu 15 den 18
        public static void DanhSach15Den18(List<Student> danhsachHocSinh)
        {
            Console.WriteLine("Danh sach hoc sinh co do tuoi tu 15 den 18:");
            Console.WriteLine("Id\tName\t\tAge");
            var danhsach15den18 = danhsachHocSinh.Where(hocsinh => hocsinh.Age >= 15 && hocsinh.Age <= 18).ToList();
            foreach(Student hocsinh in danhsach15den18)
            {
                Console.WriteLine($"{hocsinh.Id}\t{hocsinh.Name}\t{hocsinh.Age}");
            }
        }
        //c.tim va in danh  sach hoc sinh co ten bat dau bang chu 'A'
        public static void HocSinhBatDauBangChuA(List<Student> danhsachHocSinh)
        {
            Console.WriteLine("Danh sach hoc sinh co ten bat dau bang chu 'A':");
            Console.WriteLine("Id\tName\t\tAge");
            var danhsachA = danhsachHocSinh.Where(hocsinh => hocsinh.Name.StartsWith("A")).ToList();
            foreach (Student hocsinh in danhsachA)
            {
                Console.WriteLine($"{hocsinh.Id}\t{hocsinh.Name}\t{hocsinh.Age}");
            }
        }
        //d.tinh tong tuoi tat ca hoc sinh trong danh sach
        public static void TongTuoiHS(List<Student> danhsachHocSinh)
        {
            int tongTuoi = danhsachHocSinh.Sum(hocsinh => hocsinh.Age);
            Console.WriteLine($"Tong tuoi tat ca hoc sinh trong danh sach: {tongTuoi}");
            
        }

        //e. tim va in ra hoc sinh co tuoi lon nhat 
        public static void TuoiMax(List<Student > danhsachHocSinh)
        {
            Console.WriteLine("Hoc sinh co tuoi lon nhat:");
            Console.WriteLine("Id\tName\t\tAge");
            int tuoiMax = danhsachHocSinh.Max(hocsinh => hocsinh.Age);
            var hocsinhTuoiMax = danhsachHocSinh.Where(hocsinh => hocsinh.Age == tuoiMax).ToList();
            foreach (Student hocsinh in hocsinhTuoiMax)
            {
                Console.WriteLine($"{hocsinh.Id}\t{hocsinh.Name}\t{hocsinh.Age}");
            }
        }
        //f. sap xep danh sach hoc sinh theo do tuoi tang dan va in ra danh sach sap xep
        public static void DanhSachTuoiTangDan(List<Student> danhsachHocSinh)
        {
            Console.WriteLine("Danh sach hoc sinh sap xep theo do tuoi tang dan:");
            Console.WriteLine("Id\tName\t\tAge");
            var danhsachTangDan = danhsachHocSinh.OrderBy(hocsinh => hocsinh.Age).ToList();
            foreach (Student hocsinh in danhsachTangDan)
            {
                Console.WriteLine($"{hocsinh.Id}\t{hocsinh.Name}\t{hocsinh.Age}");
            }
        }
        
        //Ham Main
        static void Main(string[] args)
        {
            List<Student> danhSachHocSinh = new List<Student>
            {                
                new Student {Id = 1, Name = "Minh Tan", Age = 18},
                new Student {Id = 2, Name = "Van Thinh", Age = 17 },
                new Student {Id = 3, Name = "Thanh Nhan", Age = 19 },
                new Student {Id = 4, Name = "Manh Cuong", Age = 20 },
                new Student {Id = 5, Name = "Anh Minh", Age = 15}
            };
            InDanhSach(danhSachHocSinh);
            Console.WriteLine("=============================================");
            DanhSach15Den18(danhSachHocSinh);
            Console.WriteLine("=============================================");
            HocSinhBatDauBangChuA(danhSachHocSinh);
            Console.WriteLine("=============================================");
            TongTuoiHS(danhSachHocSinh);
            Console.WriteLine("=============================================");
            TuoiMax(danhSachHocSinh);
            Console.WriteLine("=============================================");
            DanhSachTuoiTangDan(danhSachHocSinh);
        }
    }
}


