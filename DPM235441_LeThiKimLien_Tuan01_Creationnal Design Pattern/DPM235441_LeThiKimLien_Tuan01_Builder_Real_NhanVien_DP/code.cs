using System;
using System.Text;

namespace Builder_Real_NhanVien
{
    // ==========================================
    // 1. PRODUCT (??i t??ng ph?c t?p c?n t?o)
    // ==========================================
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public double LuongCoBan { get; set; }
        public double PhuCap { get; set; }
        public bool CoBaoHiem { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }

        public void HienThiThongTin()
        {
            Console.WriteLine($"=== H? S? NHÂN VIÊN: {MaNV} - {TenNV} ===");
            Console.WriteLine($"* L??ng c? b?n : {LuongCoBan:N0} VN?");
            Console.WriteLine($"* Ph? c?p      : {PhuCap:N0} VN?");
            Console.WriteLine($"* B?o hi?m     : {(CoBaoHiem ? "Có BHXH/BHYT" : "Không")}");
            Console.WriteLine($"* Email        : {Email ?? "Ch?a c?p nh?t"}");
            Console.WriteLine($"* S?T          : {SoDienThoai ?? "Ch?a c?p nh?t"}");
            Console.WriteLine("---------------------------------------------\n");
        }
    }

    // ==========================================
    // 2. BUILDER INTERFACE (Khai báo các b??c d?ng)
    // ==========================================
    public interface INhanVienBuilder
    {
        void Reset();
        void BuildThongTinCoBan(string ma, string ten);
        void BuildThuNhap(double luongCoBan, double phuCap);
        void BuildPhucLoi(bool coBaoHiem);
        void BuildLienHe(string email, string sdt);
        NhanVien GetNhanVien();
    }

    // ==========================================
    // 3. CONCRETE BUILDER (L?p th?c thi các b??c)
    // ==========================================
    public class NhanVienBuilder : INhanVienBuilder
    {
        private NhanVien _nhanVien;

        public NhanVienBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._nhanVien = new NhanVien();
        }

        public void BuildThongTinCoBan(string ma, string ten)
        {
            this._nhanVien.MaNV = ma;
            this._nhanVien.TenNV = ten;
        }

        public void BuildThuNhap(double luongCoBan, double phuCap)
        {
            this._nhanVien.LuongCoBan = luongCoBan;
            this._nhanVien.PhuCap = phuCap;
        }

        public void BuildPhucLoi(bool coBaoHiem)
        {
            this._nhanVien.CoBaoHiem = coBaoHiem;
        }

        public void BuildLienHe(string email, string sdt)
        {
            this._nhanVien.Email = email;
            this._nhanVien.SoDienThoai = sdt;
        }

        public NhanVien GetNhanVien()
        {
            NhanVien result = this._nhanVien;
            this.Reset(); // Tái t?o l?i ??i t??ng tr?ng m?i cho l?n d?ng sau
            return result;
        }
    }

    // ==========================================
    // 4. DIRECTOR (L?p ?i?u ph?i quy trình d?ng)
    // ==========================================
    public class NhanVienDirector
    {
        private INhanVienBuilder _builder;

        public void SetBuilder(INhanVienBuilder builder)
        {
            this._builder = builder;
        }

        // D?ng c?u hình cho Nhân viên Chính th?c (??y ?? thông tin, b?o hi?m, ph? c?p)
        public void BuildNhanVienChinhThuc(string ma, string ten, string email, string sdt)
        {
            this._builder.BuildThongTinCoBan(ma, ten);
            this._builder.BuildThuNhap(15000000, 3000000);
            this._builder.BuildPhucLoi(true);
            this._builder.BuildLienHe(email, sdt);
        }

        // D?ng c?u hình cho Nhân viên Th?i v? (Ch? có l??ng c? b?n, không b?o hi?m)
        public void BuildNhanVienThoiVu(string ma, string ten)
        {
            this._builder.BuildThongTinCoBan(ma, ten);
            this._builder.BuildThuNhap(5000000, 0);
            this._builder.BuildPhucLoi(false);
        }
    }
}
