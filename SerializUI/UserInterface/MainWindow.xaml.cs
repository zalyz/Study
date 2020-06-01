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
using SerializableAPI;
using SerializableAPI.Classes;
using SerializableAPI.Repository;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fileName;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            var fileInfo = GetFile();
            if (fileInfo.Item1 != null && fileInfo.Item2 != null)
            {
                MainTable.ItemsSource = FileProcessing.Read(fileInfo.Item1, fileInfo.Item2);
            }
        }

        private (string, IRepository<Train>) GetFile()
        {
            var fileDialog = new FileDialog();
            fileDialog.ShowDialog();
            fileName = FileDialog.FileDialogWindow.fileName;
            if (!string.IsNullOrEmpty(fileName))
            {
                var typeOfFile = fileName.Split('.')[1];
                (string, IRepository<Train>) fileInfo = (fileName, null);
                fileInfo.Item2 = typeOfFile switch
                {
                    "csv" => new ScvRepository(),
                    "bin" => new BinaryRepository(),
                    "xml" => new XMLRepository(),
                    "json" => new JsonRepository(),
                };

                return fileInfo;
            }

            return (null, null);
        }

        private void WriteButton_Click(object sender, RoutedEventArgs e)
        {
            var fileInfo = GetFile();
            if (fileInfo.Item1 != null && fileInfo.Item2 != null)
            {
                var collection = (Train[])MainTable.ItemsSource;
                FileProcessing.Write(fileInfo.Item1, collection, fileInfo.Item2);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var trains = (Train[])MainTable.ItemsSource;
            if (trains == null)
            {
                trains = new Train[1];
                trains[0] = new Train();
            }
            else
            {
                Array.Resize(ref trains, trains.Length + 1);
                trains[^1] = new Train();
            }

            MainTable.ItemsSource = trains;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = MainTable.SelectedItem;
            if (selectedItem != null)
            {
                var trains = (Train[])MainTable.ItemsSource;
                var listOfTrains = trains.ToList();
                listOfTrains.Remove((Train)selectedItem);
                MainTable.ItemsSource = null;
                MainTable.ItemsSource = listOfTrains.ToArray();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MainTable.ItemsSource = null;
        }
    }
}
