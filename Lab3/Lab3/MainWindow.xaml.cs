using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<OneDementionArray> _oneDementionArrays = new BindingList<OneDementionArray>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewFile_Click(object sender, RoutedEventArgs e)
        {
            textMain.Text = "";
        }

        private void OpeningFile_Click(object sender, RoutedEventArgs e)
        {
            var openingWindow = new OpeningWindow("Сохранить", textMain.Text);
            openingWindow.Owner = this;
            openingWindow.ShowDialog();
        }

        private void LoadFile_Click(object sender, RoutedEventArgs e)
        {
            var openingWindow = new OpeningWindow("Открыть");
            openingWindow.Owner = this;
            openingWindow.Page1_txtbox1 = this.textMain;
            openingWindow.ShowDialog();
        }

        private void TextMain_TextChanged(object sender, TextChangedEventArgs e)
        {
            textLength.Text = textMain.Text.Length.ToString();
        }

        private void SumItem_Click(object sender, RoutedEventArgs e)
        {
            var spleted = GetSplitedElements();
            var arrInt = GetArrayOfInt(spleted);

            int sum = 0;
            foreach (var item in arrInt)
            {
                sum += item.Where(e => e < 0).Sum();
            }

            MessageBox.Show(sum.ToString(), "Сумма отрицательных чисел", MessageBoxButton.OK);
        }

        private void MulItem_Click(object sender, RoutedEventArgs e)
        {
            var spleted = GetSplitedElements();
            var arrInt = GetArrayOfInt(spleted);

            int mul = 1;

            foreach (var i in arrInt)
            {
                foreach (var j in i)
                {
                    mul *= j;
                }
            }

            MessageBox.Show(mul.ToString(),"Произведение элементов", MessageBoxButton.OK);
        }

        private void SortItem_Click_1(object sender, RoutedEventArgs e)
        {
            var spleted = GetSplitedElements();
            var arrInt = GetArrayOfInt(spleted);

            var builder = new StringBuilder();

            for (int i = 0; i < arrInt.Length; i++)
            {
                arrInt[i] = arrInt[i].OrderBy(e => e).ToArray();
            }

            // ХНЯ КАКАЯ ТО. НУЖНО ПРОВЕРИТЬ

            for (int i = 0; i < arrInt.Length; i++)
            {
                for (int j = 0; j < arrInt[i].Length; j++)
                {
                    builder.Append(arrInt[i][j]);
                    if (j < arrInt[i].Length - 1)
                    {
                        builder.Append(" ");
                    }
                    else
                    {
                        builder.Append("\r");
                    }
                }
                if(i < arrInt.Length - 1)
                {
                    builder.Append("\n");
                }
            }

            textMain.Text = builder.ToString();
        }

        private static int[][] GetArrayOfInt(string[][] spleted)
        {
            var arrInt = new int[spleted.Length][];
            for (int i = 0; i < spleted.Length; i++)
            {
                arrInt[i] = new int[spleted[i].Length];
                for (int j = 0; j < spleted[i].Length; j++)
                {
                    arrInt[i][j] = int.Parse(spleted[i][j]);
                }
            }
            return arrInt;
        }

        private string[][] GetSplitedElements()
        {
            var text = textMain.Text;
            var splitText = text.Split('\n');
            for (int i = 0; i < splitText.Length; i++)
            {
                splitText[i] = splitText[i].Split('\r')[0];
            }
            var splitedArr = new string[splitText.Length][];
            for (int i = 0; i < splitText.Length; i++)
            {
                splitedArr[i] = splitText[i].Split(' ').ToArray<string>();
            }

            return splitedArr;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Автор молодец, в представлении не нуждается.", "Информация об авторе");
        }
    }
}
