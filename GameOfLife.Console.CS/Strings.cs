using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Console.CS
{
    public interface IStrings
    {
        string SetupFileMustBeSpecified { get; }
        string OnlySetupFileMustBeSpecified { get; }
    }

    public class Strings : IStrings
    {
        public string SetupFileMustBeSpecified { get; } = @"Setup file name must be specified";
        public string OnlySetupFileMustBeSpecified { get; } = @"Only setup file name must be specified";
    }
}
