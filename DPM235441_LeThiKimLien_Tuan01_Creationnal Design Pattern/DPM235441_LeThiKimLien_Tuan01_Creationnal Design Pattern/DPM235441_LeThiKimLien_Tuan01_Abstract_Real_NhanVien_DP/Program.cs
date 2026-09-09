// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Text;

namespace AbstractFactory_Real_NhanVien
{
    // ==========================================
    // 1. ABSTRACT PRODUCTS (Giao diện sản phẩm)
    // ==========================================

    // Sản phẩm A: Giao diện Nhân viên
    public interface INhanVien
    {
        string GetThongTin();
    }

    // Sản phẩm B: Giao diện Hợp đồng
    public interface IHopDong
    {
        string GetChiTietHopDong();
        // Hợp đồng liên kết với thông tin Nhân viên (tương tự UsefulFunctionB hợp tác với ProductA)
        void InHopDong(INhanVien nhanVien);
    }

    // ==========================================
    // 2. CONCRETE PRODUCTS (Sản phẩm cụ thể)
    // ==========================================

    // Variant 1: Nhân viên chính thức
    public class NhanVienChinhThuc : INhanVien
    {
        public string Ten { get; set; } = "Lê Thị Kim Liên";
        public string GetThongTin() => $"[Nhân viên chính thức] - Tên: {Ten}";
    }

    // Variant 1: Hợp đồng dài hạn (đi kèm Nhân viên chính thức)
    public class HopDongDaiHan : IHopDong
    {
        public string GetChiTietHopDong() => "Hợp đồng lao động thời hạn 3 năm (Có đóng BHXH)";

        public void InHopDong(INhanVien nhanVien)
        {
            Console.WriteLine($"-> Ký {GetChiTietHopDong()} cho {nhanVien.GetThongTin()}");
        }
    }

    // Variant 2: Nhân viên thời vụ
    public class NhanVienThoiVu : INhanVien
    {
        public string Ten { get; set; } = "Nguyễn Văn A";
        public string GetThongTin() => $"[Nhân viên thời vụ] - Tên: {Ten}";
    }

    // Variant 2: Hợp đồng ngắn hạn (đi kèm Nhân viên thời vụ)
    public class HopDongNganHan : IHopDong
    {
        public string GetChiTietHopDong() => "Hợp đồng thử việc / khoán việc 3 tháng";

        public void InHopDong(INhanVien nhanVien)
        {
            Console.WriteLine($"-> Ký {GetChiTietHopDong()} cho {nhanVien.GetThongTin()}");
        }
    }

    // ==========================================
    // 3. ABSTRACT FACTORY (Giao diện Nhà máy)
    // ==========================================
    public interface INhanVienFactory
    {
        INhanVien CreateNhanVien();
        IHopDong CreateHopDong();
    }

    // ==========================================
    // 4. CONCRETE FACTORIES (Nhà máy cụ thể)
    // ==========================================

    // Factory 1: Quản lý khởi tạo bộ hồ sơ Chính thức
    public class NhanVienChinhThucFactory : INhanVienFactory
    {
        public INhanVien CreateNhanVien() => new NhanVienChinhThuc();
        public IHopDong CreateHopDong() => new HopDongDaiHan();
    }

    // Factory 2: Quản lý khởi tạo bộ hồ sơ Thời vụ
    public class NhanVienThoiVuFactory : INhanVienFactory
    {
        public INhanVien CreateNhanVien() => new NhanVienThoiVu();
        public IHopDong CreateHopDong() => new HopDongNganHan();
    }

    // ==========================================
    // 5. CLIENT CODE (Chương trình sử dụng)
    // ==========================================
    class Client
    {
        public void LapHoSoNhanSu(INhanVienFactory factory)
        {
            INhanVien nv = factory.CreateNhanVien();
            IHopDong hd = factory.CreateHopDong();

            hd.InHopDong(nv);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Client client = new Client();

            Console.WriteLine("=== BỘ HỒ SƠ 1 ===");
            client.LapHoSoNhanSu(new NhanVienChinhThucFactory());

            Console.WriteLine("\n=== BỘ HỒ SƠ 2 ===");
            client.LapHoSoNhanSu(new NhanVienThoiVuFactory());

            Console.ReadLine();
        }
    }
}