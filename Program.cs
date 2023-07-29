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
        }
    }
}