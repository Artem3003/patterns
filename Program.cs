using System;
using System.Security.Cryptography.X509Certificates;
using proxy;
using fleweight;

namespace stractural;

public class Program
{
    public static void Main(string[] args)
    {
        // Proxy
        Client client = new Client();
            
        Console.WriteLine("Client: Executing the client code with a real subject:");
        RealSubject realSubject = new RealSubject();
        client.ClientCode(realSubject);

        Console.WriteLine();

        Console.WriteLine("Client: Executing the same client code with a proxy:");
        Proxy proxy = new Proxy(realSubject);
        client.ClientCode(proxy);

        // Flyweight

        // The client code usually creates a bunch of pre-populated
        // flyweights in the initialization stage of the application.
        FlyweightFactory factory = new FlyweightFactory(
            new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
            new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
            new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
            new Car { Company = "BMW", Model = "M5", Color = "red" },
            new Car { Company = "BMW", Model = "X6", Color = "white" }
        );
        factory.ListFlyweights();

        AddCarToPoliceDatabase(factory, new Car {
            Number = "CL234IR",
            Owner = "James Doe",
            Company = "BMW",
            Model = "M5",
            Color = "red"
        });

        AddCarToPoliceDatabase(factory, new Car {
            Number = "CL234IR",
            Owner = "James Doe",
            Company = "BMW",
            Model = "X1",
            Color = "red"
        });

        factory.ListFlyweights();
    }

    public static void AddCarToPoliceDatabase(FlyweightFactory factory, Car car)
    {
        Console.WriteLine("\nClient: Adding a car to database.");
        var flyweight = factory.GetFlyweight(new Car {
            Color = car.Color,
            Model = car.Model,
            Company = car.Company
        });
        // The client code either stores or calculates extrinsic state and
        // passes it to the flyweight's methods.
        flyweight.Operation(car);
    }
} 
