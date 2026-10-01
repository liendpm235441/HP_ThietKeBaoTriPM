using System;
using System.Text;

namespace Factory_Real_NhanVien
{
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