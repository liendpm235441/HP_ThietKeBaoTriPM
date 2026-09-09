using System;

namespace DPM235441_LeThiKimLien_Adapter_Real_NhanVien_DP
{
    // Real-world example: Converting Legacy Employee System to New System

    // New system interface
    public interface IEmployeeData
    {
        string GetFullName();
        string GetDepartment();
        decimal GetSalary();
    }

    // Legacy employee system with incompatible interface
    public class LegacyEmployee
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dept { get; set; }
        public decimal BaseSalary { get; set; }

        public LegacyEmployee(string id, string fname, string lname, string dept, decimal salary)
        {
            EmployeeId = id;
            FirstName = fname;
            LastName = lname;
            Dept = dept;
            BaseSalary = salary;
        }

        public string GetLegacyInfo()
        {
            return $"ID: {EmployeeId} | {FirstName} {LastName} | {Dept}";
        }
    }

    // Adapter to make LegacyEmployee compatible with new system
    public class EmployeeAdapter : IEmployeeData
    {
        private readonly LegacyEmployee _legacyEmployee;

        public EmployeeAdapter(LegacyEmployee legacyEmployee)
        {
            this._legacyEmployee = legacyEmployee;
        }

        public string GetFullName()
        {
            return $"{_legacyEmployee.FirstName} {_legacyEmployee.LastName}";
        }

        public string GetDepartment()
        {
            return _legacyEmployee.Dept;
        }

        public decimal GetSalary()
        {
            return _legacyEmployee.BaseSalary;
        }
    }

    // New modern employee system
    public class ModernEmployeeSystem
    {
        public void ProcessEmployee(IEmployeeData employee)
        {
            Console.WriteLine("=== Modern Employee Processing System ===");
            Console.WriteLine($"Name: {employee.GetFullName()}");
            Console.WriteLine($"Department: {employee.GetDepartment()}");
            Console.WriteLine($"Salary: ${employee.GetSalary():F2}");
            Console.WriteLine($"Bonus (10%): ${employee.GetSalary() * 0.1:F2}");
            Console.WriteLine($"Total: ${employee.GetSalary() * 1.1:F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create legacy employee from old system
            var legacyEmployee = new LegacyEmployee("EMP001", "Lê", "Th? Kim Liên", "IT", 25000);

            Console.WriteLine("Legacy System Data:");
            Console.WriteLine(legacyEmployee.GetLegacyInfo());
            Console.WriteLine();

            // Adapt legacy employee to new system
            IEmployeeData adaptedEmployee = new EmployeeAdapter(legacyEmployee);

            // Process with modern system
            var modernSystem = new ModernEmployeeSystem();
            modernSystem.ProcessEmployee(adaptedEmployee);
        }
    }
}
// Output: Demonstrates how Adapter pattern converts legacy employee data to new system format
