public class Before
{
    class Report
    {
        // ...
        void SendReport()
        {
            DateTime nextDay = previousEnd.AddDays(1);
            // ...
        }
    }
}
