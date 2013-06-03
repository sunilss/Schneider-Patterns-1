using System;
using GreetingApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreetingAppTests
{
    [TestClass]
    public class GreeterTests
    {
        [TestMethod]
        public void When_Greeted_Before_12_Returns_GoodMorning()
        {
            //Arrage
            var morningTimeService = new FakeDateTimeServiceForMorning();
            var greeter = new Greeter(morningTimeService);
            var name = "magesh";

            //Act
            var msg = greeter.Greet(name);

            //Assert
            Assert.IsTrue(msg.StartsWith("Good Morning"));
        }

        [TestMethod]
        public void When_Greeted_After_12_Returns_GoodEvening()
        {
            //Arrage
            var eveningTimeService = new FakeDateTimeServiceForEvening();
            var greeter = new Greeter(eveningTimeService);
            var name = "magesh";

            //Act
            var msg = greeter.Greet(name);

            //Assert
            Assert.IsTrue(msg.StartsWith("Good Evening"));
        }
    }

    public class FakeDateTimeServiceForMorning : IDateTimeService
    {
        public DateTime GetCurrentDateTime()
        {
            return new DateTime(2013,06,03,09,0,0);
        }
    }

    public class FakeDateTimeServiceForEvening : IDateTimeService
    {
        public DateTime GetCurrentDateTime()
        {
            return new DateTime(2013, 06, 03, 15, 0, 0);
        }
    }
}
