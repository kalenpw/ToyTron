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

        public List<Instruction> AllInstructions {
            get {
                return _AllInstructions;
            }
        }

        public ToyTronSource(string[] sourceTextFile) {
            _SourceCode = sourceTextFile;
            fillInstructionList();
        }


        //Methods
        //Fills instruction list
        private void fillInstructionList() {
            for(int i = 0; i < _SourceCode.Length; i++) {
                AllInstructions.Add(deconstructInstruction(_SourceCode[i]));
                MessageBox.Show("added to instruction list " + AllInstructions[i].ToString());
            }
            
        }
        
        //Splits a complete instruction into its different parts
        private Instruction deconstructInstruction(String completeInstruction) {
            Instruction deconstructedInstruction = null;
            String instruction = "";
            String source = "";
            String destination = "";
            int instructionInt;
            int sourceInt;
            int destinationInt;

            for (int i = 0; i < 2; i++) {
                instruction += completeInstruction[i];
            }
            for (int i = 2; i < 4; i++) {
                source += completeInstruction[i];
            }
            for (int i = 4; i < 6; i++) {
                destination += completeInstruction[i];
            }

            instructionInt = stringToInt(instruction);
            sourceInt = stringToInt(source);
            destinationInt = stringToInt(destination);

            deconstructedInstruction = instructionFromInt(instructionInt, sourceInt, destinationInt);

            return deconstructedInstruction;

        }

        private Instruction instructionFromInt(int instructionNum, int source, int destination) {
            Instruction returnInstruction = null;
            switch (instructionNum) {
                case 70:
                    returnInstruction = new Add(new Register(source), new Register(destination));
                    break;
                case 51:
                    returnInstruction = new Write(new Register(source), new Register(destination));
                    break;

            }

            return returnInstruction;
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

        public void displaySourceCode() {
            //http://stackoverflow.com/questions/17001486/how-to-access-wpf-mainwindow-controls-from-my-own-cs-file
            TextBlock sourceDisplay = ((MainWindow)System.Windows.Application.Current.MainWindow).txtTronSourceCode;
            sourceDisplay.Text = "";
            string formattedMemory;

            if (validateSourceCode(_SourceCode)) {
                for (int i = 0; i < _SourceCode.Length; i++) {
                    formattedMemory = i.ToString("D2");
                    sourceDisplay.Text += formattedMemory + "   " + _SourceCode[i] + "\r\n";
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
