using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SokobanGame;

namespace SokobanConsoleGameTests
{
    [TestClass]
    public class SokobanLoadUnitTests
    {

        protected Converter Converter = new Converter();
        [TestMethod]
        public void TestLoad01IncorrectGameStringSent()
        {
            //player starts at row 3 column 2
            Filer filer = new Filer(Converter);
            Game game = new Game(filer);
            bool expected = false;
            // act 
            bool actual = game.LoadLevel("#######\n#  #\n#@ #\n####");
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
            bool actual = game.LoadLevel("####\n# .#\n#@$#\n####");
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
            bool actual = game.LoadLevel("#######\n#  #\n#@ #\n####");
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
            bool actual = game.LoadLevel("#####\n# ..#\n#@ $#\n####");
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
            bool actual = game.LoadLevel("#####\n# .*#\n#@ $#\n####");
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
            bool actual = game.LoadLevel("#####\n# @.#\n#@ $#\n####");
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
            game.LoadLevel("####\n# .#\n#@$#\n####");
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
            game.LoadLevel("####\n# .#\n#@$#\n####");
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
            game.LoadLevel("#######\n#  #  #\n#    .#\n# $#  #\n# @#  #\n#######");
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
            game.LoadLevel("#######\n#  #  #\n#    .#\n# $#  #\n# @#  #\n#######");
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
            bool actual = game.LoadLevel("#######\n#     #\n#     #\n# +   #\n#    $#\n#######");
            // assert
            Assert.AreEqual(expected, actual,
                "The game did not accept a valid string");
        }
    }
}
