//Kalen Williams
//CS 3308
//Exercise 6a Toy Tron
//10 November 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//the store instruction
namespace KalenWilliamsProject6a {
    class Store : Instruction {
        //Fields
        private Register _SourceReg;
        private Memory _DestinationMem;

        //Constructors
        public Store(Register newSource, Memory newDestination) {
            this._SourceReg = newSource;
            this._DestinationMem = newDestination;
        }     

        //Performs a store operation
        //Stores an integer from the register indicated by the destination digits (0-8)
        //into the memory location indicated by the source digits(0-99).
        public override void doInstruction() {
            int registerValue = GlobalMemory.AllRegister[_SourceReg.RegisterNumber].Contents;
            GlobalMemory.AllMemory[_DestinationMem.MemoryNumber].Contents = registerValue;
        }
    }
}
