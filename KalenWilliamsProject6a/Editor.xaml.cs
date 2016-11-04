//Kalen Williams
//CS 3308
//Exercise 6a Toy Tron
//27 October 2016

using System;
using System.Collections.Generic;
using System.IO;
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

//Code for the Editor form
//Kalen Williams 02 November 2016

namespace KalenWilliamsProject6a {
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : Window {
        public Editor() {
            InitializeComponent();
            dock.LastChildFill = true;
            txtEditor.VerticalAlignment = VerticalAlignment.Stretch;
            txtEditor.HorizontalAlignment = HorizontalAlignment.Stretch;
            txtEditor.Text = "Tron Source Code";
            txtEditor.AcceptsReturn = true;
        }

        

        //Closes editor window
        private void btnExit_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        //Load button
        private void btnLoad_Click(object sender, RoutedEventArgs e) {
            Stream streamWriter = null;
            Microsoft.Win32.OpenFileDialog fileExplorer = new Microsoft.Win32.OpenFileDialog();
            fileExplorer.DefaultExt = ".txt";
            fileExplorer.Filter = "TronCode (*.txt)|*.txt|All files (*.*)|*.*";

            if ((bool)fileExplorer.ShowDialog()) {
                if((streamWriter = fileExplorer.OpenFile()) != null) {
                    using (streamWriter) {
                        txtEditor.Text = File.ReadAllText(fileExplorer.FileName);
                    }
                }
            }
            
            

        }

        //Save button
        private void btnSave_Click(object sender, RoutedEventArgs e) {
            Microsoft.Win32.SaveFileDialog saveFile = new Microsoft.Win32.SaveFileDialog();
            saveFile.DefaultExt = ".txt";
            saveFile.Filter = "TronCode (*.txt)|*.txt|All files (*.*)|*.*";

            if((bool)saveFile.ShowDialog()) {
                StreamWriter writer = new StreamWriter(saveFile.OpenFile());
                writer.WriteLine(txtEditor.Text);
                writer.Dispose();
                writer.Close();
            }
            else {
                MessageBox.Show("Error: Unable to save file. Please try again.");
            }
        }
    }
}
