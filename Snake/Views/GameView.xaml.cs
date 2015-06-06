using Snake.Models;
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
        private const int SnakeElementHeight = 16;
        private const int SnakeElementWidth = 16;

        private DispatcherTimer _dispatcherTimer;

        private GameViewModel _gameViewModel;

        public GameView()
        {
            InitializeComponent();
        }

        private void SnakeCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            _gameViewModel = new GameViewModel(SnakeCanvas.ActualWidth / 2, SnakeCanvas.ActualHeight / 2, SnakeElementWidth, SnakeElementHeight);
            DataContext = _gameViewModel;

            foreach(SnakeElement snakeElement in _gameViewModel.GetSnakeInstance().SnakeElements)
            {
                Rectangle snakeElementShape = new Rectangle();
                Canvas.SetLeft(snakeElementShape, snakeElement.X);
                Canvas.SetTop(snakeElementShape, snakeElement.Y);
                snakeElementShape.Width = SnakeElementWidth;
                snakeElementShape.Height = SnakeElementHeight;
                snakeElementShape.Fill = new SolidColorBrush(Color.FromRgb(51, 51, 51)); //#333333

                SnakeCanvas.Children.Add(snakeElementShape);
            }

            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(500);
            _dispatcherTimer.Tick += Tick;

            _dispatcherTimer.IsEnabled = true;
            _dispatcherTimer.Start();

        }

        private void Tick(object sender, EventArgs e)
        {
            Snake.Models.Snake snake = _gameViewModel.GetSnakeInstance();

            _gameViewModel.Move();

            if (_gameViewModel.SnakeHasHitPickupItem)
            {

            }
            else
            {
                Rectangle snakeElementShape = new Rectangle();
                Canvas.SetLeft(snakeElementShape, snake.SnakeElements[0].X);
                Canvas.SetTop(snakeElementShape, snake.SnakeElements[0].Y);
                snakeElementShape.Width = SnakeElementWidth;
                snakeElementShape.Height = SnakeElementHeight;
                snakeElementShape.Fill = new SolidColorBrush(Color.FromRgb(51,51,51)); //#333333

                SnakeCanvas.Children.Insert(0, snakeElementShape);
                SnakeCanvas.Children.RemoveAt(SnakeCanvas.Children.Count - 1);
            }

        }
    }
}
