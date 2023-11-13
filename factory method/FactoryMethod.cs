using System;

namespace factoryMethod
{
   /*  Assume there is a restaurant that sells fast-food.
    In this restaurant, they have several types of fast-food such as, meals, beverages, salads, and deserts.
    However, if a customer wants, they can buy those as combos (collection of different food items).
    The combos come with three different categories named as, Lite-Combo, Family-Combo, and Mega-Combo.
    Each combo contains different types of foods based on the budget of that combo. */

    public class ComboCreator
    {
        public static Combos CreateCombos(ComboCode comboCode)
        {
            switch (comboCode)
            {
                case ComboCode.LITE:
                    Console.WriteLine("Selected Combo: LiteCombo");
                    return new LiteCombo();
                case ComboCode.FAMILY:
                    Console.WriteLine("Selected Combo: FamilyCombo");
                    return new FamilyCombo();
                case ComboCode.MEGA:
                    Console.WriteLine("Selected Combo: MegaCombo");
                    return new MegaCombo();
                default:
                    return null;
            }
        }
    }

    public enum ComboCode
    {
        LITE, FAMILY, MEGA
    }

    // fabric
    public abstract class RegularOrders
    {
        public abstract void PrintOrder();
    }

    public abstract class Combos
    {
        protected List<RegularOrders> regularOrders = new List<RegularOrders>();

        public Combos()
        {
            ComboDetails();
        }

        protected abstract void ComboDetails();

        public void PrintOrder()
        {
            Console.WriteLine("Type Price");
            for (int i = 0; i < regularOrders.Count; i++)
            {
                regularOrders[i].PrintOrder();
            }
            Console.WriteLine("_____________________________\n");
        }
    }

    // types of fast-food
    public class Meals : RegularOrders
    {
        public string name = "Meals";
        public int price = 950;

        public override void PrintOrder()
        {
            Console.WriteLine($"{name} - {price}", name, price);
        }
    }

    public class Beverages : RegularOrders
    {
        public string name = "Beverages";
        public int price = 200;

        public override void PrintOrder()
        {
            Console.WriteLine($"{name} - {price}", name, price);
        }
    }

    public class Salads : RegularOrders
    {
        public string name = "Salads";
        public int price = 400;

        public override void PrintOrder()
        {
            Console.WriteLine($"{name} - {price}", name, price);
        }
    }

    public class Deserts : RegularOrders
    {
        public string name = "Deserts";
        public int price = 550;

        public override void PrintOrder()
        {
            Console.WriteLine($"{name} - {price}", name, price);
        }
    }

    // types of combos
    public class LiteCombo : Combos
    {
        protected override void ComboDetails()
        {
            regularOrders.Add(new Meals());
            regularOrders.Add(new Beverages());
        }
    }

    public class FamilyCombo : Combos
    {
        protected override void ComboDetails()
        {
            regularOrders.Add(new Meals());
            regularOrders.Add(new Beverages());
            regularOrders.Add(new Deserts());
        }
    }

    public class MegaCombo : Combos
    {
        protected override void ComboDetails()
        {
            regularOrders.Add(new Meals());
            regularOrders.Add(new Beverages());
            regularOrders.Add(new Deserts());
            regularOrders.Add(new Salads());
        }
    }
}