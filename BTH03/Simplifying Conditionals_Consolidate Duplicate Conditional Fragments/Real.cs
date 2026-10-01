namespace SimplifyingConditionals_GuardClauses
{
    public class Real
    {
        public void ProcessOrder(string customerName, decimal orderAmount, int quantity)
        {
            if (string.IsNullOrEmpty(customerName))
            {
                Console.WriteLine("Error: Customer name required");
                return;
            }

            if (orderAmount <= 0)
            {
                Console.WriteLine("Error: Order amount must be positive");
                return;
            }

            if (quantity <= 0)
            {
                Console.WriteLine("Error: Quantity must be positive");
                return;
            }

            Console.WriteLine($"Processing order for {customerName}: {quantity} items at {orderAmount}");
        }
    }
}

