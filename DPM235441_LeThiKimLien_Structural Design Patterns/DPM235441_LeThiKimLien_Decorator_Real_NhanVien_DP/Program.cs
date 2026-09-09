// Real-world Decorator pattern: Employee salary benefits system
using DPM235441_LeThiKimLien_Decorator_Real_NhanVien_DP;

Console.WriteLine("=== Employee Salary Benefits System ===\n");

// Create basic employee
IEmployee employee1 = new BasicEmployee("Lê Thị Kim Liên", 25000);

// Add benefits step by step
employee1 = new HousingAllowanceDecorator(employee1);
employee1 = new MealAllowanceDecorator(employee1);
employee1 = new TransportAllowanceDecorator(employee1);
employee1 = new PerformanceBonusDecorator(employee1, 10);

Console.WriteLine(employee1.GetDetails());
Console.WriteLine($"\n=== Total Monthly Salary: ${employee1.GetSalary():F2} ===\n");

// Different employee with different benefits
IEmployee employee2 = new BasicEmployee("Nguyễn Văn A", 20000);
employee2 = new HousingAllowanceDecorator(employee2);
employee2 = new PerformanceBonusDecorator(employee2, 5);

Console.WriteLine(employee2.GetDetails());
Console.WriteLine($"\n=== Total Monthly Salary: ${employee2.GetSalary():F2} ===");
