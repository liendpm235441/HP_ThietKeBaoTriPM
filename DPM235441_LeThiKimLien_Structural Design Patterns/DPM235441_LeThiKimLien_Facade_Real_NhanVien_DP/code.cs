using System;

namespace DPM235441_LeThiKimLien_Facade_Real_NhanVien_DP
{
    // Real-world example: HR Management System using Facade pattern
    // Simplifies complex HR operations

    // Subsystem 1: Employee database
    public class EmployeeDatabase
    {
        public string RegisterEmployee(string name, string position, decimal salary)
        {
            return $"[DB] Employee '{name}' registered as {position}";
        }

        public string GetEmployeeInfo(string employeeId)
        {
            return $"[DB] Retrieved employee info for ID: {employeeId}";
        }
    }

    // Subsystem 2: Payroll system
    public class PayrollSystem
    {
        public string CalculateSalary(string employeeId, decimal baseSalary)
        {
            decimal tax = baseSalary * 0.1m;
            decimal netSalary = baseSalary - tax;
            return $"[Payroll] Calculated salary for {employeeId}: Base ${baseSalary:F2}, Tax ${tax:F2}, Net ${netSalary:F2}";
        }

        public string ProcessPayment(string employeeId)
        {
            return $"[Payroll] Payment processed for employee {employeeId}";
        }
    }

    // Subsystem 3: Benefits system
    public class BenefitsSystem
    {
        public string EnrollInHealthInsurance(string employeeId)
        {
            return $"[Benefits] Employee {employeeId} enrolled in health insurance";
        }

        public string RegisterPension(string employeeId)
        {
            return $"[Benefits] Employee {employeeId} registered in pension plan";
        }
    }

    // Subsystem 4: Training system
    public class TrainingSystem
    {
        public string AssignOrientation(string employeeId)
        {
            return $"[Training] Orientation assigned to employee {employeeId}";
        }

        public string CreateTrainingPlan(string employeeId)
        {
            return $"[Training] Training plan created for employee {employeeId}";
        }
    }

    // Facade: Simplifies complex HR operations
    public class HRManagementFacade
    {
        private EmployeeDatabase _employeeDb;
        private PayrollSystem _payrollSystem;
        private BenefitsSystem _benefitsSystem;
        private TrainingSystem _trainingSystem;

        public HRManagementFacade()
        {
            _employeeDb = new EmployeeDatabase();
            _payrollSystem = new PayrollSystem();
            _benefitsSystem = new BenefitsSystem();
            _trainingSystem = new TrainingSystem();
        }

        // Unified operation: Hire new employee
        public void HireNewEmployee(string employeeId, string name, string position, decimal salary)
        {
            Console.WriteLine($"=== Hiring Process for {name} ===");
            Console.WriteLine(_employeeDb.RegisterEmployee(name, position, salary));
            Console.WriteLine(_payrollSystem.CalculateSalary(employeeId, salary));
            Console.WriteLine(_benefitsSystem.EnrollInHealthInsurance(employeeId));
            Console.WriteLine(_benefitsSystem.RegisterPension(employeeId));
            Console.WriteLine(_trainingSystem.AssignOrientation(employeeId));
            Console.WriteLine(_trainingSystem.CreateTrainingPlan(employeeId));
            Console.WriteLine();
        }

        // Unified operation: Process monthly payroll
        public void ProcessMonthlyPayroll(string employeeId, decimal salary)
        {
            Console.WriteLine($"=== Monthly Payroll Processing ===");
            Console.WriteLine(_payrollSystem.CalculateSalary(employeeId, salary));
            Console.WriteLine(_payrollSystem.ProcessPayment(employeeId));
            Console.WriteLine();
        }

        // Unified operation: Update employee benefits
        public void UpdateEmployeeBenefits(string employeeId)
        {
            Console.WriteLine($"=== Benefits Update ===");
            Console.WriteLine(_benefitsSystem.EnrollInHealthInsurance(employeeId));
            Console.WriteLine(_benefitsSystem.RegisterPension(employeeId));
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== HR Management System (Facade Pattern) ===\n");

            var hrSystem = new HRManagementFacade();

            // Hire a new employee - one simple call instead of many
            hrSystem.HireNewEmployee("EMP001", "Lê Th? Kim Liên", "Software Developer", 25000);

            // Process monthly payroll - one simple call
            hrSystem.ProcessMonthlyPayroll("EMP001", 25000);

            // Update benefits - one simple call
            hrSystem.UpdateEmployeeBenefits("EMP001");

            Console.WriteLine("All HR operations completed successfully!");
        }
    }
}
// Output: Demonstrates how Facade pattern simplifies complex HR management operations
