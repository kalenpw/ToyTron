//Kalen Williams
//CS 3308
//Exercise 6a Toy Tron
//27 October 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Represents a register
namespace KalenWilliamsProject6a {
    class Register {
        int _RegisterNumber;
        int _Contents;

        public Register(int regNumber) {
            this._RegisterNumber = regNumber;
        }

        public int RegisterNumber {
            get {
                return _RegisterNumber;
            }

            set {
                _RegisterNumber = value;
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
