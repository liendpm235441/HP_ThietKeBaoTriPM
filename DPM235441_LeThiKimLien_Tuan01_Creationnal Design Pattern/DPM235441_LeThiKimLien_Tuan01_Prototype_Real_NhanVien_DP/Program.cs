using System;
using System.Text;

namespace Prototype_Real_NhanVien
{
    // 1. REFERENCE TYPE CLASS (Đối tượng tham chiếu: Phòng ban)
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

    // 2. PROTOTYPE CLASS (Đối tượng Nhân viên hỗ trợ nhân bản)
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public int Tuoi { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public PhongBan ThongTinPhong { get; set; } // Reference Type

        // Sao chép nông (Shallow Copy): Sao chép giá trị biến cơ bản, nhưng dùng chung con trỏ PhongBan
        public NhanVien ShallowCopy()
        {
            return (NhanVien)this.MemberwiseClone();
        }

        // Sao chép sâu (Deep Copy): Tách biệt hoàn toàn, tạo mới đối tượng PhongBan độc lập
        public NhanVien DeepCopy()
        {
            NhanVien clone = (NhanVien)this.MemberwiseClone();
            clone.ThongTinPhong = new PhongBan(this.ThongTinPhong.MaPhong, this.ThongTinPhong.TenPhong);
            return clone;
        }
    }

    // 3. PROGRAM & CLIENT CODE
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Khởi tạo nhân viên gốc
            NhanVien nv1 = new NhanVien
            {
                MaNV = "NV01",
                TenNV = "Lê Thị Kim Liên",
                Tuoi = 22,
                NgayVaoLam = Convert.ToDateTime("2024-01-15"),
                ThongTinPhong = new PhongBan("PB01", "Phòng Nhân Sự")
            };

            // Thực hiện nhân bản
            NhanVien nv2 = nv1.ShallowCopy(); // Bản sao nông
            NhanVien nv3 = nv1.DeepCopy();    // Bản sao sâu

            Console.WriteLine("=== GIÁ TRỊ BAN ĐẦU CỦA NV1, NV2 (SHALLOW), NV3 (DEEP) ===");
            Console.WriteLine("-> [NV1 Gốc]:");
            HienThiThongTin(nv1);
            Console.WriteLine("-> [NV2 - Sao chép nông]:");
            HienThiThongTin(nv2);
            Console.WriteLine("-> [NV3 - Sao chép sâu]:");
            HienThiThongTin(nv3);

            // Tiến hành sửa dữ liệu ở nhân viên gốc NV1
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("--- THAY ĐỔI DỮ LIỆU CỦA NHÂN VIÊN GỐC (NV1) ---");
            Console.WriteLine("-------------------------------------------------------");
            nv1.TenNV = "Lê Thị Kim Liên (Đã sửa tên)";
            nv1.Tuoi = 25;
            nv1.ThongTinPhong.TenPhong = "Phòng IT (Đã đổi phòng)"; // Sửa đối tượng tham chiếu

            // Hiển thị lại để kiểm tra tính độc lập dữ liệu
            Console.WriteLine("\n=== GIÁ TRỊ SAU KHI NV1 BỊ THAY ĐỔI ===");
            Console.WriteLine("-> [NV1 Gốc - Đã sửa]:");
            HienThiThongTin(nv1);

            Console.WriteLine("-> [NV2 - Shallow Copy] (Bị ảnh hưởng Tên Phòng do dùng chung tham chiếu):");
            HienThiThongTin(nv2);

            Console.WriteLine("-> [NV3 - Deep Copy] (HOÀN TOÀN ĐỘC LẬP - Không bị ảnh hưởng):");
            HienThiThongTin(nv3);

            Console.ReadLine();
        }

        public static void HienThiThongTin(NhanVien nv)
        {
            Console.WriteLine($"   Mã NV: {nv.MaNV} | Tên: {nv.TenNV} | Tuổi: {nv.Tuoi} | Ngày vào làm: {nv.NgayVaoLam:dd/MM/yyyy}");
            Console.WriteLine($"   Mã phòng: {nv.ThongTinPhong.MaPhong} | Tên phòng: {nv.ThongTinPhong.TenPhong}\n");
        }
    }
}