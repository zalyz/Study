using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for FileDialog.xaml
    /// </summary>
    public partial class FileDialog : Window
    {
        public string fileName;

        public static FileDialog FileDialogWindow { get; private set; }

        public FileDialog()
        {
            InitializeComponent();
            fileName = null;
            FileDialogWindow = this;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (CSV.IsChecked == true)
            {
                Binary.IsChecked = false;
                XML.IsChecked = false;
                JSON.IsChecked = false;
                fileName = "File1.csv";
            }

            if (Binary.IsChecked == true)
            {
                CSV.IsChecked = false;
                XML.IsChecked = false;
                JSON.IsChecked = false;
                fileName = "File2.bin";
            }

            if (XML.IsChecked == true)
            {
                CSV.IsChecked = false;
                Binary.IsChecked = false;
                JSON.IsChecked = false;
                fileName = "File3.xml";
            }

            if(JSON.IsChecked == true)
            {
                CSV.IsChecked = false;
                Binary.IsChecked = false;
                XML.IsChecked = false;
                fileName = "File4.json";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
