//Kalen Williams
//CS 3308
//Exercise 6a Toy Tron
//10 November 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Memory class contains the location and contents of a memory address
//Kalen Williams 10 November 2016

namespace KalenWilliamsProject6a {
    public class Memory {
        //Fields
        int _MemoryNumber;
        int _Contents;
     
        //Constructors
        public Memory(int memNumber) {
            this._MemoryNumber = memNumber;
        }

        //Properties
        public int MemoryNumber {
            get {
                return _MemoryNumber;
            }

            set {
                _MemoryNumber = value;
            }
        }

        public int Contents {
            get {
                return _Contents;
            }

            set {
                _Contents = value;
            }
        }

    }
}
