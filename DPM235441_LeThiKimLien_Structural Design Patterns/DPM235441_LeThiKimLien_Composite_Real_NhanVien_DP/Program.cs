// Real-world Composite pattern: Company organizational structure
using DPM235441_LeThiKimLien_Composite_Real_NhanVien_DP;

Console.WriteLine("=== Company Organizational Structure ===\n");

// Create company structure
var company = new Department("Tech Company");

// Create departments
var itDept = new Department("IT Department");
var hrDept = new Department("HR Department");

// Add employees to IT Department
itDept.Add(new Employee("Lê Thị Kim Liên", 25000));
itDept.Add(new Employee("Nguyễn Văn A", 22000));
itDept.Add(new Employee("Trần Thị B", 20000));

// Add employees to HR Department
hrDept.Add(new Employee("Phạm Thị C", 18000));
hrDept.Add(new Employee("Hoàng Văn D", 17000));

// Add departments to company
company.Add(itDept);
company.Add(hrDept);

// Display organization
Console.WriteLine(company.GetInfo());
Console.WriteLine($"Total Company Salary: ${company.GetTotalSalary():F2}");
