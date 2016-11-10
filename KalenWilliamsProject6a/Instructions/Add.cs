//Kalen Williams
//CS 3308
//Exercise 6a Toy Tron
//10 October 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KalenWilliamsProject6a {
    class Add : Instruction {
        //Fields
        private Register _SourceReg;
        private Register _DestinationReg;

        //Constructors
        public Add(Register sourceReg, Register destinationReg) {
            this._SourceReg = sourceReg;
            this._DestinationReg = destinationReg;
            //fillInitialRegisterValues();
        }

        //Performs an instruction
        //Kalen Williams 08 November 2016
        public override void doInstruction() {
            int sum = GlobalMemory.AllRegister[_SourceReg.RegisterNumber].Contents + GlobalMemory.AllRegister[_DestinationReg.RegisterNumber].Contents;
            GlobalMemory.AllRegister[_DestinationReg.RegisterNumber].Contents = sum;

        }

        
    }
}
