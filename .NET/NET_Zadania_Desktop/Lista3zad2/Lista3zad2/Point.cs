using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista3zad2
{
    public class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Circle
    {
        public Point x;
        public int r;

        public Circle(Point x, int r)
        {
            this.x = x;
            this.r = r;
        }
    }

    public class Triangle
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

        public static double Distance(Point p1, Point p2) => Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2));
        
        public string CalculateType()
        {
            double A = Distance(this.x, this.y);
            double B = Distance(this.y, this.z);
            double C = Distance(this.z, this.x);

            if (A == B && B == C)                   return "Równoboczny";
            else if (A == B || B == C || C == A)    return "Równoramienny";
            else                                    return "Inny";
            
        }
    }

    public class Polygon
    {
        protected List<Point> Points;

        public Polygon(Point[] points) 
        {
            this.Points = points.ToList();
        }
        
    }
}
