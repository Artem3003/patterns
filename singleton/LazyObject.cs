using System;

namespace singleton
{
    public class LazyObjectGreetingService : IGreetingService
    {
         // Random number is assigned to easily demonstrate that only one instance will be generated
        private readonly string _baseGreet = $"{new Random().Next(2, 100)} Greetings for";

        // We can go even further and not use a private variable anymore and use Auto-Property, which assigns a value for the property if it doesn’t have a value yet.
        static LazyObjectGreetingService() {} 

        private static readonly Lazy<LazyObjectGreetingService> _instance = new Lazy<LazyObjectGreetingService>(() => new LazyObjectGreetingService());

        public static IGreetingService Instance { get => _instance.Value;}

        public void Greet(string name)
        {
            System.Console.WriteLine($"{_baseGreet} {name}");
        }
    }
}