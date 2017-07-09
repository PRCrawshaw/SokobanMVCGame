using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SokobanConsoleGame;

namespace SokobanConsoleGameTest
{
    [TestClass]
	public class GameMoveUnitTests
	{
        protected iLoader Loader;
        protected iSaver Saver;
        protected iConverter Converter;
        protected iChecker Checker;
        [TestInitialize]
        public void Initialize()
        {
            // Loader = new Loader();    
        }
        [TestMethod]
        public void TestPly01PlayerNoLongerThereIfMovedUp()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game("####\n#  #\n#@ #\n####");
            // act 
            game.Move(Direction.Up);
            // assert
            Position pos = new Position(3-1, 2-1);
            Parts actual3_2 = game.GetMovable(pos);
            Parts expected3_2 = Parts.Empty;
            Assert.AreEqual(actual3_2, expected3_2, "The player is unmoved after being told to go up");
        }
        [TestMethod]
        public void TestPly02PlayerWhereExpectedIfMovedUp()
        {
            // player starts at row 3 column 2 
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game("####\n#  #\n#@ #\n####");
            // act
            game.Move(Direction.Up);
            //assert 
            Parts actual2_2 = game.WhatsAt(2-1, 2-1);
            Parts expected2_2 = Parts.Player;
            Assert.AreEqual(actual2_2, expected2_2, "The player is not where expected after being told to go up");
        }
        [TestMethod]
        public void TestPly03BlockWhereExpectedIfPlayerPushedUp()
        {
            // player starts at row 4 column 2 
            // block starts at row 3 column 2
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game("####\n#  #\n#$ #\n#@ #\n####");
            // act
            game.Move(Direction.Up);
            //assert 
            Parts actual2_2 = game.WhatsAt(2 - 1, 2 - 1);
            Parts expected2_2 = Parts.Block;
            Assert.AreEqual(actual2_2, expected2_2, "The player is not where expected after being told to go up");
        }
    }      
}
