//Kalen Williams
//CS 3308
//Exercise 6b Toy Tron
//10 November 2016

//This class contains a globally accessible array containing all of the memory
//I feel like using this and also using the xaml for my registers are both poor form
//but it works so what the hell

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalenWilliamsProject6a {
    public static class GlobalMemory {
        static Memory[] _AllMemory = new Memory[100];
        static Register[] _AllRegister = new Register[8];

        static public void fillArrayWithZero() {
            for(int i=0; i < _AllMemory.Length; i++) {
                _AllMemory[i] = new Memory(i);
            }
        }

        static public void fillRegisterArrayWithZero() {
            for(int i =0; i < AllRegister.Length; i++) {
                AllRegister[i] = new Register(i);
            }
        }

        public static Memory[] AllMemory {
            get {
                return _AllMemory;
            }

            set {
                _AllMemory = value;
            }
        }

        internal static Register[] AllRegister {
            get {
                return _AllRegister;
            }

            set {
                _AllRegister = value;
            }
        }
    }
}
