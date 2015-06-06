using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    public class SnakeElement
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public SnakeElement(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
