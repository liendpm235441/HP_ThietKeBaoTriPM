namespace SimplifyingMethodCalls_SeparateQueryfromModifier
{
    public class Real
    {
        public class Queue
        {
            private List<string> items = new List<string>();

            public string Dequeue()
            {
                if (items.Count == 0)
                    return null;
                string first = items[0];
                items.RemoveAt(0);
                return first;
            }

            public int GetQueueSize()
            {
                return items.Count;
            }

            public void Enqueue(string item)
            {
                items.Add(item);
            }
        }
    }
}

