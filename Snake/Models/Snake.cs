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
        private int _snakeElementHeight;
        private int _snakeElementWidth;

        public Direction Direction { get; set; }

        public List<SnakeElement> SnakeElements { get; set; }

        public Snake(double x, double y, int snakeElementHeight, int snakeElementWidth)
        {
            _snakeElementHeight = snakeElementHeight;
            _snakeElementWidth = snakeElementWidth;

            SnakeElements = new List<SnakeElement> { new SnakeElement(x, y, snakeElementHeight, snakeElementWidth)};
            Direction = Direction.Up;
        }

        internal void Move()
        {
            double x = SnakeElements[0].X;
            double y = SnakeElements[0].Y;

            int width = SnakeElements[0].Width;
            int height = SnakeElements[0].Height; 

            switch (Direction)
            {
                case Direction.Up:
                    y = y - height;
                    break;
                case Direction.Right:
                    x = x + width;
                    break;
                case Direction.Down:
                    y = y + height;
                    break;
                case Direction.Left:
                    x = x - width;
                    break;
                default:
                    break;
            }

            SnakeElements.Insert(0, new SnakeElement(x, y, height, width));
            SnakeElements.RemoveAt(SnakeElements.Count - 1);
        }
    }
}
