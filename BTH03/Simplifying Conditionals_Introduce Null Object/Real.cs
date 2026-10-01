namespace SimplifyingConditionals_IntroduceNullObject
{
    public class Real
    {
        public abstract class Logger
        {
            public abstract void Log(string message);
        }

        public class ConsoleLogger : Logger
        {
            public override void Log(string message)
            {
                Console.WriteLine("[LOG] " + message);
            }
        }

        public class NullLogger : Logger
        {
            public override void Log(string message)
            {
                // Do nothing
            }
        }

        public class Application
        {
            private Logger _logger;

            public Application(Logger logger)
            {
                _logger = logger ?? new NullLogger();
            }

            public void Run()
            {
                _logger.Log("Application started");
            }
        }
    }
}

