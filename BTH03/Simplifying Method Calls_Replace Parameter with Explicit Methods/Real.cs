using System;
using System.Windows.Forms;

namespace SimplifyingMethodCalls_ReplaceParameterwithExplicitMethods
{
    /// <summary>
    /// Real example: Apply Replace Parameter with Explicit Methods
    /// to code inspired by Cuahang_Nongduoc (frmBanLe / setting giá trị theo tên)
    /// 
    /// BEFORE: 1 method nhận parameter "name" rồi if-else gán giá trị
    /// AFTER : tách thành các method riêng rõ ràng (SetDonGia, SetSoLuong, ...)
    /// </summary>
    public class Real
    {
        // Simulated fields from frmBanLe
        private NumericUpDown numDonGia = new NumericUpDown();
        private NumericUpDown numSoLuong = new NumericUpDown();
        private NumericUpDown numThanhTien = new NumericUpDown();
        private NumericUpDown numTongTien = new NumericUpDown();

        // ========== BEFORE ==========
        /*
        void SetValue(string name, decimal value)
        {
            if (name.Equals("DonGia"))
            {
                numDonGia.Value = value;
                return;
            }
            if (name.Equals("SoLuong"))
            {
                numSoLuong.Value = value;
                return;
            }
            if (name.Equals("ThanhTien"))
            {
                numThanhTien.Value = value;
                return;
            }
            if (name.Equals("TongTien"))
            {
                numTongTien.Value = value;
                return;
            }
        }
        */

        // ========== AFTER (Replace Parameter with Explicit Methods) ==========
        void SetDonGia(decimal value)
        {
            numDonGia.Value = value;
        }

        void SetSoLuong(decimal value)
        {
            numSoLuong.Value = value;
        }

        void SetThanhTien(decimal value)
        {
            numThanhTien.Value = value;
        }

        void SetTongTien(decimal value)
        {
            numTongTien.Value = value;
        }
    }
}
