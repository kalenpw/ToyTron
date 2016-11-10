//Kalen Williams
//CS 3308
//Exercise 6a Toy Tron
//27 October 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This class will be used for each toy tron instruction and execute them
namespace KalenWilliamsProject6a {
    public abstract class Instruction {
        private int _InstructionCode;
        private int _Source;
        private int _Destination;

        abstract public void doInstruction();

    }
}
