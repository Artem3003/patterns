using System;
using System.Collections.Generic;
using System.Text;

namespace patterns
{
    /* You can create 3 coffee recipes:
    
    Black = Black coffee
    Cubano = Cubano coffee + Brown sugar
    Americano = Americano coffee + Milk with 0.5% fat

    And you can add a lot of extra sugar and extra milk in any coffee, e.g.:

    Black + Milk with 3.2% fat + Brown sugar
    Cubano + Brown sugar + Brown sugar + Regular sugar
    Americano + Milk with 3.2% fat + Milk with 0% fat + Regular sugar

    You need to create a Coffee by implementing a CoffeeBuilder class/class like in the Builder design pattern. */

    class Coffee
    {
        private string sort;
        private List<Milk> milk;
        private List<Sugar> sugar;

        public Coffee(CoffeeBuilder coffeeBuilder)
        {
            this.sort = coffeeBuilder.sort;
            this.milk = coffeeBuilder.milk;
            this.sugar = coffeeBuilder.sugar;

        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            
            builder.Append($"Coffee: {this.sort}\n");

            foreach (Milk fat in milk)
            {
                builder.Append($"Milk {fat.Fat}% fat");
            }
            foreach (Sugar sort in sugar)
            {
                builder.Append($"Milk {sort.Sort}% fat");
            }
            return builder.ToString();
        }
    }

    class Milk
    {
        public double Fat;

        public Milk(double fat)
        {
            this.Fat = fat;
        }
    }

    class Sugar
    {
        public string Sort;

        public Sugar(string sort)
        {
            this.Sort = sort;
        }
    }

    class CoffeeBuilder
    {    
        public string sort;
        public List<Milk> milk;
        public List<Sugar> sugar;
        public CoffeeBuilder() 
        {
            this.milk = new List<Milk>();
            this.sugar = new List<Sugar>();
        }

        public CoffeeBuilder SetBlackCoffee()
        {
            this.sort = "Black";

            return this;
        }

        public CoffeeBuilder SetCubanoCoffee()
        {
            this.sort = "Cubano";
            sugar.Add(new Sugar("Brown"));

            return this;
        }

        public CoffeeBuilder SetAntoccinoCoffee()
        {
            this.sort = "Americano";
            milk.Add(new Milk(0.5));

            return this;
        }

        public CoffeeBuilder WithMilk(double fat)
        {
            milk.Add(new Milk(fat));

            return this;
        }   

        public CoffeeBuilder WithSugar(string sort)
        {
            sugar.Add(new Sugar(sort));

            return this;
        }

        public Coffee Build()
        {
            Coffee coffee = new Coffee(this);
            return coffee;
        }
    }
}