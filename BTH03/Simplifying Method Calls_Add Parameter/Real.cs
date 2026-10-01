namespace SimplifyingMethodCalls_AddParameter
{
    public class Real
    {
        public class EmailService
        {
            public void SendEmail(string to, string subject, string body, bool isHtml = false)
            {
                string contentType = isHtml ? "text/html" : "text/plain";
                Console.WriteLine($"Sending email to {to} with content type: {contentType}");
                Console.WriteLine($"Subject: {subject}");
                Console.WriteLine($"Body: {body}");
            }
        }
    }
}

