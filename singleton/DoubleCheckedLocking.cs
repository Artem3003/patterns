using System;

namespace singleton
{
    public sealed class DoubleCheckedLockingGreetingService : IGreetingService // sealed - are not able to inherit from that service
    {
        private DoubleCheckedLockingGreetingService() {}

        private static readonly object _lock = new object();

        private static DoubleCheckedLockingGreetingService _instance;

        // Random number is assigned to easily demonstrate that only one instance will be generated
        private readonly string _baseGreet = $"{new Random().Next(2, 100)} Greetings for";

        public static IGreetingService Instance
        {
            get
            {
                // Check if instance needs to be created to avoid unnecessary lock
                // everytime you request an instance of the service
                if (_instance is null)
                {
                    // Lock thread so only one thread can create the first instance
                    lock (_lock)
                    {
                        // Check if instance needs to be created
                        // This is to avoid initial initialization by two threads.
                        if (_instance is null)
                        {
                            _instance = new DoubleCheckedLockingGreetingService();
                        }
                    }
                }

                return _instance;
            }
        }

        public void Greet(string name)
        {
            System.Console.WriteLine($"{_baseGreet} {name}");
        }
    }
}