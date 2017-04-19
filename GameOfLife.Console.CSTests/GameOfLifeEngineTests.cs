using GameOfLife.Console.CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

namespace GameOfLife.Console.CS.Tests
{
    [TestFixture]
    [SingleThreadedAttribute]
    public class GameOfLifeEngineTests
    {
        MockFileSystem _file; 

        [SetUp]
        public void Setup()
        {
            _file = new MockFileSystem();
            _file.AddFile("setup2.txt", new MockFileData("111/r/n111/r/n111"));
            _file.AddFile("setup1.txt", new MockFileData(" "));
        }
        [Test]
        public void RunTest_ShouldThrowExceptionIfSetupIsNotSpecified1()
        {
            // Arrange
            var game = new GameOfLifeEngine(new Strings(), _file);
            // Act
            TestDelegate act = () => game.Run(null);
            // Asset
            Assert.Throws<ArgumentNullException>(act);
        }

        [TestCase("")]
        [TestCase("file1.txt,file2.txt")]
        public void RunTest_ShouldThrowExceptionIfSetupIsNotProperlySpecified(string args)
        {
            // Arrange
            var game = new GameOfLifeEngine(new Strings(), _file);
            // Act
            TestDelegate act = () => game.Run(args.Split(','));
            // Asset
            Assert.Throws<ArgumentException>(act);
        }


        [Test]
        public void RunTest_LoadsTheFile()
        {
            // Arrange
            var fileName = "setup2.txt";
            var game = new GameOfLifeEngine(new Strings(), _file);
            // Act
            var result = game.Run(new string[] {fileName}).Status;
            // Asset
            Assert.AreEqual(fileName, result.FileName);
        }

    }
}