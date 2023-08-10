using System;

namespace patterns
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

            // Builder
            Car myCar = new CarBuilder("BMW","X5", 2020)
                .WithColor("gray")
                .Builder();


            Car myCar1 = new CarBuilder("Audi","Q5", 2012)
                    .WithColor("gray")
                    .WithMileage(78000)
                    .WithVIN("vin")
                    .Builder();

            Car myCar2 = new CarBuilder("Acura","TLX", 2017)
                    .WithColor("gray")
                    .WithMileage(27000)
                    .WithVIN("vin")
                    .WithTrim("trim")
                    .Builder();

            System.Console.WriteLine(myCar.ToString());
            System.Console.WriteLine(myCar1.ToString());
            System.Console.WriteLine(myCar2.ToString());
            System.Console.WriteLine(myCar.Model);
            
            // 

            Coffee coffee = new CoffeeBuilder().SetBlackCoffee().WithSugar("Regular").WithMilk(3.2).Build();
            System.Console.WriteLine(coffee.ToString());

            Coffee coffeeAntoccino = new CoffeeBuilder().SetAntoccinoCoffee().Build();
            System.Console.WriteLine(coffeeAntoccino.ToString());

            Coffee coffeeCubano = new CoffeeBuilder().SetCubanoCoffee().Build();
            System.Console.WriteLine(coffeeCubano.ToString());
        }
    }
}