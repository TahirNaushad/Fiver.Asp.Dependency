namespace Fiver.Asp.Dependency
{
    public interface IGreetingService
    {
        string Greet(string to);
    }

    public class GreetingService : IGreetingService
    {
        public string Greet(string to)
        {
            return $"Hello {to}";
        }
    }

    public class FlexibleGreetingService : IGreetingService
    {
        private readonly string sayWhat;

        public FlexibleGreetingService(string sayWhat)
        {
            this.sayWhat = sayWhat;
        }

        public string Greet(string to)
        {
            return $"{this.sayWhat} {to}";
        }
    }
}
