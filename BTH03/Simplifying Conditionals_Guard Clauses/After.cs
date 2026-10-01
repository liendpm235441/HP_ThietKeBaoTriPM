namespace SimplifyingConditionals_GuardClauses
{
    public class After
    {
        public decimal CalculateDiscount(int quantity, decimal price)
        {
            if (quantity <= 0 || price <= 0)
                return 0;

            if (quantity > 100)
                return price * quantity * 0.2m;

            return price * quantity * 0.1m;
        }
    }
}

