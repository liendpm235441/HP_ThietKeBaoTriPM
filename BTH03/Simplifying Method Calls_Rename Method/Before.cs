namespace SimplifyingMethodCalls_RenameMethod
{
    public class Before
    {
        public class Employee
        {
            private decimal salary;

            public decimal GetSal()
            {
                return salary;
            }

            public void SetSal(decimal newSalary)
            {
                salary = newSalary;
            }
        }
    }
}

