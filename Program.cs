using System;
using System.Security.Cryptography.X509Certificates;
using proxy;

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
    }
} 
