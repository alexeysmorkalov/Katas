using System;
using System.IO.Abstractions;

namespace GameOfLife.Console.CS
{
    public class GameOfLifeEngine
    {
        readonly IStrings _strings;
        readonly IFileSystem _file;
        readonly GameStatus _status;

        public GameOfLifeEngine(IStrings strings, IFileSystem file)
        {
            _file = file;
            _strings = strings;
            _status = new GameStatus();
        }

        public GameStatus Status => _status;
        IStrings Strings => _strings;
        IFileSystem File => _file;

        public GameOfLifeEngine Run(string[] args)
        {
            if (args == null) throw new ArgumentNullException(Strings.SetupFileMustBeSpecified);
            if (args.Length == 0) throw new ArgumentException(Strings.SetupFileMustBeSpecified);
            if (args.Length > 1) throw new ArgumentException(Strings.OnlySetupFileMustBeSpecified);
            string fileName = args[0];
            if (fileName == "") throw new ArgumentException(Strings.SetupFileMustBeSpecified);
            if (File.File.Exists(fileName))
            {
                Load(File.File.ReadAllText(fileName));
                Status.FileName = fileName;
            }
            return this;
        }

        public void Load(string data)
        {

        }
    }
}