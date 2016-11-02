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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KalenWilliamsProject6a {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            txtTronSourceCode.Text = "This will eventually display the source code of a toy tron program and highlight each line of code when it is stepped into";

            //Fill stack panel with register values
            for(int i = 0; i < 8; i++) {
                TextBlock register = new TextBlock();
                register.Text = "Register 0" + i + ":";
                stkRegisters.Children.Add(register);
            }
        }

        //Button to open an editor
        private void btnEdit_Click(object sender, RoutedEventArgs e) {
            Editor toyTronEditor = new Editor();
            toyTronEditor.Show();
            
        }

        //Exit button
        private void btnExit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        //Load text file
        private void btnLoad_Click(object sender, RoutedEventArgs e) {
            Microsoft.Win32.OpenFileDialog fileExplorer = new Microsoft.Win32.OpenFileDialog();
            fileExplorer.DefaultExt = ".txt";
            fileExplorer.Filter = "TronCode (*.txt)|*.txt|All files (*.*)|*.*";
            fileExplorer.ShowDialog();
            
        }

        //Run button
        private void btnRun_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("This will eventually run a Toy Tron program");
        }

        //Step button
        private void btnStep_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("This will eventually step through steps of a Toy Tron program");
        }
    }
}
