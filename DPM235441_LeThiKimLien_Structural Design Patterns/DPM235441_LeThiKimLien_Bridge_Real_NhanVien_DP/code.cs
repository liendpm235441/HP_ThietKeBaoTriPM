using System;

namespace DPM235441_LeThiKimLien_Bridge_Real_NhanVien_DP
{
    // Real-world example: Employee payment system using Bridge pattern
    // Separates employee type from payment method

    // Implementation: Payment method abstraction
    public interface IPaymentMethod
    {
        string ProcessPayment(decimal amount, string employeeName);
    }

    // Concrete payment methods
    public class BankTransferPayment : IPaymentMethod
    {
        public string ProcessPayment(decimal amount, string employeeName)
        {
            return $"Bank Transfer: ${amount:F2} to {employeeName}'s account";
        }
    }

    public class CashPayment : IPaymentMethod
    {
        public string ProcessPayment(decimal amount, string employeeName)
        {
            return $"Cash Payment: ${amount:F2} handed to {employeeName}";
        }
    }

    // Abstraction: Employee type
    public abstract class Employee
    {
        protected IPaymentMethod _paymentMethod;
        protected string _name;
        protected decimal _salary;

        public Employee(string name, decimal salary, IPaymentMethod paymentMethod)
        {
            _name = name;
            _salary = salary;
            _paymentMethod = paymentMethod;
        }

        public abstract string GetDetails();

        public string PayEmployee()
        {
            return GetDetails() + "\n" + _paymentMethod.ProcessPayment(_salary, _name);
        }
    }

    // Concrete implementations
    public class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(string name, decimal salary, IPaymentMethod paymentMethod)
            : base(name, salary, paymentMethod) { }

        public override string GetDetails()
        {
            return $"Full-Time Employee: {_name} - Base Salary: ${_salary:F2}";
        }
    }

    public class PartTimeEmployee : Employee
    {
        public PartTimeEmployee(string name, decimal hourlyRate, IPaymentMethod paymentMethod)
            : base(name, hourlyRate * 160, paymentMethod) // 160 hours/month assumed
        {
        }

        public override string GetDetails()
        {
            return $"Part-Time Employee: {_name} - Monthly Salary: ${_salary:F2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Employee Payment Processing System ===\n");

            // Create payment methods
            IPaymentMethod bankTransfer = new BankTransferPayment();
            IPaymentMethod cash = new CashPayment();

            // Create employees with different payment methods
            Employee fullTimeWithBank = new FullTimeEmployee("Lê Th? Kim Liên", 25000, bankTransfer);
            Employee partTimeWithCash = new PartTimeEmployee("Nguy?n V?n A", 150, cash);

            // Process payments
            Console.WriteLine(fullTimeWithBank.PayEmployee());
            Console.WriteLine();
            Console.WriteLine(partTimeWithCash.PayEmployee());
        }
    }
}
// Output: Demonstrates how Bridge pattern separates employee types from payment methods
