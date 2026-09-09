using System;
using System.Text;

namespace Factory_Real_NhanVien
{
    // ==========================================
    // 1. PRODUCT INTERFACE (Giao di?n s?n ph?m)
    // ==========================================
    public interface INhanVien
    {
        string TinhLuong();
        string GetThongTin();
    }

    // ==========================================
    // 2. CONCRETE PRODUCTS (S?n ph?m c? th?)
    // ==========================================
    class NhanVienChinhThuc : INhanVien
    {
        private string _ten = "Lê Th? Kim Liên";
        private double _luongCoBan = 15000000;

        public string TinhLuong()
        {
            return $"{_luongCoBan:N0} VN?";
        }

        public string GetThongTin()
        {
            return $"[Chính th?c] - Tên: {_ten} | L??ng: {TinhLuong()}";
        }
    }

    class NhanVienThoiVu : INhanVien
    {
        private string _ten = "Nguy?n V?n A";
        private int _soGio = 120;
        private double _luongTheoGio = 50000;

        public string TinhLuong()
        {
            return $"{(_soGio * _luongTheoGio):N0} VN?";
        }

        public string GetThongTin()
        {
            return $"[Th?i v?]    - Tên: {_ten} | L??ng: {TinhLuong()}";
        }
    }

    // ==========================================
    // 3. CREATOR (L?p kh?i t?o tr?u t??ng)
    // ==========================================
    abstract class NhanVienCreator
    {
        // Factory Method b?t bu?c các l?p con ghi ?è
        public abstract INhanVien FactoryMethod();

        // Nghi?p v? chính x? lý thông tin nhân viên thông qua Factory Method
        public string InBangLuong()
        {
            var nhanVien = FactoryMethod();
            var result = "B? ph?n Nhân s? x? lý thành công: " + nhanVien.GetThongTin();
            return result;
        }
    }

    // ==========================================
    // 4. CONCRETE CREATORS (L?p kh?i t?o c? th?)
    // ==========================================
    class NhanVienChinhThucCreator : NhanVienCreator
    {
        public override INhanVien FactoryMethod()
        {
            return new NhanVienChinhThuc();
        }
    }

    class NhanVienThoiVuCreator : NhanVienCreator
    {
        public override INhanVien FactoryMethod()
        {
            return new NhanVienThoiVu();
        }
    }

    // ==========================================
    // 5. CLIENT CODE (Ch??ng trình s? d?ng)
    // ==========================================
    class Client
    {
        public void Main()
        {
            Console.WriteLine("--- QUY TRÌNH 1: NHÂN VIÊN CHÍNH TH?C ---");
            ClientCode(new NhanVienChinhThucCreator());

            Console.WriteLine("\n--- QUY TRÌNH 2: NHÂN VIÊN TH?I V? ---");
            ClientCode(new NhanVienThoiVuCreator());
        }

        public void ClientCode(NhanVienCreator creator)
        {
            Console.WriteLine("Client: G?i quy trình tính l??ng (không ph? thu?c l?p nhân viên c? th?):\n"
                + creator.InBangLuong());
        }
    }
}
