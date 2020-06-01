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
using System.Linq;
using System.Windows.Threading;

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly List<Ellipse> arrayOfWhite = new List<Ellipse>();

        private static readonly List<Ellipse> arrayOfBlack = new List<Ellipse>();

        static Ellipse ellipse = null;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                arrayOfWhite.Add(new Ellipse()
                {
                    Fill = new SolidColorBrush(Colors.Pink),
                    Height = 60,
                    Width = 60,
                });

                arrayOfWhite[i].PreviewMouseRightButtonUp += Ellips_MuseRightButtonUp;

                arrayOfBlack.Add(new Ellipse()
                {
                    Fill = new SolidColorBrush(Colors.Black),
                    Height = 60,
                    Width = 60,
                });

                arrayOfBlack[i].PreviewMouseRightButtonUp += Ellips_MuseRightButtonUp;
            }

            SetPositionsOfWhite();
            SetPositionsOfBlack();
            for (int i = 0; i < arrayOfWhite.Count; i++)
            {
                gameField.Children.Add(arrayOfWhite[i]);
                gameField.Children.Add(arrayOfBlack[i]);
            }
        }

        private void Ellips_MuseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            arrayOfWhite.Remove((Ellipse)sender);
            arrayOfBlack.Remove((Ellipse)sender);
            gameField.Children.Remove((Ellipse)sender);

            if (IsEndOfGame())
            {
                foreach (var blackEllips in arrayOfBlack)
                {
                    gameField.Children.Remove(blackEllips);
                }

                foreach (var whiteEllips in arrayOfWhite)
                {
                    gameField.Children.Remove(whiteEllips);
                }

                arrayOfWhite.Clear();
                arrayOfBlack.Clear();

                if (MessageBox.Show("Конец игры, начать новую?", "Конец игры", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Button_Click(null, null);
                }
            }
        }

        private bool IsEndOfGame()
        {
            if (arrayOfBlack.Count == 0)
                return true;
            if (arrayOfWhite.Count == 0)
                return true;
            return false;
        }

        private void SetPositionsOfWhite()
        {
            arrayOfWhite[0].SetValue(Grid.RowProperty, 0);
            arrayOfWhite[1].SetValue(Grid.RowProperty, 0);
            arrayOfWhite[2].SetValue(Grid.RowProperty, 0);
            arrayOfWhite[3].SetValue(Grid.RowProperty, 0);

            arrayOfWhite[0].SetValue(Grid.ColumnProperty, 1);
            arrayOfWhite[1].SetValue(Grid.ColumnProperty, 3);
            arrayOfWhite[2].SetValue(Grid.ColumnProperty, 5);
            arrayOfWhite[3].SetValue(Grid.ColumnProperty, 7);

            arrayOfWhite[4].SetValue(Grid.RowProperty, 1);
            arrayOfWhite[5].SetValue(Grid.RowProperty, 1);
            arrayOfWhite[6].SetValue(Grid.RowProperty, 1);
            arrayOfWhite[7].SetValue(Grid.RowProperty, 1);

            arrayOfWhite[4].SetValue(Grid.ColumnProperty, 0);
            arrayOfWhite[5].SetValue(Grid.ColumnProperty, 2);
            arrayOfWhite[6].SetValue(Grid.ColumnProperty, 4);
            arrayOfWhite[7].SetValue(Grid.ColumnProperty, 6);

            arrayOfWhite[8].SetValue(Grid.RowProperty, 2);
            arrayOfWhite[9].SetValue(Grid.RowProperty, 2);
            arrayOfWhite[10].SetValue(Grid.RowProperty, 2);
            arrayOfWhite[11].SetValue(Grid.RowProperty, 2);

            arrayOfWhite[8].SetValue(Grid.ColumnProperty, 1);
            arrayOfWhite[9].SetValue(Grid.ColumnProperty, 3);
            arrayOfWhite[10].SetValue(Grid.ColumnProperty, 5);
            arrayOfWhite[11].SetValue(Grid.ColumnProperty, 7);
        }

        private void SetPositionsOfBlack()
        {
            arrayOfBlack[0].SetValue(Grid.RowProperty, 7);
            arrayOfBlack[1].SetValue(Grid.RowProperty, 7);
            arrayOfBlack[2].SetValue(Grid.RowProperty, 7);
            arrayOfBlack[3].SetValue(Grid.RowProperty, 7);

            arrayOfBlack[0].SetValue(Grid.ColumnProperty, 0);
            arrayOfBlack[1].SetValue(Grid.ColumnProperty, 2);
            arrayOfBlack[2].SetValue(Grid.ColumnProperty, 4);
            arrayOfBlack[3].SetValue(Grid.ColumnProperty, 6);

            arrayOfBlack[4].SetValue(Grid.RowProperty, 6);
            arrayOfBlack[5].SetValue(Grid.RowProperty, 6);
            arrayOfBlack[6].SetValue(Grid.RowProperty, 6);
            arrayOfBlack[7].SetValue(Grid.RowProperty, 6);

            arrayOfBlack[4].SetValue(Grid.ColumnProperty, 1);
            arrayOfBlack[5].SetValue(Grid.ColumnProperty, 3);
            arrayOfBlack[6].SetValue(Grid.ColumnProperty, 5);
            arrayOfBlack[7].SetValue(Grid.ColumnProperty, 7);

            arrayOfBlack[8].SetValue(Grid.RowProperty, 5);
            arrayOfBlack[9].SetValue(Grid.RowProperty, 5);
            arrayOfBlack[10].SetValue(Grid.RowProperty, 5);
            arrayOfBlack[11].SetValue(Grid.RowProperty, 5);

            arrayOfBlack[8].SetValue(Grid.ColumnProperty, 0);
            arrayOfBlack[9].SetValue(Grid.ColumnProperty, 2);
            arrayOfBlack[10].SetValue(Grid.ColumnProperty, 4);
            arrayOfBlack[11].SetValue(Grid.ColumnProperty, 6);
        }

        private void gameField_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var height = gameField.ActualHeight;
            var width = gameField.ActualWidth;
            var heightOfOneSell = (int)(height / 8);
            var WidthOfOneSell = (int)(width / 8);
            var mousePoint = Mouse.GetPosition(gameField);
            var colomnNumber = (int)(mousePoint.X / WidthOfOneSell);
            var rowNumber = (int)(mousePoint.Y / heightOfOneSell);
            if (ellipse == null)
            {
                for (int i = 0; i < arrayOfWhite.Count && ellipse == null; i++)
                {
                    if ((int)arrayOfWhite[i].GetValue(Grid.ColumnProperty) == colomnNumber && (int)arrayOfWhite[i].GetValue(Grid.RowProperty) == rowNumber)
                    {
                        ellipse = arrayOfWhite[i];
                    }
                }

                for (int i = 0; i < arrayOfBlack.Count && ellipse == null; i++)
                {
                    if ((int)arrayOfBlack[i].GetValue(Grid.ColumnProperty) == colomnNumber && (int)arrayOfBlack[i].GetValue(Grid.RowProperty) == rowNumber)
                    {
                        ellipse = arrayOfBlack[i];
                    }
                }
            }
            else
            {
                ellipse.SetValue(Grid.ColumnProperty, colomnNumber);
                ellipse.SetValue(Grid.RowProperty, rowNumber);
                ellipse = null;
            }
        }
    }
}
