namespace SimplifyingMethodCalls_SeparateQueryfromModifier
{
    public class Before
    {
        public class Item
        {
            private int quantity;

            public int GetAndResetQuantity()
            {
                int temp = quantity;
                quantity = 0;
                return temp;
            }
        }
    }
}

