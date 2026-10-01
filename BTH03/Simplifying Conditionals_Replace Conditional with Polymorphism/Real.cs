namespace SimplifyingConditionals_ReplaceConditionalwithPolymorphism
{
    public class Real
    {
        public abstract class PaymentProcessor
        {
            public abstract decimal CalculateTotal(decimal amount);
        }

        public class CreditCardProcessor : PaymentProcessor
        {
            public override decimal CalculateTotal(decimal amount)
            {
                return amount + (amount * 0.03m);
            }
        }

        public class PayPalProcessor : PaymentProcessor
        {
            public override decimal CalculateTotal(decimal amount)
            {
                return amount + (amount * 0.04m);
            }
        }

        public class CashProcessor : PaymentProcessor
        {
            public override decimal CalculateTotal(decimal amount)
            {
                return amount;
            }
        }
    }
}

