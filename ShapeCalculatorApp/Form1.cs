using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapeCalculatorApp
{
    public partial class Form1 : Form
    {
        private Figure selectedFigure;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            selectedFigure = null;
        }

        private void DrawCircle(Circle circle)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            float x = (pictureBox1.Width - circle.radius) / 2;
            float y = (pictureBox1.Height - circle.radius) / 2;

            g.DrawEllipse(Pens.Black, x, y, circle.radius, circle.radius);
        }

        private void DrawSquare(Square square)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            float x = (pictureBox1.Width - square.side) / 2;
            float y = (pictureBox1.Height - square.side) / 2;

            g.DrawRectangle(Pens.Black, x, y, square.side, square.side);
        }

        private void DrawRectangle(Rectangle rectangle)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            float x = (pictureBox1.Width - rectangle.length) / 2;
            float y = (pictureBox1.Height - rectangle.width) / 2;

            g.DrawRectangle(Pens.Black, x, y, rectangle.length, rectangle.width);
        }

        private void DrawTriangle(Triangle triangle)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            double x = (Math.Pow(triangle.a, 2) + Math.Pow(triangle.c, 2) - Math.Pow(triangle.b, 2)) / (2 * triangle.a);
            double y = Math.Sqrt(Math.Pow(triangle.c, 2) - x * x);

            Point point1 = new Point(125, 100);
            Point point2 = new Point(125 + triangle.a, 100);
            Point point3 = new Point(125 + (int)x, 100 + (int)y);

            g.DrawLine(Pens.Black, point1, point2);
            g.DrawLine(Pens.Black, point2, point3);
            g.DrawLine(Pens.Black, point3, point1);
        }

        private void UpdateResults(Figure figure)
        {
            if (figure != null)
            {
                double area = figure.CalculateArea();
                double perimeter = figure.CalculatePerimeter();
                label1.Text = $"Площадь: {area:F2}, Периметр: {perimeter:F2}";
            }
            else
            {
                label1.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectedFigure = new Triangle(100, 100, 100);
            DrawTriangle((Triangle)selectedFigure);
            UpdateResults(selectedFigure);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedFigure = new Rectangle(100, 60);
            DrawRectangle((Rectangle)selectedFigure);
            UpdateResults(selectedFigure);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedFigure = new Square(80);
            DrawSquare((Square)selectedFigure);
            UpdateResults(selectedFigure);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedFigure = new Circle(100);
            DrawCircle((Circle)selectedFigure);
            UpdateResults(selectedFigure);
        }
    }
}
