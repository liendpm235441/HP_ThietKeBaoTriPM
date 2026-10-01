namespace SimplifyingMethodCalls_RenameMethod
{
    public class After
    {
        public class Employee
        {
            private decimal salary;

            public decimal GetSalary()
            {
                return salary;
            }

            public void SetSalary(decimal newSalary)
            {
                salary = newSalary;
            }
        }
    }
}

