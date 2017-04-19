using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace GameOfLife.Console.CS
{
    class Program
    {
        static void Main(string[] args)
        {
            new GameOfLifeEngine(new Strings(), new FileSystem()).Run(args);
        }
    }
}
