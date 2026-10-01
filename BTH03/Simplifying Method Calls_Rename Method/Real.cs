namespace SimplifyingMethodCalls_RenameMethod
{
    public class Real
    {
        public class Order
        {
            private List<decimal> items = new List<decimal>();

            public decimal CalculateTotal()
            {
                decimal total = 0;
                foreach (var price in items)
                    total += price;
                return total;
            }

            public void AddItem(decimal price)
            {
                items.Add(price);
            }

            public int GetItemCount()
            {
                return items.Count;
            }
        }
    }
}

