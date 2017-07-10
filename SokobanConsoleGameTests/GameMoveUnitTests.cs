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
        protected Converter Converter = new Converter();
        protected iChecker Checker;
        public const int OFFSET = 1;
        [TestMethod]
        public void TestLoad01IncorrectGameStringSent()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            bool expected = false;
            // act 
            bool actual = game.Load("#######\n#  #\n#@ #\n####");
            // assert
            Assert.AreEqual(actual, expected, 
                "The game accepted and invalid string");
        }
        [TestMethod]
        public void TestLoad02ValidGameStringSent()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            bool expected = false;
            // act 
            bool actual = game.Load("####\n#  #\n#@ #\n####");
            // assert
            Assert.AreEqual(actual, expected, 
                "The game did not accept a valid string");
        }
        [TestMethod]
        public void TestPly01PlayerNoLongerThereIfMovedUp()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("####\n# .#\n#@$#\n####");
            // act 
            game.Move(Direction.Up);
            // assert
            Position pos = new Position(3 - OFFSET, 2- OFFSET);
            Parts actual3_2 = game.GetMovable(pos);
            Parts expected3_2 = Parts.Empty;
            Assert.AreEqual(actual3_2, expected3_2, 
                "The player is unmoved after being told to go up");
        }
        [TestMethod]
        public void TestPly02PlayerWhereExpectedIfMovedUp()
        {
            // player starts at row 3 column 2 
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("####\n# .#\n#@$#\n####");
            // act
            game.Move(Direction.Up);
            //assert 
            Parts actual2_2 = game.WhatsAt(2- OFFSET, 2- OFFSET);
            Parts expected2_2 = Parts.Player;
            Assert.AreEqual(actual2_2, expected2_2, 
                "The player is not where expected after being told to go up");
        }
        [TestMethod]
        public void TestPly03PlayerNoLongerThereIfMovedDown()
        {
            //player starts at row 2 column 2
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("####\n#@.#\n# $#\n####");
            // act 
            game.Move(Direction.Down);
            // assert
            Position pos = new Position(2 - OFFSET, 2 - OFFSET);
            Parts actual2_2 = game.GetMovable(pos);
            Parts expected2_2 = Parts.Empty;
            Assert.AreEqual(actual2_2, expected2_2,
                "The player is unmoved after being told to go down");
        }
        [TestMethod]
        public void TestPly04PlayerWhereExpectedIfMovedDown()
        {
            // player starts at row 2 column 2 
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("####\n#@.#\n# $#\n####");
            // act
            game.Move(Direction.Down);
            //assert 
            Parts actual3_2 = game.WhatsAt(3 - OFFSET, 2 - OFFSET);
            Parts expected3_2 = Parts.Player;
            Assert.AreEqual(actual3_2, expected3_2,
                "The player is not where expected after being told to go down");
        }
        [TestMethod]
        public void TestPly05PlayerNoLongerThereIfMovedLeft()
        {
            //player starts at row 2 column 3
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("####\n# @#\n#.$#\n####");
            // act 
            game.Move(Direction.Left);
            // assert
            Position pos = new Position(2 - OFFSET, 3 - OFFSET);
            Parts actual2_3 = game.GetMovable(pos);
            Parts expected2_3 = Parts.Empty;
            Assert.AreEqual(actual2_3, expected2_3,
                "The player is unmoved after being told to go left");
        }
        [TestMethod]
        public void TestPly06PlayerWhereExpectedIfMovedLeft()
        {
            // player starts at row 2 column 3 
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("####\n# @#\n#.$#\n####");
            // act
            game.Move(Direction.Left);
            //assert 
            Parts actual2_2 = game.WhatsAt(2 - OFFSET, 2 - OFFSET);
            Parts expected2_2 = Parts.Player;
            Assert.AreEqual(actual2_2, expected2_2,
                "The player is not where expected after being told to go left");
        }
        [TestMethod]
        public void TestPly07PlayerNoLongerThereIfMovedRight()
        {
            //player starts at row 2 column 2
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("####\n#@ #\n#.$#\n####");
            // act 
            game.Move(Direction.Right);
            // assert
            Position pos = new Position(2 - OFFSET, 2 - OFFSET);
            Parts actual2_2 = game.GetMovable(pos);
            Parts expected2_2 = Parts.Empty;
            Assert.AreEqual(actual2_2, expected2_2,
                "The player is unmoved after being told to go right");
        }
        [TestMethod]
        public void TestPly08PlayerWhereExpectedIfMovedRight()
        {
            // player starts at row 2 column 2 
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("####\n#@ #\n#.$#\n####");
            // act
            game.Move(Direction.Right);
            //assert 
            Parts actual2_3 = game.WhatsAt(2 - OFFSET, 3 - OFFSET);
            Parts expected2_3 = Parts.Player;
            Assert.AreEqual(actual2_3, expected2_3,
                "The player is not where expected after being told to go right");
        }
        [TestMethod]
        public void TestPly09BlockWhereExpectedIfPlayerPushedUp()
        {
            // player starts at row 4 column 3 
            // block starts at row 3 column 3
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("#####\n#  .#\n# $ #\n# @ #\n#####");
            // act
            game.Move(Direction.Up);
            //assert 
            // block should be at row 2 column 3
            Parts actual2_3 = game.WhatsAt(2 - OFFSET, 3 - OFFSET);
            Parts expected2_3 = Parts.Block;
            Assert.AreEqual(actual2_3, expected2_3, 
                "The block is not where expected after being pushed to go up");
        }
        [TestMethod]
        public void TestPly10BlockBecomesBlockOnGoalIfPlayerPushedUp()
        {
            // player starts at row 4 column 3 
            // block starts at row 3 column 3
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("#####\n# . #\n# $ #\n# @ #\n#####");
            // act
            game.Move(Direction.Up);
            //assert 
            // block should be at row 2 column 3
            Parts actual2_3 = game.WhatsAt(2 - OFFSET, 3 - OFFSET);
            Parts expected2_3 = Parts.BlockOnGoal;
            Assert.AreEqual(actual2_3, expected2_3, "The block has not become block on goal after being pushed to go up");
        }
        [TestMethod]
        public void TestPly11BlockWhereExpectedIfPlayerPushedDown()
        {
            // player starts at row 2 column 3 
            // block starts at row 3 column 3
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("#####\n# @ #\n# $ #\n#  .#\n#####");
            // act
            game.Move(Direction.Down);
            //assert 
            // block should be at row 4 column 3
            Parts actual4_3 = game.WhatsAt(4 - OFFSET, 3 - OFFSET);
            Parts expected4_3 = Parts.Block;
            Assert.AreEqual(actual4_3, expected4_3, 
                "The block is not where expected after being pushed to go down");
        }
        [TestMethod]
        public void TestPly12BlockBecomesBlockOnGoalIfPlayerPushedDown()
        {
            // player starts at row 2 column 3 
            // block starts at row 3 column 3
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("#####\n# @ #\n# $ #\n# . #\n#####");
            // act
            game.Move(Direction.Down);
            //assert 
            // block should be at row 4 column 3
            Parts actual4_3 = game.WhatsAt(4 - OFFSET, 3 - OFFSET);
            Parts expected4_3 = Parts.BlockOnGoal;
            Assert.AreEqual(actual4_3, expected4_3, 
                "The block has not become block on goal after being pushed to go down");
        }
        [TestMethod]
        public void TestPly13BlockWhereExpectedIfPlayerPushedLeft()
        {
            // player starts at row 3 column 4 
            // block starts at row 3 column 3
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("#####\n#   #\n# $@#\n#  .#\n#####");
            // act
            game.Move(Direction.Left);
            //assert 
            // block should be at row 3 column 2
            Parts actual3_2 = game.WhatsAt(3 - OFFSET, 2 - OFFSET);
            Parts expected3_2 = Parts.Block;
            Assert.AreEqual(actual3_2, expected3_2, 
                "The block is not where expected after being pushed to go left");
        }
        [TestMethod]
        public void TestPly14BlockBecomesBlockOnGoalIfPlayerPushedLeft()
        {
            // player starts at row 3 column 4 
            // block starts at row 3 column 3
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("#####\n#   #\n#.$@#\n#   #\n#####");
            // act
            game.Move(Direction.Left);
            //assert 
            // block should be at row 3 column 2
            Parts actual3_2 = game.WhatsAt(3 - OFFSET, 2 - OFFSET);
            Parts expected3_2 = Parts.BlockOnGoal;
            Assert.AreEqual(actual3_2, expected3_2, 
                "The block has not become block on goal after being pushed to go left");
        }
        [TestMethod]
        public void TestPly15BlockWhereExpectedIfPlayerPushedRight()
        {
            // player starts at row 3 column 2 
            // block starts at row 3 column 3
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("#####\n#   #\n#@$ #\n#  .#\n#####");
            // act
            game.Move(Direction.Right);
            //assert 
            // block should be at row 3 column 4
            Parts actual3_4 = game.WhatsAt(3 - OFFSET, 4 - OFFSET);
            Parts expected3_4 = Parts.Block;
            Assert.AreEqual(actual3_4, expected3_4, 
                "The block is not where expected after being pushed to go right");
        }
        [TestMethod]
        public void TestPly16BlockBecomesBlockOnGoalIfPlayerPushedRight()
        {
            // player starts at row 3 column 2 
            // block starts at row 3 column 3
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("#####\n#   #\n#@$.#\n#   #\n#####");
            // act
            game.Move(Direction.Right);
            //assert 
            // block should be at row 3 column 4
            Parts actual3_4 = game.WhatsAt(3 - OFFSET, 4 - OFFSET);
            Parts expected3_4 = Parts.BlockOnGoal;
            Assert.AreEqual(actual3_4, expected3_4, 
                "The block has not become block on goal after being pushed to go right");
        }
        [TestMethod]
        public void TestPly17PlayerUnableToGoIntoAWallUp()
        {
            // player starts at row 2 column 3 
            // block starts at row 3 column 3
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("#####\n# @ #\n# $ #\n#  .#\n#####");
            // act
            bool actual = game.Move(Direction.Up);
            //assert 
            bool expected = false;
            Assert.AreEqual(actual, expected,
                "The player is unable to go into a wall upwards.");
        }
        [TestMethod]
        public void TestPly18PlayerUnableToGoIntoAWallDown()
        {
            // player starts at row 2 column 3 
            // block starts at row 3 column 3
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("#####\n#   #\n# $ #\n# @.#\n#####");
            // act
            bool actual = game.Move(Direction.Down);
            //assert 
            bool expected = false;
            Assert.AreEqual(actual, expected,
                "The player is unable to go into a wall downwards.");
        }
        [TestMethod]
        public void TestPly19PlayerUnableToGoIntoAWallLeft()
        {
            // player starts at row 2 column 3 
            // block starts at row 3 column 3
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("#####\n#   #\n# $ #\n#@ .#\n#####");
            // act
            bool actual = game.Move(Direction.Left);
            //assert 
            bool expected = false;
            Assert.AreEqual(actual, expected,
                "The player is unable to go into a wall leftwards.");
        }
        [TestMethod]
        public void TestPly20PlayerUnableToGoIntoAWallRight()
        {
            // player starts at row 2 column 3 
            // block starts at row 3 column 3
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("#####\n#  @#\n# $ #\n#  .#\n#####");
            // act
            bool actual = game.Move(Direction.Right);
            //assert 
            bool expected = false;
            Assert.AreEqual(actual, expected,
                "The player is unable to go into a wall rightwards.");
        }
        [TestMethod]
        public void TestPly20BlockUnableToBePushedIntoAWallUp()
        {
            // player starts at row 2 column 3 
            // block starts at row 3 column 3
            Filer filer = new Filer(Loader, Saver, Converter, Checker);
            Game game = new Game(filer);
            game.Load("#####\n# $ #\n# @ #\n#  .#\n#####");
            // act
            bool actual = game.Move(Direction.Up);
            //assert 
            bool expected = false;
            Assert.AreEqual(actual, expected,
                "The player is unable to go into a wall rightwards.");
        }
    }      
}
