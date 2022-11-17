using System;
using System.Collections.Generic;
using System.IO;

namespace Exercise.LoggerFileGenerics
{
    internal class Program
    {
        static string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "GenericLog.txt");
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>();
            points.Add(new Point(3, 3));
            points.Add(new Point(5, 5));

            Line line = new Line(new Point(3, 3), new Point(5, 5));

            Console.WriteLine("Test");

            GenericLog.LogToFile(points, filepath);
            GenericLog.LogToFile(line, filepath);
        }

        public class Point {
            public int x;
            public int y;
        
            public int Square()
            {
                return x ^ 2 * y ^ 2;
            }

            public Point(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }

        public class Line
        {
            public Point p1;
            public Point p2;

            public Line(Point _p1, Point _p2)
            {
                p1 = _p1;
                p2 = _p2;
            }
        }
    }
}
