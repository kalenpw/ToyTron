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
//The halt command
namespace KalenWilliamsProject6a {
    class Halt : Instruction {
        public override void doInstruction() {
            MessageBox.Show("Program halted");
        }
    }
}
