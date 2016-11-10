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
//The write instruction
namespace KalenWilliamsProject6a {
    class Write : Instruction {
        private Memory _SourceMem;
        private Memory _DestinationMem;

        public Write(Memory newSource, Memory newDestination) {
            this._SourceMem = newSource;
            this._DestinationMem = newDestination;
        }

        //Performs instruction
        //Writes to messagebox
        public override void doInstruction() {
            MessageBox.Show(GlobalMemory.AllMemory[_SourceMem.MemoryNumber].Contents.ToString());
        }
    }
}
