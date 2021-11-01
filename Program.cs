using System;
using System.Globalization;

namespace Ca1T3_NguyenHoang_17DH110963_Buoi4
{
  class Program
  {
    static int workingDays = 22;

    static void Main(string[] args)
    {
      #region Set Data Staff and Staff Salary
      NhanVien model = Input();

      int bonus = 0;

      if (model.ChucVu == ChucVu.NhanVien)
      {
        bonus = 1;
      }

      if (model.ChucVu == ChucVu.TruongPhong)
      {
        bonus = 5;
      }

      if (model.ChucVu == ChucVu.GiamDoc)
      {
        bonus = 10;
      }

      Salary salary = new Salary(model.MaNV, bonus, (int)model.HocVi);

      #endregion

      #region Set Dayoff
      Console.WriteLine("----- Set ngay nghi -----");
      Console.Write("Tu ngay: ");
      DateTime fromDate = DateTime.Parse(Console.ReadLine());

      Console.Write("Den ngay: ");
      DateTime toDate = DateTime.Parse(Console.ReadLine());

      double totalDayoff = setPhep(fromDate, toDate);
      #endregion


      #region Service Calculate
      TinhBhYT(salary.BasicSalary);
      TinhBHXH(salary.BasicSalary);
      TinhBHTN(salary.BasicSalary);
      TinhThueTNCN(salary.BasicSalary);
      TinhTienPhep((int)totalDayoff, salary.BasicSalary);
      TongThuNhap(salary.BasicSalary, model.ThamNien);
      LuongThucNhan(salary.BasicSalary, model.ThamNien, (int)totalDayoff, bonus * 1000000);
      ThuongLe(salary.BasicSalary, model.NgayThamgia);
      #endregion
    }

    static NhanVien Input()
    {
      Console.Write("Ma Nhan vien: ");
      string maNv = Console.ReadLine();

      Console.Write("Nhap ten  Nhan vien: ");
      string name = Console.ReadLine();

      Console.Write("Ngay tham gia: ");
      DateTime joinDate = DateTime.Parse(Console.ReadLine());

      Console.WriteLine("Trinh do hoc van: ");
      Console.WriteLine("1. Cao Dang");
      Console.WriteLine("2. Dai Hoc");
      Console.WriteLine("3. Thac Si");
      Console.WriteLine("4. Tien Si");
      Console.Write("Chon 1 -> 4: ");
      int selectEducation = Convert.ToInt32(Console.ReadLine());
      HocVi hocVi = (HocVi)selectEducation;

      Console.WriteLine("Chuc Vu: ");
      Console.WriteLine("1. Nhan Vien");
      Console.WriteLine("2. Truong Phong");
      Console.WriteLine("3. Giam Doc");
      Console.Write("Chon 1 -> 3: ");
      int selectPosition = Convert.ToInt32(Console.ReadLine());
      ChucVu chucVu = (ChucVu)selectPosition;

      var model = new NhanVien(maNv, name, joinDate, hocVi, chucVu);
      return model;
    }

    static double setPhep(DateTime fromDate, DateTime toDate)
    {
      return (toDate - fromDate).Days;
    }

    static void TinhBhYT(int salary)
    {
      Console.WriteLine("BHYT: {0}", salary * (int)InsuranceType.HealthInsurance / 100);
    }

    static void TinhBHXH(int salary)
    {
      Console.WriteLine("BHXH: {0}", salary * (int)InsuranceType.SocialInsurance / 100);
    }

    static void TinhBHTN(int salary)
    {
      Console.WriteLine("BHTN: {0}", salary * (int)InsuranceType.UnemploymentInsurance / 100);
    }

    static void TinhThueTNCN(int salary)
    {
      Console.WriteLine("Thue TNCN: {0}", salary * 0.105);
    }

    static void TinhTienPhep(int totalDayoff, int salary)
    {
      Console.WriteLine("Tien nghi phep: {0}", totalDayoff * salary / workingDays);
    }

    static void TongThuNhap(int salary, double thamNien)
    {
      Console.WriteLine("Tong thu nhap: {0}", salary + salary * thamNien);
    }

    static void LuongThucNhan(int salary, double thamNien, int soNgayNghi, int bonus)
    {
      Console.WriteLine("Luong thuc nhan: {0}", salary + bonus + salary * thamNien - salary * 0.105 - salary * soNgayNghi / workingDays);
    }

    static void ThuongLe(int salary, DateTime joinDate) {

      double bonus = DateTime.Now.Year - joinDate.Year;

      if (bonus < 1) {
        bonus = 0.5;
      }

      Console.WriteLine("Tien thuong le: {0}", salary * bonus);
    }
  }

  public enum InsuranceType
  {
    HealthInsurance = 8,
    SocialInsurance = 2,
    UnemploymentInsurance = 1
  }
}
