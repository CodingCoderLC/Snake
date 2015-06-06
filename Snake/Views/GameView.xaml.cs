using Snake.Enums;
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

            this.Focusable = true;
            this.Focus();
        }

        private void SnakeCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            _gameViewModel = new GameViewModel(SnakeCanvas.ActualWidth / 2, SnakeCanvas.ActualHeight / 2, SnakeElementWidth, SnakeElementHeight);
            DataContext = _gameViewModel;

            foreach(SnakeElement snakeElement in _gameViewModel.GetSnakeInstance().SnakeElements)
            {
                SnakeCanvas.Children.Add(CreateSnakeElementShape(snakeElement.X,
                                                                 snakeElement.Y,
                                                                 SnakeElementWidth,
                                                                 SnakeElementHeight,
                                                                 new SolidColorBrush(Color.FromRgb(51, 51, 51))));
            }

            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(250);
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
                SnakeCanvas.Children.Insert(0, CreateSnakeElementShape(snake.SnakeElements[0].X,
                                                                       snake.SnakeElements[0].Y,
                                                                       SnakeElementWidth,
                                                                       SnakeElementHeight,
                                                                       new SolidColorBrush(Color.FromRgb(51, 51, 51))));
                SnakeCanvas.Children.RemoveAt(SnakeCanvas.Children.Count - 1);
            }

        }

        internal UIElement CreateSnakeElementShape(double left, double top, int width, int height, Brush fill)
        {
            Rectangle snakeElementShape = new Rectangle();
            Canvas.SetLeft(snakeElementShape, left);
            Canvas.SetTop(snakeElementShape, top);
            snakeElementShape.Width = width;
            snakeElementShape.Height = height;
            snakeElementShape.Fill = fill;

            return snakeElementShape;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                case Key.Up:
                    _gameViewModel.SetDirection(Direction.Up);
                    break;

                case Key.D:
                case Key.Right:
                    _gameViewModel.SetDirection(Direction.Right);
                    break;

                case Key.S:
                case Key.Down:
                    _gameViewModel.SetDirection(Direction.Down);
                    break;

                case Key.A:
                case Key.Left:
                    _gameViewModel.SetDirection(Direction.Left);
                    break;

                default:
                    base.OnKeyDown(e);
                    break;
            }
        }
    }
}
