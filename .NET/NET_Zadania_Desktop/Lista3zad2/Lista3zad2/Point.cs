using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista3zad2
{
    public abstract class Cosiek
    {
        public Cosiek() { }
        public abstract string Wypiszmnie();
    }
    public class Point : Cosiek
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string Wypiszmnie() => $"({this.x}, {this.y})";
        public override string ToString() => $"({this.x}, {this.y})";

    }

    public class Circle : Cosiek
    {
        public Point x;
        public int r;

        public Circle(Point x, int r)
        {
            this.x = x;
            this.r = r;
        }
        public override string Wypiszmnie() => $"{this.x.Wypiszmnie()} {this.r}";

    }

    public class Triangle : Cosiek
    {
        public Point x;
        public Point y;
        public Point z;
        public string type;

        public Triangle(Point x, Point y, Point z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.type = CalculateType();
        }

        public override string Wypiszmnie() => $"{this.type} {this.x.ToString()} {this.y.ToString()} {this.z.ToString()}";

        public static double Distance(Point p1, Point p2) => Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2));

        public string CalculateType()
        {
            double A = Distance(this.x, this.y);
            double B = Distance(this.y, this.z);
            double C = Distance(this.z, this.x);

            if (A == B && B == C) return "Równoboczny";
            else if (A == B || B == C || C == A) return "Równoramienny";
            else return "Inny";

        }

        public Point[] points() => new Point[] { this.x, this.y, this.z };
    }

    public class Polygon : Cosiek 
    {
        public List<Point> Points;

        public Polygon(params Point[] points) 
        {
            this.Points = points.ToList();
        }

        public override string Wypiszmnie()
        {
            string output = "";

            foreach (Point p in this.Points)
                output += p.ToString();
            
            return output;
        }
    }
}
