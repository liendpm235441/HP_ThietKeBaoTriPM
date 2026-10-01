namespace SimplifyingConditionals_GuardClauses
{
    public class Before
    {
        public decimal CalculateDiscount(int quantity, decimal price)
        {
            if (quantity > 0)
            {
                if (price > 0)
                {
                    if (quantity > 100)
                    {
                        return price * quantity * 0.2m;
                    }
                    else
                    {
                        return price * quantity * 0.1m;
                    }
                }
            }
            return 0;
        }
    }
}

