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
    /// Interaction logic for UserInput.xaml
    /// </summary>
    public partial class UserInput : Window {
        //Fields
        Memory _DestinationReg;

        //Constructors
        public UserInput(ref Memory destinationReg) {
            InitializeComponent();
            tbPrompt.Text = "Please enter a value for memory address " + destinationReg.MemoryNumber;
            this._DestinationReg = destinationReg;
        }

        //Button to submit number
        //Kalen Williams 10 November 2016
        private void btnSubmit_Click(object sender, RoutedEventArgs e) {
            String userInput = txtInput.Text;
            if (isNumeric(userInput)) {
                GlobalMemory.AllMemory[_DestinationReg.MemoryNumber].Contents = stringToInt(userInput);
                this.Close();
            }
            else {
                MessageBox.Show("Error: Please enter an integer.");
            }
        }

        //Converts a string to an integer
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

        //Checks if a string is an integer
        //Kalen Williams 10 November 2016
        private bool isNumeric(string str) {
            int number;
            bool isNumeric = int.TryParse(str, out number);
            return isNumeric;
        }

    }
}
