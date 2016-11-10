//Kalen Williams
//CS 3308
//Exercise 6b Toy Tron
//10 November 2016

////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////// NOTES FOR GRADER /////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////
/*
I don't have any of the branches working.
As you can see my memory doesn't line up properly with the headings and is kinda mess to look at
    as such the scroll bars aren't used 
My source code doesn't handle negative numbers
Trailing whitespace at the end of source code file causes a halt command to be put in there
*/

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
        Memory[] allMem = new Memory[100];

        public MainWindow() {
            InitializeComponent();
            lblMemTensDigit.Content = "00\r\n10\r\n20\r\n30\r\n40\r\n50\r\n60\r\n70\r\n80\r\n90";
            GlobalMemory.fillArrayWithZero();
            GlobalMemory.fillRegisterArrayWithZero();
            updateMemoryDisplay();
            updateRegisterDisplay();
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

        //button to load text file
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
            int delay = checkForDelay();
            for (int i = 0; i < instructions.Count; i++) {
                instructions[i].doInstruction();
                updateRegisterDisplay();
                updateMemoryDisplay();
                incrementProgramCounter();
                System.Threading.Thread.Sleep(delay);
            }

        }

        //Step button
        private void btnStep_Click(object sender, RoutedEventArgs e) {
            List<Instruction> instructions = source.AllInstructions;
            if (instructions.Count == 0) {
                //Don't do anything if ran through all instructions
            }
            else {
                instructions[0].doInstruction();
                instructions.RemoveAt(0);
                updateRegisterDisplay();
                updateMemoryDisplay();
                incrementProgramCounter();
            }
        }

        //Reset button
        private void btnReset_Click(object sender, RoutedEventArgs e) {
            GlobalMemory.fillArrayWithZero();
            GlobalMemory.fillRegisterArrayWithZero();
            updateMemoryDisplay();
            updateRegisterDisplay();
        }

        //Checks if a delay has been entered
        //Kalen Williams 10 November 2016
        private int checkForDelay() {
            String typedInBox = txtDelay.Text;
            int delay = 0;
            if (isNumeric(typedInBox)) {
                delay = stringToInt(typedInBox);
            }
            return delay;
        }

        //Displays the memory
        //Kalen Williams 10 November 2016]
        public void updateMemoryDisplay() {
            txtMemory.Text = "";
            //The minus one/plus one nonsense is to make the mod 10 division workout
            //and display in a nice table
            for(int i=1; i < GlobalMemory.AllMemory.Length+1; i++) {
                txtMemory.Text += GlobalMemory.AllMemory[i-1].Contents + " ";
                if(i % 10 == 0) {
                    txtMemory.Text += "\r\n";
                }
            }
        }


        //Increments program counter
        //Kalen Williams 10 November 2016
        private void incrementProgramCounter() {
            int newValue = stringToInt(txtProgramCounter.Text) + 1;
            txtProgramCounter.Text = "0" + newValue.ToString();
        }

        //Converts a string to an int
        //Kalen Williams 10 November 2016
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

        //Updates the values in registers
        //Kalen Williams 10 November 2016
        private void updateRegisterDisplay() {
            for(int i=0; i < GlobalMemory.AllRegister.Length; i++) {
                getTextBlockFromInt(i).Text = GlobalMemory.AllRegister[i].Contents.ToString();
            }

        }

        //Returns the corresponding textblock from a register's int value
        //Kalen Williams 08 November 2016
        private TextBlock getTextBlockFromInt(int value) {
            switch (value) {
                case 0:
                    return ((MainWindow)System.Windows.Application.Current.MainWindow).tbRegOne;
                case 1:
                    return ((MainWindow)System.Windows.Application.Current.MainWindow).tbRegTwo;
                case 2:
                    return ((MainWindow)System.Windows.Application.Current.MainWindow).tbRegThree;
                case 3:
                    return ((MainWindow)System.Windows.Application.Current.MainWindow).tbRegFour;
                case 4:
                    return ((MainWindow)System.Windows.Application.Current.MainWindow).tbRegFive;
                case 5:
                    return ((MainWindow)System.Windows.Application.Current.MainWindow).tbRegSix;
                case 6:
                    return ((MainWindow)System.Windows.Application.Current.MainWindow).tbRegSeven;
                case 7:
                    return ((MainWindow)System.Windows.Application.Current.MainWindow).tbRegEight;
                default:
                    return ((MainWindow)System.Windows.Application.Current.MainWindow).tbRegOne;
            }
        }

        //Checks if a string is an integer
        //Kalen Williams 03 November 2016
        private bool isNumeric(string str) {
            int number;
            bool isNumeric = int.TryParse(str, out number);
            return isNumeric;
        }


    }
}
