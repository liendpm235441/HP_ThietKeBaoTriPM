namespace SimplifyingMethodCalls_RemoveParameter
{
    public class Real
    {
        public class UserService
        {
            public bool AuthenticateUser(string username, string password)
            {
                return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
            }

            public void LogActivity(string username, string activity)
            {
                Console.WriteLine($"[{DateTime.Now}] User {username}: {activity}");
            }
        }
    }
}

