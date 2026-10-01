namespace SimplifyingMethodCalls_AddParameter
{
    public class After
    {
        public class Printer
        {
            public void Print(string text, bool isUrgent)
            {
                string prefix = isUrgent ? "[URGENT] " : "";
                Console.WriteLine(prefix + "Printing: " + text);
            }
        }
    }
}

