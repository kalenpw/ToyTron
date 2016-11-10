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
//The add instruction
namespace KalenWilliamsProject6a {
    class Subtract : Instruction {
        //Fields
        private Register _SourceReg;
        private Register _DestinationReg;

        //Constructors
        public Subtract(Register sourceReg, Register destinationReg) {
            this._SourceReg = sourceReg;
            this._DestinationReg = destinationReg;
        }

        //Performs an instruction
        //Subtract source reg from Destination reg saving result in destination
        //Kalen Williams 08 November 2016
        public override void doInstruction() {
            int diff = GlobalMemory.AllRegister[_DestinationReg.RegisterNumber].Contents - GlobalMemory.AllRegister[_SourceReg.RegisterNumber].Contents;
            GlobalMemory.AllRegister[_DestinationReg.RegisterNumber].Contents = diff;
        }

     
    }
}
