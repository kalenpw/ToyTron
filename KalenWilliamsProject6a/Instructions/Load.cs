//Kalen Williams
//CS 3308
//Exercise 6a Toy Tron
//10 November 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//The load instruction
namespace KalenWilliamsProject6a {
    class Load : Instruction {
        //Fields
        private Memory _SourceMem;
        private Register _DestinationReg;

        //Constructors
        public Load(Memory newSource, Register newDestination) {
            this._SourceMem = newSource;
            this._DestinationReg = newDestination;

        }

        //Performs the instruction
        public override void doInstruction() {
            int valueFromMem = GlobalMemory.AllMemory[_SourceMem.MemoryNumber].Contents;
            GlobalMemory.AllRegister[_DestinationReg.RegisterNumber].Contents = valueFromMem;
        }
    }
}
