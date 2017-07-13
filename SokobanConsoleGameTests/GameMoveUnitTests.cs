using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SokobanGame;

namespace SokobanGameTests
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
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            bool expected = false;
            // act 
            bool actual = game.Load("#######\n#  #\n#@ #\n####");
            // assert
            Assert.AreEqual(actual, expected,
                "The game accepted an invalid string");
        }
        [TestMethod]
        public void TestLoad02ValidGameStringSent()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            bool expected = true;
            // act 
            bool actual = game.Load("####\n# .#\n#@$#\n####");
            // assert
            Assert.AreEqual(actual, expected,
                "The game did not accept a valid string");
        }
        [TestMethod]
        public void TestLoad03InvalidGameStringLinesNotEqualLengths()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            bool expected = false;
            // act 
            bool actual = game.Load("#######\n#  #\n#@ #\n####");
            // assert
            Assert.AreEqual(actual, expected,
                "The game did not accept a valid string");
        }
        [TestMethod]
        public void TestLoad04InvalidGameStringUnevenGoalsAndBoxes()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            bool expected = false;
            // act 
            bool actual = game.Load("#####\n# ..#\n#@ $#\n####");
            // assert
            Assert.AreEqual(actual, expected,
                "The game did not accept a valid string");
        }
        [TestMethod]
        public void TestLoad05InvalidGameStringUnevenGoalsBoxesAndBoxesOnGoal()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            bool expected = false;
            // act 
            bool actual = game.Load("#####\n# .*#\n#@ $#\n####");
            // assert
            Assert.AreEqual(actual, expected,
                "The game did not accept a valid string");
        }
        [TestMethod]
        public void TestLoad06InvalidGameStringTooManyPlayers()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            bool expected = false;
            // act 
            bool actual = game.Load("#####\n# @.#\n#@ $#\n####");
            // assert
            Assert.AreEqual(actual, expected,
                "The game did not accept a valid string");
        }
        [TestMethod]
        public void TestLoad07LoadFileWithEvenRowsAndColumns_GetCorrectRowCount()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            int expected = 4;
            // act 
            game.Load("####\n# .#\n#@$#\n####");
            int actual = game.GetRowCount();
            // assert
            Assert.AreEqual(expected, actual,
                "The game did not accept a valid string");
        }
        [TestMethod]
        public void TestLoad08LoadFileWithEvenRowsAndColumns_GetCorrectColumnCount()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            int expected = 4;
            // act 
            game.Load("####\n# .#\n#@$#\n####");
            int actual = game.GetColumnCount();
            // assert
            Assert.AreEqual(expected, actual,
                "The game did not accept a valid string");
        }
        [TestMethod]
        public void TestLoad09LoadFileWithUnevenRowsAndColumns_GetCorrectRowCount()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            int expected = 6;
            // act 
            game.Load("#######\n#  #  #\n#    .#\n# $#  #\n# @#  #\n#######");
            int actual = game.GetRowCount();
            // assert
            Assert.AreEqual(expected, actual,
                "The game did not accept a valid string");
        }
        [TestMethod]
        public void TestLoad10LoadFileWithUnevenRowsAndColumns_GetCorrectColumnCount()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            int expected = 7;
            // act 
            game.Load("#######\n#  #  #\n#    .#\n# $#  #\n# @#  #\n#######");
            int actual = game.GetColumnCount();
            // assert
            Assert.AreEqual(expected, actual,
                "The game did not accept a valid string");
        }
        [TestMethod]
        public void TestLoad11LoadFileWithPayerOnGoal()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            bool expected = true;
            // act 
            bool actual = game.Load("#######\n#     #\n#     #\n# +   #\n#    $#\n#######");
            // assert
            Assert.AreEqual(expected, actual,
                "The game did not accept a valid string");
        }
        [TestMethod]
        public void TestGame01PlayerNoLongerThereIfMoved_Up()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("####\n# .#\n#@$#\n####");
            // act 
            game.Move(Direction.Up);
            // assert
            Position pos = new Position(3 - OFFSET, 2 - OFFSET);
            Parts actual3_2 = game.GetMovable(pos);
            Parts expected3_2 = Parts.Empty;
            Assert.AreEqual(actual3_2, expected3_2,
                "The player is unmoved after being told to go up");
        }
        [TestMethod]
        public void TestGame02PlayerWhereExpectedIfMoved_Up()
        {
            // player starts at row 3 column 2 
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("####\n# .#\n#@$#\n####");
            // act
            game.Move(Direction.Up);
            //assert 
            Parts actual2_2 = game.WhatsAt(2 - OFFSET, 2 - OFFSET);
            Parts expected2_2 = Parts.Player;
            Assert.AreEqual(actual2_2, expected2_2,
                "The player is not where expected after being told to go up");
        }
        [TestMethod]
        public void TestGame03PlayerNoLongerThereIfMoved_Down()
        {
            //player starts at row 2 column 2
            Filer filer = new Filer(Converter);
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
        public void TestGame04PlayerWhereExpectedIfMoved_Down()
        {
            // player starts at row 2 column 2 
            Filer filer = new Filer(Converter);
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
        public void TestGame05PlayerNoLongerThereIfMoved_Left()
        {
            //player starts at row 2 column 3
            Filer filer = new Filer(Converter);
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
        public void TestGame06PlayerWhereExpectedIfMoved_Left()
        {
            // player starts at row 2 column 3 
            Filer filer = new Filer(Converter);
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
        public void TestGame07PlayerNoLongerThereIfMoved_Right()
        {
            //player starts at row 2 column 2
            Filer filer = new Filer(Converter);
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
        public void TestGame08PlayerWhereExpectedIfMoved_Right()
        {
            // player starts at row 2 column 2 
            Filer filer = new Filer(Converter);
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
        public void TestGame09BlockWhereExpectedIfPlayerPushed_Up()
        {
            // player starts at row 4 column 3 
            // block starts at row 3 column 3
            Filer filer = new Filer(Converter);
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
        public void TestGame10BlockBecomesBlockOnGoalIfPlayerPushed_Up()
        {
            // player starts at row 4 column 3 
            // block starts at row 3 column 3
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#####\n# . #\n# $ #\n# @ #\n#####");
            // act
            game.Move(Direction.Up);
            //assert 
            // block should be at row 2 column 3
            Parts actual2_3 = game.WhatsAt(2 - OFFSET, 3 - OFFSET);
            Parts expected2_3 = Parts.BlockOnGoal;
            Assert.AreEqual(actual2_3, expected2_3,
                "The block has not become block on goal after being pushed to go up");
        }
        [TestMethod]
        public void TestGame11BlockWhereExpectedIfPlayerPushed_Down()
        {
            // player starts at row 2 column 3 
            // block starts at row 3 column 3
            Filer filer = new Filer(Converter);
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
        public void TestGame12BlockBecomesBlockOnGoalIfPlayerPushed_Down()
        {
            // player starts at row 2 column 3 
            // block starts at row 3 column 3
            Filer filer = new Filer(Converter);
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
        public void TestGame13BlockWhereExpectedIfPlayerPushed_Left()
        {
            // player starts at row 3 column 4 
            // block starts at row 3 column 3
            Filer filer = new Filer(Converter);
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
        public void TestGame14BlockBecomesBlockOnGoalIfPlayerPushed_Left()
        {
            // player starts at row 3 column 4 
            // block starts at row 3 column 3
            Filer filer = new Filer(Converter);
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
        public void TestGame15BlockWhereExpectedIfPlayerPushed_Right()
        {
            // player starts at row 3 column 2 
            // block starts at row 3 column 3
            Filer filer = new Filer(Converter);
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
        public void TestGame16BlockBecomesBlockOnGoalIfPlayerPushed_Right()
        {
            // player starts at row 3 column 2 
            // block starts at row 3 column 3
            Filer filer = new Filer(Converter);
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
        public void TestGame17PlayerUnableToGoIntoAWall_Up()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#####\n# @ #\n# $ #\n#  .#\n#####");
            // act
            bool actual = game.Move(Direction.Up);
            //assert 
            bool expected = false;
            Assert.AreEqual(actual, expected,
                "The player is able to go into a wall upwards.");
        }
        [TestMethod]
        public void TestGame18PlayerUnableToGoIntoAWall_Down()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#####\n#   #\n# $ #\n# @.#\n#####");
            // act
            bool actual = game.Move(Direction.Down);
            //assert 
            bool expected = false;
            Assert.AreEqual(actual, expected,
                "The player is able to go into a wall downwards.");
        }
        [TestMethod]
        public void TestGame19PlayerUnableToGoIntoAWall_Left()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#####\n#   #\n# $ #\n#@ .#\n#####");
            // act
            bool actual = game.Move(Direction.Left);
            //assert 
            bool expected = false;
            Assert.AreEqual(actual, expected,
                "The player is able to go into a wall leftwards.");
        }
        [TestMethod]
        public void TestGame20PlayerUnableToGoIntoAWallRight()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#####\n#  @#\n# $ #\n#  .#\n#####");
            // act
            bool actual = game.Move(Direction.Right);
            //assert 
            bool expected = false;
            Assert.AreEqual(actual, expected,
                "The player is able to go into a wall rightwards.");
        }
        [TestMethod]
        public void TestGame21BlockUnableToBePushedIntoAWall_Up()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#####\n# $ #\n# @ #\n#  .#\n#####");
            // act
            bool actual = game.Move(Direction.Up);
            //assert 
            bool expected = false;
            Assert.AreEqual(actual, expected,
                "Pushed the block into a wall upwards.");
        }
        [TestMethod]
        public void TestGame22BlockUnableToBePushedIntoAWall_Down()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#####\n#   #\n# @ #\n# $.#\n#####");
            // act
            bool actual = game.Move(Direction.Down);
            //assert 
            bool expected = false;
            Assert.AreEqual(actual, expected,
                "Pushed the block into a wall downwards.");
        }
        [TestMethod]
        public void TestGame23BlockUnableToBePushedIntoAWall_Left()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#####\n#   #\n#$@ #\n#  .#\n#####");
            // act
            bool actual = game.Move(Direction.Left);
            //assert 
            bool expected = false;
            Assert.AreEqual(actual, expected,
                "Pushed the block into a wall leftwards.");
        }
        [TestMethod]
        public void TestGame24BlockUnableToBePushedIntoAWall_Right()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#####\n#   #\n# @$#\n#  .#\n#####");
            // act
            bool actual = game.Move(Direction.Right);
            //assert 
            bool expected = false;
            Assert.AreEqual(actual, expected,
                "Pushed the block into a wall rightwards.");
        }
        [TestMethod]
        public void TestGame25PushBlockOntoLastGoalCheckIfFinished_Up()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#####\n# . #\n# $ #\n# @ #\n#####");
            // act
            game.Move(Direction.Up);
            bool actual = game.isFinished();
            //assert 
            bool expected = true;
            Assert.AreEqual(actual, expected,
                "Game not finished when push block onto last goal upwards.");
        }
        [TestMethod]
        public void TestGame26PushBlockOntoLastGoalCheckIfFinished_Left()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#####\n#   #\n#.$@#\n#   #\n#####");
            // act
            game.Move(Direction.Left);
            bool actual = game.isFinished();
            //assert 
            bool expected = true;
            Assert.AreEqual(actual, expected,
                "Game not finished when push block onto last goal leftwards.");
        }
        [TestMethod]
        public void TestGame27PushBlockOntoLastGoalCheckIfFinished_Right()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#####\n#   #\n#@$.#\n#   #\n#####");
            // act
            game.Move(Direction.Right);
            bool actual = game.isFinished();
            //assert 
            bool expected = true;
            Assert.AreEqual(actual, expected,
                "Game not finished when push block onto last goal rightwards.");
        }
        [TestMethod]
        public void TestGame28PushBlockOntoGoalButNotLastCheckIfFinished_Up()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#####\n# . #\n# $ #\n#$@.#\n#####");
            // act
            game.Move(Direction.Up);
            bool actual = game.isFinished();
            //assert 
            bool expected = false;
            Assert.AreEqual(actual, expected,
                "Game finished when push block onto a goal but it wasn't the last one upwards.");
        }
        [TestMethod]
        public void TestGame29MoveAroundBlockThenPushBlockThroughGapInWall_Right()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#######\n#  #  #\n#    .#\n# $#  #\n# @#  #\n#######");
            // act
            bool moved = game.Move(Direction.Up);
            moved = game.Move(Direction.Left);
            moved = game.Move(Direction.Up);
            moved = game.Move(Direction.Right);
            moved = game.Move(Direction.Right);
            moved = game.Move(Direction.Right);
            bool actual = game.isFinished();
            //assert 
            bool expected = true;
            Assert.AreEqual(actual, expected,
                "Did not move around block then push block onto a goal .");
        }
        [TestMethod]
        public void TestGame30MovePlayerSixTimesGetCount()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#######\n#  #  #\n#    .#\n# $#  #\n# @#  #\n#######");
            int expected = 6;
            // act
            bool moved = game.Move(Direction.Up);
            moved = game.Move(Direction.Left);
            moved = game.Move(Direction.Up);
            moved = game.Move(Direction.Right);
            moved = game.Move(Direction.Right);
            moved = game.Move(Direction.Right);
            moved = game.Move(Direction.Right);
            int actual = game.MoveCount;
            //assert 
            Assert.AreEqual(expected, actual,
                "Not counting moves correctly");
        }
        [TestMethod]
        public void TestGame31DontMovePlayerReturnZeroCount()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#######\n#     #\n#    .#\n# $#  #\n# @   #\n#######");
            int expected = 0;
            // act
            int actual = game.MoveCount;
            //assert 
            Assert.AreEqual(expected, actual,
                "Not returning zero count when no moves made");
        }
        [TestMethod]
        public void TestGame32MovePlayerGreaterThan10TimesReturn11Count()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            game.Load("#######\n#     #\n#    .#\n#    $#\n# @   #\n#######");
            int expected = 11;
            // act
            game.Move(Direction.Up);
            game.Move(Direction.Up);
            game.Move(Direction.Up);
            game.Move(Direction.Left);
            game.Move(Direction.Down);
            game.Move(Direction.Down);
            game.Move(Direction.Down);
            game.Move(Direction.Right);
            game.Move(Direction.Right);
            game.Move(Direction.Right);
            game.Move(Direction.Up);
            int actual = game.MoveCount;
            //assert 
            Assert.AreEqual(expected, actual,
                "Not returning zero count when no moves made");
        }
        [TestMethod]
        public void TestGame33MovePlayerThreeTimesThenResetGame()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            // player starts at row 5 column 3
            game.Load("#######\n#     #\n#    .#\n#    $#\n# @   #\n#######");
            // act
            game.Move(Direction.Up);
            game.Move(Direction.Up);
            game.Move(Direction.Up);
            game.Restart();
            Parts actual5_3 = game.WhatsAt(5 - OFFSET, 3 - OFFSET);
            Parts expected5_3 = Parts.Player;
            //assert 
            Assert.AreEqual(expected5_3, actual5_3,
                "Player not returning to original position");
        }
        [TestMethod]
        public void TestGame34MovePlayerThreeTimesThenUndoLastMove()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            // player starts at row 5 column 3
            game.Load("#######\n#     #\n#    .#\n#    $#\n# @   #\n#######");
            // act
            game.Move(Direction.Up); // player at 4 3
            game.Move(Direction.Up); // player at 3 3
            game.Move(Direction.Up); // player at 2 3
            game.Undo();
            // player should be back at 3 3
            Parts actual3_3 = game.WhatsAt(3 - OFFSET, 3 - OFFSET);
            Parts expected3_3 = Parts.Player;
            //assert 
            Assert.AreEqual(expected3_3, actual3_3,
                "Player not returning to previous position");
        }
        [TestMethod]
        public void TestGame35MovePlayerThreeTimesThenUndoLastTwoMoves()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            // player starts at row 5 column 3
            game.Load("#######\n#     #\n#    .#\n#    $#\n# @   #\n#######");
            // act
            game.Move(Direction.Up); // player at 4 3
            game.Move(Direction.Up); // player at 3 3
            game.Move(Direction.Up); // player at 2 3
            game.Undo();
            game.Undo();
            // player should be back at 4 3
            Parts actual4_3 = game.WhatsAt(4 - OFFSET, 3 - OFFSET);
            Parts expected4_3 = Parts.Player;
            //assert 
            Assert.AreEqual(expected4_3, actual4_3,
                "Player not returning to position two turns ago");
        }
        [TestMethod]
        public void TestGame36PushBlockTwoTimesThenUndoLastMove()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            // block starts at row 4 column 3
            game.Load("#######\n#     #\n#    .#\n# $   #\n# @   #\n#######");
            // act
            game.Move(Direction.Up); // block at 3 3
            game.Move(Direction.Up); // block at 2 3
            game.Undo();
            // block should be back at 3 3
            Parts actual3_3 = game.WhatsAt(3 - OFFSET, 3 - OFFSET);
            Parts expected3_3 = Parts.Block;
            //assert 
            Assert.AreEqual(expected3_3, actual3_3,
                "Block not returning to last position");
        }
        [TestMethod]
        public void TestGame37PushBlockTwoTimesThenUndoLastTwoMoves()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            // block starts at row 4 column 3
            game.Load("#######\n#     #\n#    .#\n# $   #\n# @   #\n#######");
            Parts block1 = game.WhatsAt(4 - OFFSET, 3 - OFFSET);
            // act
            game.Move(Direction.Up); // block at 3 3
            Parts block2 = game.WhatsAt(3 - OFFSET, 3 - OFFSET);
            game.Move(Direction.Up); // block at 2 3
            Parts block3 = game.WhatsAt(2 - OFFSET, 3 - OFFSET);
            game.Undo();
            game.Undo();
            // block should be back at 4 3
            Parts actual4_3 = game.WhatsAt(4 - OFFSET, 3 - OFFSET);
            Parts expected4_3 = Parts.Block;
            //assert 
            Assert.AreEqual(expected4_3, actual4_3,
                "Block not returning to position two turns ago");
        }
        [TestMethod]
        public void TestGame38MovePlayerOntoGoalGetPlayerOnGoal()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            // goal  at row 4 column 3
            game.Load("#######\n#     #\n#     #\n# .   #\n# @  $#\n#######");
            Parts goal = game.WhatsAt(4 - OFFSET, 3 - OFFSET);
            // act
            game.Move(Direction.Up);
            // player on goal at 4 3
            Parts actual4_3 = game.WhatsAt(4 - OFFSET, 3 - OFFSET);
            Parts expected4_3 = Parts.PlayerOnGoal;
            //assert 
            Assert.AreEqual(expected4_3, actual4_3,
                "Unable to move the player onto a goal. ");
        }
        [TestMethod]
        public void TestGame39MovePlayerOffGoalGetGoal()
        {
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            // goal  at row 4 column 3
            game.Load("#######\n#     #\n#     #\n# +   #\n#    $#\n#######");
            Parts playerOnGoal = game.WhatsAt(4 - OFFSET, 3 - OFFSET);
            // act
            game.Move(Direction.Up);
            // player on goal at 4 3
            Parts actual4_3 = game.WhatsAt(4 - OFFSET, 3 - OFFSET);
            Parts expected4_3 = Parts.Goal;
            //assert 
            Assert.AreEqual(expected4_3, actual4_3,
                "Move player off goal does not return position to goal. ");
        }
    }      
}
