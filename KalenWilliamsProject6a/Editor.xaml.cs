//Kalen Williams
//CS 3308
//Exercise 6a Toy Tron
//27 October 2016

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
using System.Windows.Shapes;

namespace KalenWilliamsProject6a {
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : Window {
        public Editor() {
            InitializeComponent();
        }

        //Closes editor window
        private void btnExit_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        //Load button
        private void btnLoad_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("This will eventually be used to load a .txt file containing toy tron code");
            Microsoft.Win32.OpenFileDialog fileExplorer = new Microsoft.Win32.OpenFileDialog();
            fileExplorer.DefaultExt = ".txt";
            fileExplorer.Filter = "TronCode (*.txt)|*.txt|All files (*.*)|*.*";
            fileExplorer.ShowDialog();

        }

        //Save button
        private void btnSave_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("This will eventually be used to save a .txt file containing toy tron code");
            Microsoft.Win32.SaveFileDialog saveFile = new Microsoft.Win32.SaveFileDialog();
            saveFile.DefaultExt = ".txt";
            saveFile.Filter = "TronCode (*.txt)|*.txt|All files (*.*)|*.*";
            saveFile.ShowDialog();
        }
    }
}
