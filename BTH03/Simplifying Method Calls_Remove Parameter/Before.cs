namespace SimplifyingMethodCalls_RemoveParameter
{
    public class Before
    {
        public class Calculator
        {
            public int Add(int a, int b, int unusedParam)
            {
                return a + b;
            }
        }
    }
}

