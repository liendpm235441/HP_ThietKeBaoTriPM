namespace SimplifyingMethodCalls_SeparateQueryfromModifier
{
    public class After
    {
        public class Item
        {
            private int quantity;

            public int GetQuantity()
            {
                return quantity;
            }

            public void ResetQuantity()
            {
                quantity = 0;
            }
        }
    }
}

