using System;
using System.Text;

namespace Prototype_Real_NhanVien
{
    // 1. REFERENCE TYPE CLASS (??i t??ng tham chi?u: Phòng ban)
    public class PhongBan
    {
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }

        public PhongBan(string maPhong, string tenPhong)
        {
            MaPhong = maPhong;
            TenPhong = tenPhong;
        }
    }

    // 2. PROTOTYPE CLASS (??i t??ng Nhân viên h? tr? nhân b?n)
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public int Tuoi { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public PhongBan ThongTinPhong { get; set; } // Reference Type

        // Sao chép nông (Shallow Copy): Sao chép giá tr? bi?n c? b?n, nh?ng dùng chung con tr? PhongBan
        public NhanVien ShallowCopy()
        {
            return (NhanVien)this.MemberwiseClone();
        }

        // Sao chép sâu (Deep Copy): Tách bi?t hoàn toàn, t?o m?i ??i t??ng PhongBan ??c l?p
        public NhanVien DeepCopy()
        {
            NhanVien clone = (NhanVien)this.MemberwiseClone();
            clone.ThongTinPhong = new PhongBan(this.ThongTinPhong.MaPhong, this.ThongTinPhong.TenPhong);
            return clone;
        }
    }

    // 3. HELPER CLASS FOR DISPLAY
    public class DisplayHelper
    {
        public static void HienThiThongTin(NhanVien nv)
        {
            Console.WriteLine($"   Mã NV: {nv.MaNV} | Tên: {nv.TenNV} | Tu?i: {nv.Tuoi} | Ngày vào làm: {nv.NgayVaoLam:dd/MM/yyyy}");
            Console.WriteLine($"   Mã phòng: {nv.ThongTinPhong.MaPhong} | Tên phòng: {nv.ThongTinPhong.TenPhong}\n");
        }
    }
}
