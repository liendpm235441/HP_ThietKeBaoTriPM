using System;
using System.Text;

namespace Builder_Real_NhanVien
{
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