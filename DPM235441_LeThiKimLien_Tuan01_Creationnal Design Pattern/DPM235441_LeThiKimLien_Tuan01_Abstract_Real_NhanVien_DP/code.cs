using System;
using System.Text;

namespace Abstract_Real_NhanVien
{
    // ==========================================
    // 1. PRODUCT INTERFACES (Giao di?n s?n ph?m)
    // ==========================================
    public interface IPhucLoi
    {
        string GetThongTin();
    }

    public interface INguonNhanSu
    {
        IPhucLoi CreatePhucLoi();
    }

    // ==========================================
    // 2. CONCRETE PRODUCTS (S?n ph?m c? th?)
    // ==========================================
    class PhucLoiChinhThuc : IPhucLoi
    {
        public string GetThongTin()
        {
            return "B?o hi?m xã h?i + B?o hi?m y t? + Ph? c?p + Th??ng n?m";
        }
    }

    class PhucLoiThoiVu : IPhucLoi
    {
        public string GetThongTin()
        {
            return "Không b?o hi?m, L??ng theo gi?";
        }
    }

    // ==========================================
    // 3. CONCRETE FACTORIES (Nhà máy t?o ra s?n ph?m)
    // ==========================================
    class NguonNhanSuChinhThuc : INguonNhanSu
    {
        public IPhucLoi CreatePhucLoi()
        {
            return new PhucLoiChinhThuc();
        }
    }

    class NguonNhanSuThoiVu : INguonNhanSu
    {
        public IPhucLoi CreatePhucLoi()
        {
            return new PhucLoiThoiVu();
        }
    }

    // ==========================================
    // 4. CLIENT CODE (Ch??ng trình s? d?ng)
    // ==========================================
    class Client
    {
        public void Main()
        {
            Console.WriteLine("--- X? LÝ PHÚC L?I NHÂN VIÊN CHÍNH TH?C ---");
            ClientMethod(new NguonNhanSuChinhThuc());
            Console.WriteLine();

            Console.WriteLine("--- X? LÝ PHÚC L?I NHÂN VIÊN TH?I V? ---");
            ClientMethod(new NguonNhanSuThoiVu());
        }

        public void ClientMethod(INguonNhanSu factory)
        {
            var phucLoi = factory.CreatePhucLoi();
            Console.WriteLine($"Ch? ?? phúc l?i: {phucLoi.GetThongTin()}");
        }
    }
}
