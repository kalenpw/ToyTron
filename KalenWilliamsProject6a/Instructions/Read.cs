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

//The read instruction 
namespace KalenWilliamsProject6a {
    class Read : Instruction {
        Memory _SourceMem;
        Memory _DestinationMem;

        public Read(Memory sourceMem, Memory destinationMem) {
            this._SourceMem = sourceMem;
            this._DestinationMem = destinationMem;
        }

        //Reads in an instruction from user to be saved in memory address
        //Kalen Williams 10 November 2016
        public override void doInstruction() {
            UserInput inputForm = new UserInput(ref _DestinationMem);
            inputForm.ShowDialog();
        }
    }
}
