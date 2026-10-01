namespace SimplifyingMethodCalls_ParameterizeMethod
{
    public class Real
    {
        public class Discount
        {
            public decimal ApplyDiscount(decimal amount, decimal discountPercent)
            {
                return amount * (1 - discountPercent / 100m);
            }

            public decimal Apply10PercentDiscount(decimal amount)
            {
                return ApplyDiscount(amount, 10);
            }

            public decimal Apply20PercentDiscount(decimal amount)
            {
                return ApplyDiscount(amount, 20);
            }
        }
    }
}

