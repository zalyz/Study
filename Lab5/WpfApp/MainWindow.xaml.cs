using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly PointCollection Points = new PointCollection();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Path_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mousePoint = Mouse.GetPosition(paintField);
            DrawFigures(mousePoint);
        }

        private void DrawFigures(Point coords)
        {
            Shape figure = null;
            if (radioEllips.IsChecked == true)
            {
                figure = GetEllipse(coords);
            }

            if (radioLine.IsChecked == true)
            {
                figure = GetLine(coords);
            }

            if (radioPlygon.IsChecked == true)
            {
                figure = GetPolygon(coords);
            }

            if (radioRectangle.IsChecked == true)
            {
                figure = GetRectangle(coords);
            }

            if (radioSquare.IsChecked == true)
            {
                figure = GetSquare(coords);
            }

            if (figure != null)
            {
                paintField.Children.Add(figure);
                Points.Clear();
            }
        }

        private SolidColorBrush GetBrush()
        {
            if (red.IsChecked == true)
            {
                return new SolidColorBrush(Colors.Red);
            }

            if (black.IsChecked == true)
            {
                return new SolidColorBrush(Colors.Black);
            }

            if (purple.IsChecked == true)
            {
                return new SolidColorBrush(Colors.Purple);
            }

            if (pink.IsChecked == true)
            {
                return new SolidColorBrush(Colors.Pink);
            }

            if (yellow.IsChecked == true)
            {
                return new SolidColorBrush(Colors.Yellow);
            }

            if (blue.IsChecked == true)
            {
                return new SolidColorBrush(Colors.Blue);
            }

            return new SolidColorBrush(Colors.White);
        }

        private Ellipse GetEllipse(Point point)
        {
            var ellipse = new Ellipse
            {
                Height = 90,
                Width = 90,
                Fill = GetBrush(),
                Margin = new Thickness(point.X, point.Y, 0, 0)
            };
            return ellipse;
        }

        private Line GetLine(Point point)
        {
            if (Points.Count == 1)
            {
                var line = new Line
                {
                    //Margin = new Thickness(point.X, point.Y, 0, 0),
                    X1 = Points[0].X,
                    X2 = point.X,
                    Y1 = Points[0].Y,
                    Y2 = point.Y,
                    Stroke = GetBrush(),
                    StrokeThickness = 2,
                    Visibility = Visibility.Visible
                };

                return line;
            }

            Points.Add(point);
            return null;
        }

        private Polygon GetPolygon(Point point)
        {
            if (Points.Count == 5)
            {
                Points.Add(point);
                var polygon = new Polygon
                {
                    Fill = GetBrush(),
                    Visibility = Visibility.Visible,
                    Points = Points,
                };

                return polygon;
            }

            Points.Add(point);
            return null;
        }

        private Rectangle GetRectangle(Point point)
        {
            var rectangle = new Rectangle()
            {
                Height = 90,
                Width = 180,
                Fill = GetBrush(),
                Margin = new Thickness(point.X, point.Y, 0, 0),
            };

            return rectangle;
        }

        private Rectangle GetSquare(Point point)
        {
            var rectangle = new Rectangle()
            {
                Height = 50,
                Width = 50,
                Fill = GetBrush(),
                Margin = new Thickness(point.X, point.Y, 0, 0),
            };

            return rectangle;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            paintField.Children.Clear();
        }
    }
}
