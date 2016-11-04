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

//Contains a copy of source code and a list of all instructions
//Kalen Williams 02 November 2016

namespace KalenWilliamsProject6a {
    class ToyTronSource {
        List<Instruction> _AllInstructions = new List<Instruction>();
        string[] _SourceCode;

        public ToyTronSource(string[] sourceTextFile) {
            _SourceCode = sourceTextFile;
        }

        public void displaySourceCode() {
            //http://stackoverflow.com/questions/17001486/how-to-access-wpf-mainwindow-controls-from-my-own-cs-file
            TextBlock sourceDisplay = ((MainWindow)System.Windows.Application.Current.MainWindow).txtTronSourceCode;
            sourceDisplay.Text = "";
            string formattedMemory;

            if (validateSourceCode(_SourceCode)) {
                for (int i = 0; i < _SourceCode.Length; i++) {
                    formattedMemory = i.ToString("D3");
                    sourceDisplay.Text += formattedMemory + " " + _SourceCode[i] + "\r\n";
                }
            }
            else {
                sourceDisplay.Text += "Error: Invalid source code.";
            }
            
        }   

        //Returns true if source code is valid, false if not valid
        //Valid = 6 numeric chars on each line
        private bool validateSourceCode(string[] code) {
            for(int i=0; i < code.Length; i++) {
                if(code[i].Length != 6) {
                    return false;
                }
                string[] lineOfCode = code[i].Split();
                for(int j = 0; j < lineOfCode.Length; j++) {
                    if (!isNumeric(lineOfCode[j])) {
                        if (lineOfCode[j] == "\r" || lineOfCode[j] == "\n" || lineOfCode[j] == "-") {
                            //Allow whitespace and entering negative numbers
                        }
                        else {
                            return false;
                        }
                    }
                }
            }


            return true;
        }

        private bool isNumeric(string str) {
            int number;
            bool isNumeric = int.TryParse(str, out number);
            return isNumeric;
        }

        private void getInstructions() {

        }


    }//End class
}
