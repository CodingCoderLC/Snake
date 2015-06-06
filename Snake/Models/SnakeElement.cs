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

        public int Height { get; private set; }
        public int Width { get; private set; }

        public SnakeElement(double x, double y, int height, int width)
        {
            this.X = x;
            this.Y = y;
            this.Height = height;
            this.Width = width;
        }
    }
}
