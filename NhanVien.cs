using System;

namespace Ca1T3_NguyenHoang_17DH110963_Buoi4
{
  public class NhanVien
  {
    public string MaNV { get; set; }
    public string HoTen { get; set; }
    public DateTime NgayThamgia { get; set; }
    public HocVi HocVi { get; set; }
    public ChucVu ChucVu { get; set; }
    public double ThamNien { get; private set; }
    public NhanVien() { }
    public NhanVien(string maNv, string name, DateTime joinDate, HocVi hocVi, ChucVu chucVu)
    {
      this.MaNV = maNv;
      this.HoTen = name;
      this.NgayThamgia = joinDate;
      this.HocVi = hocVi;
      this.ChucVu = chucVu;
      this.ThamNien = (DateTime.Now.Year - joinDate.Year <= 7) ? (DateTime.Now.Year - joinDate.Year <= 5) ? 0.05 : 0.07 : 0.1;
    }
  }

  public class Salary
  {
    public string StaffId { get; set; }
    public int Bonus { get; private set; }
    public int BasicSalary { get; set; }

    public Salary(string staffId, int bonus, int basicSalary)
    {
      this.StaffId = staffId;
      this.Bonus = bonus;
      this.BasicSalary = basicSalary;
    }
  }

  public enum HocVi
  {
    CaoDang = 5000000,
    DaiHoc = 8000000,
    ThacSi = 11000000,
    TienSi = 13000000
  }

  public enum ChucVu
  {
    NhanVien = 1,
    TruongPhong = 2,
    GiamDoc = 3
  }
}