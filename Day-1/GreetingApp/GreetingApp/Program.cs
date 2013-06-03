using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreetingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name :");
            var name = Console.ReadLine();
            var dateTimeService = new DateTimeService();
            var greeter = new Greeter(dateTimeService);
            Console.WriteLine(greeter.Greet(name));
            Console.ReadLine();
        }
    }

    public class Greeter
    {
        private readonly IDateTimeService _dateTimeService;

        public Greeter(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public string Greet(string name)
        {
            var greetMsg = string.Empty;

            var currentDateTime = _dateTimeService.GetCurrentDateTime();

            if (currentDateTime.Hour < 12)
            {
                greetMsg = string.Format("Good Morning {0}", name);
            }
            else
            {
                greetMsg = string.Format("Good Evening {0}", name);
            }
            return greetMsg;
        }   
    }

    public interface IDateTimeService
    {
        DateTime GetCurrentDateTime();
    }

    public class DateTimeService : IDateTimeService
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}
