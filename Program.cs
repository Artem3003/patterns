using System.Reflection;
using System;
using NUnit.Framework;
using singleton;
using prtotype;
using factoryMethod;

namespace creational
{
    class Program
    {
        static void Main(string[] args)
        {
            // Factory Method
            Combos combos = ComboCreator.CreateCombos(ComboCode.LITE);
            combos.PrintOrder();
            
            Combos combos1 = ComboCreator.CreateCombos(ComboCode.FAMILY);
            combos.PrintOrder();

            Combos combos2 = ComboCreator.CreateCombos(ComboCode.MEGA);
            combos.PrintOrder();

            IShape circle = ShapeCreator.CreateShape(ObjectType.C, 7);
            Console.WriteLine("Area of shape: " + circle.Area);
            Console.WriteLine("Parimeter of shape: " + circle.Perimeter);
            
            // singleton
            // double checked locking
            IGreetingService service = DoubleCheckedLockingGreetingService.Instance;
            IGreetingService service1 = DoubleCheckedLockingGreetingService.Instance;

            service.Greet("Singletion");
            service1.Greet("Singleton");

            // lazy object
            IGreetingService LazyObjectService = LazyObjectGreetingService.Instance;
            IGreetingService LazyObjectService1 = LazyObjectGreetingService.Instance;

            LazyObjectService.Greet("Singleton");
            LazyObjectService1.Greet("Singleton");

            // singleton idependent task
            
            // Adam Is Unique
            Adam adam = Adam.GetInstance();
            Adam anotherAdam = Adam.GetInstance();
            
            Assert.IsTrue(adam is Adam);
            Assert.AreEqual(adam, anotherAdam);
            
            // Adam is unique and only GetInstance can return adam
            // GetInstance() is the only static method on Adam
            Assert.AreEqual(1, typeof(Adam).GetMethods().Where(x => x.IsStatic).Count());
            // Adam does not have public or internal constructors
            Assert.IsFalse(typeof(Adam).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Any(x => x.IsPublic || x.IsAssembly));
        
            // Adam is unique and cannot be overrriden
            Assert.IsTrue(typeof(Adam).IsSealed);

            // Adam is a human
            Assert.IsTrue(Adam.GetInstance() is Human);

            //Adam is a male
            Assert.IsTrue(Adam.GetInstance() is Male);

            // Eva is unique and created from a rib of adam
            // Adam adam = Adam.GetInstance();
            Eve eve = Eve.GetInstance(adam);
            Eve anotherEve = Eve.GetInstance(adam);

            Assert.IsTrue(eve is Eve);
            Assert.AreEqual(eve, anotherEve);
            // GetInstance() is the only static method on Eve
            Assert.AreEqual(1, typeof(Eve).GetMethods().Where(x => x.IsStatic).Count());
            // Eve has no public or internal constructor
            Assert.IsFalse(typeof(Eve).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Any(x => x.IsPublic || x.IsAssembly));
            // Eve cannot be overridden
            Assert.IsTrue(typeof(Eve).IsSealed);

            // Eve can only be create of a rib of adam
            Assert.Throws<ArgumentNullException>(() => Eve.GetInstance(null));
            
            // Eve is a human
            Assert.IsTrue(Eve.GetInstance(Adam.GetInstance()) is Human);

            // Eve is a female
            Assert.IsTrue(Eve.GetInstance(Adam.GetInstance()) is Female);

            // Reproduction always result in a male or female
            Assert.IsTrue(typeof(Human).IsAbstract);

            // Humans can reproduce when there is a name of mother and a father
            // Adam adam = Adam.GetInstance();
            // Eve eve = Eve.GetInstance(adam);
            Female azura = new Female("Azura", eve, adam);
            Male seth = new Male("Seth", eve, adam);
            Male enos = new Male("Enos", azura, seth);

            Assert.AreEqual("Eve", eve.Name);
            Assert.AreEqual("Adam", adam.Name);
            Assert.AreEqual("Seth", seth.Name);
            Assert.AreEqual("Azura", azura.Name);
            Assert.AreEqual("Enos", ((Human)enos).Name);
            Assert.AreEqual(seth, ((Human)enos).Father);
            Assert.AreEqual(azura, ((Human)enos).Mother);

            // Father and mother are essential for reproduction
            // There is just 1 way to reproduce 
            Assert.AreEqual(1, typeof(Male).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
              .Where(x => x.IsPublic || x.IsAssembly).Count());
            Assert.AreEqual(1, typeof(Female).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).
              Where(x => x.IsPublic || x.IsAssembly).Count());

            // Adam adam = Adam.GetInstance();
            // Eve eve = Eve.GetInstance(adam);
            Assert.Throws<ArgumentNullException>(() => new Male("Seth", null, null));
            Assert.Throws<ArgumentNullException>(()=> new Male("Abel", eve, null));
            Assert.Throws<ArgumentNullException>(() => new Male("Seth", null, adam));
            Assert.Throws<ArgumentNullException>(() => new Female("Azura", null, null));
            Assert.Throws<ArgumentNullException>(() => new Female("Awan", eve, null));
            Assert.Throws<ArgumentNullException>(() => new Female("Dina", null, adam));
            Assert.Throws<ArgumentNullException>(() => new Female("Eve", null, null));
            Assert.Throws<ArgumentNullException>(() => new Male("Adam", null, null));

            // Prototype
            Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Jack Daniels";
            p1.IdInfo = new IdInfo(666);

            // Perform a shallow copy of p1 and assign it to p2.
            Person p2 = p1.ShallowCopy();
            // Make a deep copy of p1 and assign it to p3.
            Person p3 = p1.DeepCopy();

            // Display values of p1, p2 and p3.
            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values:");
            DisplayValues(p3);

            // Change the value of p1 properties and display the values of p1,
            // p2 and p3.
            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1900-01-01");
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values (reference values have changed):");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values (everything was kept the same):");
            DisplayValues(p3);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                p.Name, p.Age, p.BirthDate);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }
    }
}