using System;
using System.Text;

namespace Builder_Real_NhanVien
{
    // ==========================================
    // 1. PRODUCT (Đối tượng phức tạp cần tạo)
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
            Console.WriteLine($"=== HỒ SƠ NHÂN VIÊN: {MaNV} - {TenNV} ===");
            Console.WriteLine($"* Lương cơ bản : {LuongCoBan:N0} VNĐ");
            Console.WriteLine($"* Phụ cấp      : {PhuCap:N0} VNĐ");
            Console.WriteLine($"* Bảo hiểm     : {(CoBaoHiem ? "Có BHXH/BHYT" : "Không")}");
            Console.WriteLine($"* Email        : {Email ?? "Chưa cập nhật"}");
            Console.WriteLine($"* SĐT          : {SoDienThoai ?? "Chưa cập nhật"}");
            Console.WriteLine("---------------------------------------------\n");
        }
    }

    // ==========================================
    // 2. BUILDER INTERFACE (Khai báo các bước dựng)
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
    // 3. CONCRETE BUILDER (Lớp thực thi các bước)
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
            this.Reset(); // Tái tạo lại đối tượng trống mới cho lần dựng sau
            return result;
        }
    }

    // ==========================================
    // 4. DIRECTOR (Lớp điều phối quy trình dựng)
    // ==========================================
    public class NhanVienDirector
    {
        private INhanVienBuilder _builder;

        public void SetBuilder(INhanVienBuilder builder)
        {
            this._builder = builder;
        }

        // Dựng cấu hình cho Nhân viên Chính thức (Đầy đủ thông tin, bảo hiểm, phụ cấp)
        public void BuildNhanVienChinhThuc(string ma, string ten, string email, string sdt)
        {
            this._builder.BuildThongTinCoBan(ma, ten);
            this._builder.BuildThuNhap(15000000, 3000000);
            this._builder.BuildPhucLoi(true);
            this._builder.BuildLienHe(email, sdt);
        }

        // Dựng cấu hình cho Nhân viên Thời vụ (Chỉ có lương cơ bản, không bảo hiểm)
        public void BuildNhanVienThoiVu(string ma, string ten)
        {
            this._builder.BuildThongTinCoBan(ma, ten);
            this._builder.BuildThuNhap(5000000, 0);
            this._builder.BuildPhucLoi(false);
        }
    }

    // ==========================================
    // 5. CLIENT CODE (Chương trình chạy)
    // ==========================================
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var director = new NhanVienDirector();
            var builder = new NhanVienBuilder();
            director.SetBuilder(builder);

            // 1. Dùng Director để tạo quy trình chuẩn: Nhân viên Chính thức
            Console.WriteLine("--- 1. TẠO HỒ SƠ CHÍNH THỨC (QUA DIRECTOR) ---");
            director.BuildNhanVienChinhThuc("NV01", "Lê Thị Kim Liên", "lienlkt@school.edu.vn", "0901234567");
            NhanVien nvChinhThuc = builder.GetNhanVien();
            nvChinhThuc.HienThiThongTin();

            // 2. Dùng Director để tạo quy trình chuẩn: Nhân viên Thời vụ
            Console.WriteLine("--- 2. TẠO HỒ SƠ THỜI VỤ (QUA DIRECTOR) ---");
            director.BuildNhanVienThoiVu("NV02", "Nguyễn Văn A");
            NhanVien nvThoiVu = builder.GetNhanVien();
            nvThoiVu.HienThiThongTin();

            // 3. Tự lắp ráp thủ công (Tùy biến các bước theo nhu cầu mà không cần Director)
            Console.WriteLine("--- 3. TỰ LẮP RÁP HỒ SƠ TÙY CHỈNH (KHÔNG QUA DIRECTOR) ---");
            builder.BuildThongTinCoBan("NV03", "Trần Thị B");
            builder.BuildThuNhap(10000000, 1000000);
            builder.BuildLienHe("tranb@gmail.com", "0987654321");
            NhanVien nvTuyChinh = builder.GetNhanVien();
            nvTuyChinh.HienThiThongTin();

            Console.ReadLine();
        }
    }
}