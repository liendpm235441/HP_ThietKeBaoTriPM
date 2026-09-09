using System;
using System.Text;

namespace Factory_Real_NhanVien
{
    // ==========================================
    // 1. PRODUCT INTERFACE (Giao diện sản phẩm)
    // ==========================================
    public interface INhanVien
    {
        string TinhLuong();
        string GetThongTin();
    }

    // ==========================================
    // 2. CONCRETE PRODUCTS (Sản phẩm cụ thể)
    // ==========================================
    class NhanVienChinhThuc : INhanVien
    {
        private string _ten = "Lê Thị Kim Liên";
        private double _luongCoBan = 15000000;

        public string TinhLuong()
        {
            return $"{_luongCoBan:N0} VNĐ";
        }

        public string GetThongTin()
        {
            return $"[Chính thức] - Tên: {_ten} | Lương: {TinhLuong()}";
        }
    }

    class NhanVienThoiVu : INhanVien
    {
        private string _ten = "Nguyễn Văn A";
        private int _soGio = 120;
        private double _luongTheoGio = 50000;

        public string TinhLuong()
        {
            return $"{(_soGio * _luongTheoGio):N0} VNĐ";
        }

        public string GetThongTin()
        {
            return $"[Thời vụ]    - Tên: {_ten} | Lương: {TinhLuong()}";
        }
    }

    // ==========================================
    // 3. CREATOR (Lớp khởi tạo trừu tượng)
    // ==========================================
    abstract class NhanVienCreator
    {
        // Factory Method bắt buộc các lớp con ghi đè
        public abstract INhanVien FactoryMethod();

        // Nghiệp vụ chính xử lý thông tin nhân viên thông qua Factory Method
        public string InBangLuong()
        {
            var nhanVien = FactoryMethod();
            var result = "Bộ phận Nhân sự xử lý thành công: " + nhanVien.GetThongTin();
            return result;
        }
    }

    // ==========================================
    // 4. CONCRETE CREATORS (Lớp khởi tạo cụ thể)
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
    // 5. CLIENT CODE (Chương trình sử dụng)
    // ==========================================
    class Client
    {
        public void Main()
        {
            Console.WriteLine("--- QUY TRÌNH 1: NHÂN VIÊN CHÍNH THỨC ---");
            ClientCode(new NhanVienChinhThucCreator());

            Console.WriteLine("\n--- QUY TRÌNH 2: NHÂN VIÊN THỜI VỤ ---");
            ClientCode(new NhanVienThoiVuCreator());
        }

        public void ClientCode(NhanVienCreator creator)
        {
            Console.WriteLine("Client: Gọi quy trình tính lương (không phụ thuộc lớp nhân viên cụ thể):\n"
                + creator.InBangLuong());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            new Client().Main();
            Console.ReadLine();
        }
    }
}