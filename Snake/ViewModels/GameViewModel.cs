using Snake.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Models;

namespace Snake.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private int _score;
        private Snake.Models.Snake _snake;
        private int _snakeElementWidth;
        private int _snakeElementHeight;

        public int Score
        {
            get { return _score; }
            set
            {
                SetProperty<int>(ref _score, value, () => Score);
            }
        }

        public bool SnakeHasHitPickupItem { get; private set; }

        public GameViewModel(double x, double y, int snakeElementWidth, int snakeElementHeight)
        {
            _snake = new Snake.Models.Snake(x, y, snakeElementHeight, snakeElementWidth);

            this._snakeElementWidth = snakeElementWidth;
            this._snakeElementHeight = snakeElementHeight;
        }

        internal void Move()
        {
            _snake.Move();
        }

        internal Models.Snake GetSnakeInstance()
        {
            return _snake;
        }
    }
}
