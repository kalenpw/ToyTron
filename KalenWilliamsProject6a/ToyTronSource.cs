//Kalen Williams
//CS 3308
//Exercise 6a Toy Tron
//10 November 2016

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
        //Fields
        List<Instruction> _AllInstructions = new List<Instruction>();
        string[] _SourceCode;

        //Constructor
        public ToyTronSource(string[] sourceTextFile) {
            _SourceCode = sourceTextFile;
            fillInstructionList();
        }

        //Properties
        public List<Instruction> AllInstructions {
            get {
                return _AllInstructions;
            }
        }

        //Methods
        //Fills instruction list
        //Kalen Williams 10 November 2016
        private void fillInstructionList() {
            for(int i = 0; i < _SourceCode.Length; i++) {
                AllInstructions.Add(deconstructInstruction(_SourceCode[i]));
            }     
        }
        
        //Splits a complete instruction into its different parts
        //Kalen Williams 10 November 2016
        private Instruction deconstructInstruction(String completeInstruction) {
            Instruction deconstructedInstruction = null;
            String instruction = "";
            String source = "";
            String destination = "";
            int instructionInt;
            int sourceInt;
            int destinationInt;
            if (completeInstruction.Length == 6) {

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
            //If syntax error set instruction to halt.
            else {
                return new Halt();
            }

        }

        //Gets an instruction from int(opcode)
        //Kalen Williams 10 November 2016
        private Instruction instructionFromInt(int instructionNum, int source, int destination) {
            Instruction returnInstruction = null;
            switch (instructionNum) {
                case 70:
                    returnInstruction = new Add(new Register(source), new Register(destination));
                    break;
                case 71:
                    returnInstruction = new Subtract(new Register(source), new Register(destination));
                    break;
                case 50:
                    returnInstruction = new Read(new Memory(source), new Memory(destination));
                    break;
                case 51:
                    returnInstruction = new Write(new Memory(source), new Memory(destination));
                    break;
                case 83:
                    returnInstruction = new Halt();
                    break;
                case 60:
                    returnInstruction = new Load(new Memory(source), new Register(destination));
                    break;
                case 61:
                    returnInstruction = new Store(new Register(source), new Memory(destination));
                    break;
                //Branches
                //Not implemented


            }

            return returnInstruction;
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

        //Displays source code to main window
        //Kalen Williams 03 November 2016
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
        //Note doesn't work with negatives, yet
        //Kalen Williams 04 November 2016
        private bool validateSourceCode(string[] code) {
            for(int i=0; i < code.Length; i++) {
                if(code[i].Length != 6) {
                    return false;
                }
                string[] lineOfCode = code[i].Split();
                for(int j = 0; j < lineOfCode.Length; j++) {
                    if (!isNumeric(lineOfCode[j])) {
                        if (lineOfCode[j] == "\r" || lineOfCode[j] == "\n") {
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

        //Checks if a string is an integer
        //Kalen Williams 03 November 2016
        private bool isNumeric(string str) {
            int number;
            bool isNumeric = int.TryParse(str, out number);
            return isNumeric;
        }


    }
}
