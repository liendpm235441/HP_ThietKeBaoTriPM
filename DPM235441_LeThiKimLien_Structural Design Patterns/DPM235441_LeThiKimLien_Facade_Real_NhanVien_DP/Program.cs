// Real-world Facade pattern: HR Management System
using DPM235441_LeThiKimLien_Facade_Real_NhanVien_DP;

Console.WriteLine("=== HR Management System (Facade Pattern) ===\n");

var hrSystem = new HRManagementFacade();

// Hire a new employee - one simple call instead of many
hrSystem.HireNewEmployee("EMP001", "Lê Thị Kim Liên", "Software Developer", 25000);

// Process monthly payroll - one simple call
hrSystem.ProcessMonthlyPayroll("EMP001", 25000);

// Update benefits - one simple call
hrSystem.UpdateEmployeeBenefits("EMP001");

Console.WriteLine("All HR operations completed successfully!");
