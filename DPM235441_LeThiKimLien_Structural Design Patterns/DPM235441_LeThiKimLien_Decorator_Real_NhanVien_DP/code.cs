using System;

namespace DPM235441_LeThiKimLien_Decorator_Real_NhanVien_DP
{
    // Real-world example: Employee salary benefits system using Decorator pattern
    // Adds various allowances (housing, meal, etc.) to base salary

    public interface IEmployee
    {
        string GetName();
        decimal GetSalary();
        string GetDetails();
    }

    // Base employee with base salary
    public class BasicEmployee : IEmployee
    {
        protected string _name;
        protected decimal _baseSalary;

        public BasicEmployee(string name, decimal baseSalary)
        {
            _name = name;
            _baseSalary = baseSalary;
        }

        public virtual string GetName()
        {
            return _name;
        }

        public virtual decimal GetSalary()
        {
            return _baseSalary;
        }

        public virtual string GetDetails()
        {
            return $"Employee: {_name}\nBase Salary: ${_baseSalary:F2}";
        }
    }

    // Decorator base class
    public abstract class SalaryDecorator : IEmployee
    {
        protected IEmployee _employee;

        public SalaryDecorator(IEmployee employee)
        {
            _employee = employee;
        }

        public virtual string GetName()
        {
            return _employee.GetName();
        }

        public virtual decimal GetSalary()
        {
            return _employee.GetSalary();
        }

        public virtual string GetDetails()
        {
            return _employee.GetDetails();
        }
    }

    // Concrete decorators: Various allowances
    public class HousingAllowanceDecorator : SalaryDecorator
    {
        private const decimal HOUSING_ALLOWANCE = 3000;

        public HousingAllowanceDecorator(IEmployee employee)
            : base(employee) { }

        public override decimal GetSalary()
        {
            return base.GetSalary() + HOUSING_ALLOWANCE;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"\nHousing Allowance: ${HOUSING_ALLOWANCE:F2}";
        }
    }

    public class MealAllowanceDecorator : SalaryDecorator
    {
        private const decimal MEAL_ALLOWANCE = 1500;

        public MealAllowanceDecorator(IEmployee employee)
            : base(employee) { }

        public override decimal GetSalary()
        {
            return base.GetSalary() + MEAL_ALLOWANCE;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"\nMeal Allowance: ${MEAL_ALLOWANCE:F2}";
        }
    }

    public class TransportAllowanceDecorator : SalaryDecorator
    {
        private const decimal TRANSPORT_ALLOWANCE = 1000;

        public TransportAllowanceDecorator(IEmployee employee)
            : base(employee) { }

        public override decimal GetSalary()
        {
            return base.GetSalary() + TRANSPORT_ALLOWANCE;
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"\nTransport Allowance: ${TRANSPORT_ALLOWANCE:F2}";
        }
    }

    public class PerformanceBonusDecorator : SalaryDecorator
    {
        private decimal _bonusPercentage;

        public PerformanceBonusDecorator(IEmployee employee, decimal bonusPercentage)
            : base(employee)
        {
            _bonusPercentage = bonusPercentage;
        }

        public override decimal GetSalary()
        {
            decimal bonus = base.GetSalary() * (_bonusPercentage / 100);
            return base.GetSalary() + bonus;
        }

        public override string GetDetails()
        {
            decimal bonus = base.GetSalary() * (_bonusPercentage / 100);
            return base.GetDetails() + $"\nPerformance Bonus ({_bonusPercentage}%): ${bonus:F2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Employee Salary Benefits System ===\n");

            // Create basic employee
            IEmployee employee1 = new BasicEmployee("Lê Th? Kim Liên", 25000);

            // Add benefits step by step
            employee1 = new HousingAllowanceDecorator(employee1);
            employee1 = new MealAllowanceDecorator(employee1);
            employee1 = new TransportAllowanceDecorator(employee1);
            employee1 = new PerformanceBonusDecorator(employee1, 10);

            Console.WriteLine(employee1.GetDetails());
            Console.WriteLine($"\n=== Total Monthly Salary: ${employee1.GetSalary():F2} ===\n");

            // Different employee with different benefits
            IEmployee employee2 = new BasicEmployee("Nguy?n V?n A", 20000);
            employee2 = new HousingAllowanceDecorator(employee2);
            employee2 = new PerformanceBonusDecorator(employee2, 5);

            Console.WriteLine(employee2.GetDetails());
            Console.WriteLine($"\n=== Total Monthly Salary: ${employee2.GetSalary():F2} ===");
        }
    }
}
// Output: Demonstrates how Decorator pattern adds flexible benefits to employee salaries
