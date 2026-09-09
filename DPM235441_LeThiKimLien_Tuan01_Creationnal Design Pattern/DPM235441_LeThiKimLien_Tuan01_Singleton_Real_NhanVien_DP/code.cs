using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton_Real_NhanVien
{
    // 1. CLASS NHÂN VIÊN (??i t??ng d? li?u)
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string ChucVu { get; set; }

        public NhanVien(string ma, string ten, string chucVu)
        {
            MaNV = ma;
            TenNV = ten;
            ChucVu = chucVu;
        }
    }

    // 2. SINGLETON CLASS: B? QU?N LÝ NHÂN VIÊN T?P TRUNG
    // Class ph?i là 'sealed' ?? ng?n k? th?a
    public sealed class QuanLyNhanVien
    {
        // Constructor là 'private' ?? không th? g?i 'new QuanLyNhanVien()' t? bên ngoài
        private QuanLyNhanVien()
        {
            _danhSachNhanVien = new List<NhanVien>();
        }

        // L?u tr? th? hi?n duy nh?t (Instance) trong m?t static field
        private static QuanLyNhanVien _instance;

        // Danh sách l?u tr? thông tin nhân viên
        private List<NhanVien> _danhSachNhanVien;

        // Ph??ng th?c static ki?m soát vi?c truy c?p vào th? hi?n Singleton
        public static QuanLyNhanVien GetInstance()
        {
            if (_instance == null)
            {
                _instance = new QuanLyNhanVien();
            }
            return _instance;
        }

        // Các ph??ng th?c nghi?p v? qu?n lý nhân viên
        public void ThemNhanVien(NhanVien nv)
        {
            _danhSachNhanVien.Add(nv);
            Console.WriteLine($"[Thông báo] ?ã thêm thành công: {nv.TenNV}");
        }

        public void HienThiDanhSach()
        {
            Console.WriteLine("\n=== DANH SÁCH NHÂN VIÊN TRONG H? TH?NG ===");
            if (_danhSachNhanVien.Count == 0)
            {
                Console.WriteLine("Ch?a có nhân viên nào.");
                return;
            }

            foreach (var nv in _danhSachNhanVien)
            {
                Console.WriteLine($"Mã NV: {nv.MaNV} | Tên: {nv.TenNV} | Ch?c v?: {nv.ChucVu}");
            }
            Console.WriteLine("--------------------------------------------\n");
        }
    }
}
