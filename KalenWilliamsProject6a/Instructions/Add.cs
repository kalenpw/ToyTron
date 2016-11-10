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
//The add instruction
namespace KalenWilliamsProject6a {
    class Add : Instruction {
        //Fields
        private String _CompleteInstruction;
        private int _InstructionCode;
        private int _Source;
        private int _Destination;
        private Register _SourceReg;
        private Register _DestinationReg;

        //Constructors
        public Add(Register sourceReg, Register destinationReg) {
            this._SourceReg = sourceReg;
            this._DestinationReg = destinationReg;
            fillInitialRegisterValues();


        }

        //Properties
        public int InstructionCode {
            get {
                return _InstructionCode;
            }

            set {
                _InstructionCode = value;
            }
        }

        public int Source {
            get {
                return _Source;
            }

            set {
                _Source = value;
            }
        }

        public int Destination {
            get {
                return _Destination;
            }

            set {
                _Destination = value;
            }
        }


        //Methods


        public override void doInstruction() {
            int result = _SourceReg.Contents + _DestinationReg.Contents;
            _DestinationReg.Contents = result;
            updateDisplayRegisters();
        }

        private void fillInitialRegisterValues() {
            _SourceReg.Contents = stringToInt(getTextBlockFromInt(_SourceReg.RegisterNumber).Text);
            _DestinationReg.Contents = stringToInt(getTextBlockFromInt(_DestinationReg.RegisterNumber).Text);

        }

        private void updateDisplayRegisters() {
            getTextBlockFromInt(_SourceReg.RegisterNumber).Text = _SourceReg.Contents.ToString();
            getTextBlockFromInt(_DestinationReg.RegisterNumber).Text = _DestinationReg.Contents.ToString();

        }

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


    }
}
