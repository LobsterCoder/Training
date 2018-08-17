using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles.Puzzles
{
    struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Networking
    {
        public List<Point> Inputs;

        public void FillInput()
        {
            /*Inputs = new List<Point>
            {
                new Point(-5,-3),
                new Point(-9,2),
                new Point(3,-4)
            };*/

            //6066790161
            Inputs = new List<Point>
            {
                new Point(-28189131, 593661200),
                new Point(102460950, 1038900000),
                new Point(938059973,-816049599),
                new Point(-334087877,-290840615),
                new Point(842560881,-116496866),
                new Point(-416604701, 690825000),
                new Point(19715507, 470868300),
                new Point(846505116,-694479954)
            };
        }

        public double GetMinLineLght(List<Point> Inputs)
        {
            int lineX = 0;
            double lineY = 0;
            double positionLineX = 0;
            //min XY, max XY
            int minX = Inputs.Select(p => p.x).Min();
            int minY = Inputs.Select(p => p.y).Min();

            int maxX = Inputs.Select(p => p.x).Max();
            int maxY = Inputs.Select(p => p.y).Max();
            Console.WriteLine("***");
            Console.WriteLine("min X = {0}", minX);
            Console.WriteLine("min Y = {0}", minY);
            Console.WriteLine("max X = {0}", maxX);
            Console.WriteLine("max Y = {0}", maxY);
            Console.WriteLine("***");
            
            //the median: positionLineX - Y value of the middle
            lineX = Math.Abs(maxX - minX);
            Console.Error.WriteLine("lineX = "+ lineX);
            //positionLineX = Math.Round((double)(maxY + minY)/2);
            positionLineX = Math.Round(Inputs.Select(p => p.y).Average());

            var closestPointY = (from point in Inputs let diff = Math.Abs(point.y - positionLineX) orderby diff select new { p1 = point, d1 = diff }).First().p1.y;

            Console.Error.WriteLine("positionLineX = {0}", closestPointY);

            foreach (Point p in Inputs)
            {
                lineY += Math.Abs(p.y - (closestPointY));
                Console.Error.WriteLine("** lineY ={0}", lineY);
            }

            double total = (lineX + lineY);
            return total;
        }

        public void Run()
        {
            FillInput();

            double total = 0;

            #region Debug
            var Inputs1 = Inputs.Select(p => new Point(p.x/10000000, p.y / 10000000)).ToList();
            foreach (var p in Inputs1)
            {
                Console.WriteLine(p.x + "  |  " + p.y);
            }
            #endregion Debug

            total = GetMinLineLght(Inputs);

            Console.Error.WriteLine("min total = {0}", total);
            Console.ReadLine();
        }
    }
}
