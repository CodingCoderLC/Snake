using Snake.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    public class Snake
    {
        public Direction Direction { get; set; }

        public List<SnakeElement> SnakeElements { get; set; }

        public Snake(double x, double y)
        {
            SnakeElements = new List<SnakeElement> { new SnakeElement(x, y) };
        }

        internal void Move()
        {

        }
    }
}
