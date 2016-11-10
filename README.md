# ToyTron
ToyTron computers run on a non-existent machine
language called ToyTron machine code. The ToyTron uses decimal values with 8
registers (0-7) and 100 memory locations (0-99) that can store integers between -999999
and 999999. Registers are special memory locations inside the CPU on which the
computer can do special operations like adding, subtracting, etc. Note the 100 memory
locations must include all the lines in the ToyTron program as well as all the memory
used by that program. The ToyTron Computer assumes the first line of the program is at
location 0 in the memory.
A Foo-MaC instruction consists of 6 numeric digits mapped to three integers each having
values between 0 and 99. The left-most pair of digits is the instruction code that indicates
whether the ToyTron Computer is supposed to read or write something, move something
into or out of memory, etc. The middle pair of digits is the “source”, which is either a
memory location or a register depending on the instruction code, and the right most pair
of digits is the “destination” which also is either a memory location or register depending
on the instruction. Some instructions may not need either a source or destination; in that
case, the unneeded source or destination digits are set to zero.
<ul>
<li>50-Read. Reads an integer from the keyboard and places it into the location in
memory provided by the destination digits (0-99). The source digits are set to
zero. Thus, for example 500034 reads in an integer from the keyboard and places
that integer in memory location 34.
</li><li>51-Write. Displays an integer from the memory location indicated by the source
digits (0-99) in a message box.
</li><li>60-Load. Load an integer from the memory location indicated by the source
digits (0-99) into the register indicated by the destination digits (0-8). Thus,
603401 loads the integer in memory location 34 into register 1.
</li><li>61-Store. Stores an integer from the register indicated by the source digits (0-8) into the memory location indicated by the destination digits (0-99). Thus 610144 stores the contents of register 1 into memory location 44.
</li><li>70-Add. Adds the integer in the source register (0-8) to the integer in the
destination register (0-8) placing the results into the destination register. Thus,
700401 adds the integer in register 4 to the integer in register 1, placing the results
back into register 1.
</li><li>71-Subtract. Subtracts the integer in the source register (0-8) from the integer in
the destination register (0-8) placing the results into the destination register.
</li><li>80-Branch. Go to the destination memory location. The next instruction to be
executed is given by the right two most digits (e.g., the destination digits). Thus
800007 changes the program counter to 07, the next instruction to be executed.
</li><li>81-BranchNegative. If the register indicated by the source digits contains a
negative value, GoTo the memory location indicated by the destination digits; if
the register contains a zero or positive value, execute the instruction in the next
memory location. Thus 810007 will change the program counter to 07 IFF
register 0 contains a negative number.
</li><li>82-BranchZero. If the register indicated by the source digits contains a zero,
GoTo the memory location indicated by the destination digits; if the register
contains a non-zero, execute the instruction in the next memory location.
</li><li>83-Halt. Halts program
</ul>
