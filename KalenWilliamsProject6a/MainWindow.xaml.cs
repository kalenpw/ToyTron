﻿//Kalen Williams
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KalenWilliamsProject6a {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        //Public variables
        ToyTronSource source;
        public MainWindow() {
            InitializeComponent();

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

            if ((bool)fileExplorer.ShowDialog()) {
                string fileName = fileExplorer.FileName;
                string[] fileLines = File.ReadAllLines(fileName);

                source = new ToyTronSource(fileLines);

                source.displaySourceCode();
            }
            else {
                MessageBox.Show("Error: Unable to load file. Please try again");
            }
            
            
        }

        //Run button
        private void btnRun_Click(object sender, RoutedEventArgs e) {
            List<Instruction> instructions = source.AllInstructions;
            for(int i=0; i < instructions.Count; i++) {
                instructions[i].doInstruction();
                incrementProgramCounter();
            }

        }

        //Step button
        private void btnStep_Click(object sender, RoutedEventArgs e) {
            List<Instruction> instructions = source.AllInstructions;
            instructions[0].doInstruction();
            instructions.RemoveAt(0);
            incrementProgramCounter();
        }

        //Reset button
        private void btnReset_Click(object sender, RoutedEventArgs e) {
            txtTronSourceCode.Text = "";
            tbRegOne.Text = 0.ToString();
            tbRegTwo.Text = 0.ToString();
            tbRegThree.Text = 0.ToString();
            tbRegFour.Text = 0.ToString();
            tbRegFive.Text = 0.ToString();
            tbRegSix.Text = 0.ToString();
            tbRegSeven.Text = 0.ToString();
            tbRegEight.Text = 0.ToString();
            clearMemory();
        }

        private void incrementProgramCounter() {
            int newValue = stringToInt(txtProgramCounter.Text) + 1;
            txtProgramCounter.Text = "0" + newValue.ToString();
        }

        private int stringToInt(String str) {
            int num = 0;
            bool isNum;
            isNum = int.TryParse(str, out num);
            if (isNum) {
                return num;
            }
            else {
                return -1;
            }
        }

        private void clearMemory() {
            int toPrint = 8;
            for(int i = 1; i < 93; i++) {
                txtMemory.Text += formatIntForNumber(toPrint) + " | ";
                if(i % 4 == 0) {
                    txtMemory.Text += "\r\n";
                }
                toPrint++;
            }
        }

        private String formatIntForNumber(int num) {
            String formatted = "";
            if (num < 10) {
                formatted = "0" + num.ToString();
            }
            else {
                formatted = num.ToString();
            }
            return formatted;
        }
    }
}
