﻿//Kalen Williams
//CS 3308
//Exercise 6a Toy Tron
//27 October 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//The write instruction
namespace KalenWilliamsProject6a {
    class Write : Instruction {
        private Register _SourceReg;
        private Register _DestinationReg;

        public Write(Register newSource, Register newDestination) {
            this._SourceReg = newSource;
            this._DestinationReg = newDestination;
        }

        public override void doInstruction() {
            throw new NotImplementedException();
        }
    }
}
