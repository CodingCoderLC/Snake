using Snake.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private int _score;
        private Snake.Models.Snake _snake;

        public int Score
        {
            get { return _score; }
            set
            {
                SetProperty<int>(ref _score, value, () => Score);
            }
        }

        public GameViewModel(double x, double y)
        {
            _snake = new Snake.Models.Snake(x, y);
        }

        internal void Move()
        {
            _snake.Move();
        }
    }
}
