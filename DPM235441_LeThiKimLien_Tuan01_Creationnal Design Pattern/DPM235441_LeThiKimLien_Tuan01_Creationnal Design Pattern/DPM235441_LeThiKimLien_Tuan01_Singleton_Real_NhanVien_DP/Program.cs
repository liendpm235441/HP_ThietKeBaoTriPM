using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton_Real_NhanVien
{
    // 1. CLASS NHÂN VIÊN (Đối tượng dữ liệu)
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

    // 2. SINGLETON CLASS: BỘ QUẢN LÝ NHÂN VIÊN TẬP TRUNG
    // Class phải là 'sealed' để ngăn kế thừa
    public sealed class QuanLyNhanVien
    {
        // Constructor là 'private' để không thể gọi 'new QuanLyNhanVien()' từ bên ngoài
        private QuanLyNhanVien()
        {
            _danhSachNhanVien = new List<NhanVien>();
        }

        // Lưu trữ thể hiện duy nhất (Instance) trong một static field
        private static QuanLyNhanVien _instance;

        // Danh sách lưu trữ thông tin nhân viên
        private List<NhanVien> _danhSachNhanVien;

        // Phương thức static kiểm soát việc truy cập vào thể hiện Singleton
        public static QuanLyNhanVien GetInstance()
        {
            if (_instance == null)
            {
                _instance = new QuanLyNhanVien();
            }
            return _instance;
        }

        // Các phương thức nghiệp vụ quản lý nhân viên
        public void ThemNhanVien(NhanVien nv)
        {
            _danhSachNhanVien.Add(nv);
            Console.WriteLine($"[Thông báo] Đã thêm thành công: {nv.TenNV}");
        }

        public void HienThiDanhSach()
        {
            Console.WriteLine("\n=== DANH SÁCH NHÂN VIÊN TRONG HỆ THỐNG ===");
            if (_danhSachNhanVien.Count == 0)
            {
                Console.WriteLine("Chưa có nhân viên nào.");
                return;
            }

            foreach (var nv in _danhSachNhanVien)
            {
                Console.WriteLine($"Mã NV: {nv.MaNV} | Tên: {nv.TenNV} | Chức vụ: {nv.ChucVu}");
            }
            Console.WriteLine("--------------------------------------------\n");
        }
    }

    // 3. PROGRAM & CLIENT CODE
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Khởi tạo 2 biến quản lý từ các nơi khác nhau trong ứng dụng
            QuanLyNhanVien q1 = QuanLyNhanVien.GetInstance();
            QuanLyNhanVien q2 = QuanLyNhanVien.GetInstance();

            // Kiểm tra xem q1 và q2 có trỏ cùng một vùng nhớ không
            Console.WriteLine("=== KIỂM TRA TÍNH DUY NHẤT CỦA SINGLETON ===");
            if (q1 == q2)
            {
                Console.WriteLine("=> Thành công: q1 và q2 là CÙNG MỘT thể hiện duy nhất trong hệ thống.");
            }
            else
            {
                Console.WriteLine("=> Thất bại: q1 và q2 là hai thể hiện khác nhau.");
            }

            Console.WriteLine("\n=== THỰC THI NGHIỆP VỤ QUẢN LÝ ===");
            // Dùng biến q1 để thêm nhân viên vào hệ thống
            q1.ThemNhanVien(new NhanVien("NV01", "Lê Thị Kim Liên", "Quản lý Nhân sự"));
            q1.ThemNhanVien(new NhanVien("NV02", "Nguyễn Văn A", "Lập trình viên"));

            // Dùng biến q2 để xem danh sách nhân viên
            // Dù dữ liệu được thêm qua q1, q2 vẫn đọc được đầy đủ vì cả hai dùng chung 1 Instance Singleton
            Console.WriteLine("\n-> Gọi hàm hiển thị từ biến q2:");
            q2.HienThiDanhSach();

            Console.ReadLine();
        }
    }
}