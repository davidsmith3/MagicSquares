using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicSquares.Domain;

namespace MagicSquares.Console {
    class Program {
        static void Main(string[] args) {
            System.Console.WriteLine(new MagicSquare(9, "llur").ToString());
            System.Console.ReadLine();
        }
    }
}
