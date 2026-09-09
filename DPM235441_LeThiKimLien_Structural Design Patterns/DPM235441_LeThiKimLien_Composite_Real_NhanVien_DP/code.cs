using System;
using System.Collections.Generic;

namespace DPM235441_LeThiKimLien_Composite_Real_NhanVien_DP
{
    // Real-world example: Company organizational structure using Composite pattern
    // Represents both individual employees and departments (groups of employees)

    public abstract class OrganizationMember
    {
        protected string _name;
        protected decimal _salary;

        public OrganizationMember(string name, decimal salary)
        {
            _name = name;
            _salary = salary;
        }

        public abstract string GetInfo();
        public abstract decimal GetTotalSalary();

        public virtual void Add(OrganizationMember member)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(OrganizationMember member)
        {
            throw new NotImplementedException();
        }
    }

    // Leaf: Individual employee
    public class Employee : OrganizationMember
    {
        public Employee(string name, decimal salary)
            : base(name, salary) { }

        public override string GetInfo()
        {
            return $"Employee: {_name} (Salary: ${_salary:F2})";
        }

        public override decimal GetTotalSalary()
        {
            return _salary;
        }
    }

    // Composite: Department containing employees and other departments
    public class Department : OrganizationMember
    {
        private List<OrganizationMember> _members = new List<OrganizationMember>();

        public Department(string name)
            : base(name, 0) { }

        public override void Add(OrganizationMember member)
        {
            _members.Add(member);
        }

        public override void Remove(OrganizationMember member)
        {
            _members.Remove(member);
        }

        public override string GetInfo()
        {
            string info = $"Department: {_name}\n";
            foreach (var member in _members)
            {
                var lines = member.GetInfo().Split('\n');
                foreach (var line in lines)
                {
                    info += "  " + line + "\n";
                }
            }
            return info;
        }

        public override decimal GetTotalSalary()
        {
            decimal total = 0;
            foreach (var member in _members)
            {
                total += member.GetTotalSalary();
            }
            return total;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Company Organizational Structure ===\n");

            // Create company structure
            var company = new Department("Tech Company");

            // Create departments
            var itDept = new Department("IT Department");
            var hrDept = new Department("HR Department");

            // Add employees to IT Department
            itDept.Add(new Employee("Lê Th? Kim Liên", 25000));
            itDept.Add(new Employee("Nguy?n V?n A", 22000));
            itDept.Add(new Employee("Tr?n Th? B", 20000));

            // Add employees to HR Department
            hrDept.Add(new Employee("Ph?m Th? C", 18000));
            hrDept.Add(new Employee("Hoàng V?n D", 17000));

            // Add departments to company
            company.Add(itDept);
            company.Add(hrDept);

            // Display organization
            Console.WriteLine(company.GetInfo());
            Console.WriteLine($"Total Company Salary: ${company.GetTotalSalary():F2}");
        }
    }
}
// Output: Demonstrates how Composite pattern represents hierarchical organizational structure
