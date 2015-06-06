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

        public int Score
        {
            get { return _score; }
            set
            {
                SetProperty<int>(ref _score, value, () => Score);
            }
        }

    }
}
