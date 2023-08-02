using System;
using System.Text;

namespace patterns
{
    public class Car
    {
        /* You’re tasked to create a Car class as part of a module that allows your company to appraise cars base on customers’ provided data.
        Each customer is required to provide the year, make and model of their car.
        They can also provide the trim, color, mileage, and vehicle identification number (a.k.a VIN). */

        // required data
        private int year;
        private string model;
        private string make;

        // optinal data;
        private string trim;
        private int mileage;
        private string vin;
        private string color;

        public Car(CarBuilder carBuilder)
        {
            this.year = carBuilder.year;
            this.model = carBuilder.model;
            this.make = carBuilder.make;
            this.trim = carBuilder.trim;
            this.color = carBuilder.color;
            this.vin = carBuilder.vin;
            this.mileage = carBuilder.mileage;
        }

        public int Year => year;
        public string Model => model;
        public string Make => make;

        public string Trim => trim;
        public int Mileage => mileage;
        public string Vin => vin;
        public string Color => color;

        public override string ToString()
        {
            return new StringBuilder()
                .Append($"Model: {this.model}\n")
                .Append($"Make: {this.make}\n")
                .Append($"Year: {this.year}\n")
                .Append($"Trim: {this.trim}\n")
                .Append($"Mileage: {this.mileage}\n")
                .Append($"Vin: {this.vin}\n")
                .Append($"Color: {this.color}\n")
                .ToString();

        }
    }

    public class CarBuilder
    {
        public int year;
        public string model;
        public string make;

        public string trim;
        public int mileage;
        public string vin;
        public string color;

        public CarBuilder(string model, string make, int year)
        {
            this.model = model;
            this.make = make;
            this.year = year;
        }

        public CarBuilder WithTrim(string trim)
        {
            this.trim = trim;

            return this;
        }
        public CarBuilder WithMileage(int mileage)
        {
            this.mileage = mileage;
            
            return this;
        }
        public CarBuilder WithVIN(string vin)
        {
            this.vin = vin;
            
            return this;
        }
        public CarBuilder WithColor(string color)
        {
            this.color = color;
            
            return this;
        }

        public Car Builder()
        {
            Car car = new Car(this);

            return car;
        }
    }
}