using System;

namespace patterns
{
    /* Design a system to handle the shapes: circles, ellipses, rectangles and squares.
    Use the Factory Method design pattern according to the instructions given below.
    a) The interface should have two method prototypes for computing the area and perimeter of the shapes.
    b) Create classes for each of the shapes. You should use inheritance appropriately.
    c) The object should be created based on the user inputs as shown in table below.
    c - Circle object
    r - Rectangle object
    s - Square object
    e - Ellipse object
    d) Create a circle object with the radius = 7. */

    // fabric
    public class ShapeCreator
    {
        public static IShape CreateShape(ObjectType shape, int a)
        {
            switch (shape)
            {
                case ObjectType.C:
                    return new Circle(a);
                case ObjectType.S:
                    return new Square(a);
                default:
                    return null;
            }
        }
        public static IShape CreateShape(ObjectType shape, int a, int b)
        {
            switch (shape)
            {
                case ObjectType.R:
                    return new Rectangle(a, b);
                case ObjectType.E:
                    return new Rectangle(a, b);
                default:
                    return null;
            }
        }
    }

    public enum ObjectType
    {
        C, R, S, E
    }

    // shapes
    public interface IShape
    {
        double Area{ get; }
        double Perimeter{ get; }
    }

    public class Circle : IShape
    {
        private int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }
        public double Area => Math.PI * Math.Pow(radius, 2);
        public double Perimeter => 2 * Math.PI * radius;
    }

    public class Rectangle : IShape
    {
        private int a, b, c;
        public Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public double Area => a * b;
        public double Perimeter => 2 * (a + b);
    }

    public class Square : IShape
    {
        private int a;
        public Square(int a)
        {
            this.a = a;
        }
        public double Area => a * a;
        
        public double Perimeter => 4 * a;
    }
    
    public class Ellipse : IShape
    {
        private int a, b;
        public Ellipse(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public double Area => Math.PI * a * b;
        public double Perimeter => 2 * Math.PI * Math.Sqrt((a * a + b * b) / 2);
    }
}