using Snake.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snake.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        private DispatcherTimer _dispatcherTimer;

        private GameViewModel _gameViewModel;

        public GameView()
        {
            _gameViewModel = new GameViewModel();
            DataContext = _gameViewModel;

            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(30);
            _dispatcherTimer.Tick += Tick;

            _dispatcherTimer.IsEnabled = true;
            _dispatcherTimer.Start();

            InitializeComponent();
        }

        private void Tick(object sender, EventArgs e)
        {
            _gameViewModel.Move();
        }
    }
}
