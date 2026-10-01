namespace OrganizingData_EncapsulateField
{
    public class Real
    {
        public class BankAccount
        {
            private string _accountNumber;
            private decimal _balance;

            public string AccountNumber
            {
                get { return _accountNumber; }
                set { _accountNumber = value; }
            }

            public decimal Balance
            {
                get { return _balance; }
                private set { _balance = value; }
            }

            public void Deposit(decimal amount)
            {
                if (amount > 0)
                    Balance += amount;
            }

            public bool Withdraw(decimal amount)
            {
                if (amount > 0 && amount <= Balance)
                {
                    Balance -= amount;
                    return true;
                }
                return false;
            }
        }
    }
}

