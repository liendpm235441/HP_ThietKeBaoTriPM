// Real-world Adapter pattern: Converting legacy employee system to modern system
using DPM235441_LeThiKimLien_Adapter_Real_NhanVien_DP;

// Create legacy employee from old system
var legacyEmployee = new LegacyEmployee("EMP001", "Lê", "Thị Kim Liên", "IT", 25000);

Console.WriteLine("Legacy System Data:");
Console.WriteLine(legacyEmployee.GetLegacyInfo());
Console.WriteLine();

// Adapt legacy employee to new system
IEmployeeData adaptedEmployee = new EmployeeAdapter(legacyEmployee);

// Process with modern system
var modernSystem = new ModernEmployeeSystem();
modernSystem.ProcessEmployee(adaptedEmployee);
