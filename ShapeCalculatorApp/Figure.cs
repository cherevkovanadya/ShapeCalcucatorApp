using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeCalculatorApp
{
    abstract class Figure
    {
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }

    class Circle : Figure
    {
        private int radius2;
        private int radius2_read_count;
        public int radius {
            get { this.radius2_read_count++;
                return this.radius2;
            } private set { this.radius2 = value; } }

        public Circle(int radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Значение радиуса круга должно быть положительным числом.");

            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }
    }

    class Square : Figure
    {
        public int side { get; private set; }

        public Square(int side)
        {
            if (side <= 0)
                throw new ArgumentException("Значения сторон квадрата должны быть положительными числами.");

            this.side = side;
        }

        public override double CalculateArea()
        {
            return side * side;
        }

        public override double CalculatePerimeter()
        {
            return 4 * side;
        }
    }

    class Rectangle : Figure
    {
        public int length { get; private set; }
        public int width { get; private set; }

        public Rectangle(int length, int width)
        {
            if (length <= 0 || width <= 0)
                throw new ArgumentException("Значения сторон прямоугольника должны быть положительными числами.");

            this.length = length;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return length * width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (length + width);
        }
    }

    class Triangle : Figure
    {
        public int a { get; private set; }
        public int b { get; private set; }
        public int c { get; private set; }

        public Triangle(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Значения сторон треугольника должны быть положительными числами.");

            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("Сумма любых двух сторон треугольника должна быть больше третьей стороны.");

            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override double CalculateArea()
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public override double CalculatePerimeter()
        {
            return a + b + c;
        }
    }
}
