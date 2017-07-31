using Microsoft.VisualStudio.TestTools.UnitTesting;
using SokobanGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame.Tests
{
    [TestClass()]
    public class SokobanGameUnitTests
    {
        protected Converter Converter = new Converter();
        // Test methods removed because there is now a message box that checks before overwriting files
        //[TestMethod]
        //public void TestFile01SaveStringToFile()
        //{

        //    string input = "#.@ $##########";
        //    string fileName = "TestFile02.txt";
        //    bool expected = true;
        //    Filer filer = new Filer(Converter);
        //    // act
        //    string temp = filer.Save(AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName, input);
        //    bool actual = File.Exists(fileName);
        //    // assert 
        //    Assert.AreEqual(expected, actual, "Did not save to a file");
        //}

        //[TestMethod]
        //public void TestFile02SaveToExistingFileName()
        //{
        //    string input = "#.@ $##########";
        //    string fileName = "TestFile02.txt";
        //    string expected = "Overwrite existing file?";
        //    Filer filer = new Filer(Converter);
        //    // act
        //    string actual = filer.Save(AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName, input);
        //    actual = filer.Save(AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName, input);
        //    // assert 
        //    Assert.AreEqual(expected, actual, "Did not detect existing file");
        //}

        //[TestMethod]
        //public void TestFile03ReadFromAFile()
        //{
        //    // note Levels directory must be in the debug directory
        //    //     ~\SokobanConsoleGame\SokobanConsoleGame\SokobanConsoleGameTests\bin\Debug\Levels
        //    string input = "#.@ $     \n##########";
        //    string expected = "#.@ $     \n##########";
        //    string fileName = "TestFile02.txt";
        //    Filer filer = new Filer(Converter);
        //    // act
        //    // write to a file to ensure file exists.
        //    string temp = filer.Save(AppDomain.CurrentDomain.BaseDirectory + @"\Levels\" + fileName, input);
        //    // now try to read back from the file. Note file is expanded as read
        //    string actual = filer.Load(AppDomain.CurrentDomain.BaseDirectory + @"\Levels\" + fileName);
        //    // assert 
        //    Assert.AreEqual(expected, actual, "Did not read from a file");
        //}

        //[TestMethod]
        //public void TestFile06CompressBeforeWriteToAFile()
        //{
        //    string input = "###...@@@+++$$$   ***";
        //    string expected = "3#3.3@3+3$3-3*";
        //    string fileName = "Test02.txt";
        //    Filer filer = new Filer(Converter);
        //    // act
        //    string temp = filer.Save(AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName, input);
        //    string actual = filer.LoadDontExpand(AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName);
        //    // assert 
        //    Assert.AreEqual(expected, actual, "Did not compress the file before writing");
        //}

        [TestMethod]
        public void TestFile04TryToReadNonExistantFile()
        {
            string expected = "File does not exist";
            string fileName = "Testxxxx.txt";
            Filer filer = new Filer(Converter);
            // act
            string actual = filer.Load(AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName);
            // assert 
            Assert.AreEqual(expected, actual, "Did not detect that the file doesn't exist");
        }
        [TestMethod]
        public void TestFile05ReadFromAnExistingFile()
        {
            // note TestFile02.txt must be in the debug directory
            //     ~\SokobanConsoleGame\SokobanConsoleGame\SokobanConsoleGameTests\bin\Debug
            string expected = "#.@ $     \n##########";
            string fileName = "TestFile02.txt";
            Filer filer = new Filer(Converter);
            // act
            // file is expanded as read
            string actual = filer.Load(AppDomain.CurrentDomain.BaseDirectory + @"\Levels\" + fileName);
            // assert 
            Assert.AreEqual(expected, actual, 
                "Did read and expand file in debug directory");
        }
        [TestMethod]
        public void TestChk01CheckOnePlayerPreExpanding()
        {

            string input = "#.@ $ ";
            bool expected = true;
            Filer filer = new Filer(Converter);
            // act
            bool actual = filer.PreExpandingCheck(input);

            // assert 
            Assert.AreEqual(expected, actual, "Did not detect only one player before expanding");
        }
        [TestMethod]
        public void TestChk02CheckMoreThanOnePlayerPreExpanding()
        {
            string input = "#.@+$@*";
            bool expected = false;
            Filer filer = new Filer(Converter);
            // act
            bool actual = filer.PreExpandingCheck(input);
            // assert 
            Assert.AreEqual(expected, actual, "Did not detect more than one player before expanding");
        }
        [TestMethod]
        public void TestChk03CheckNoPlayerPreExpanding()
        {
            string input = "#.# $ ";
            bool expected = false;
            Filer filer = new Filer(Converter);
            // act
            bool actual = filer.PreExpandingCheck(input);
            // assert 
            Assert.AreEqual(expected, actual, "Did not detect no player before expanding");
        }
        [TestMethod]
        public void TestChk04CheckOnePlayerPreCompressing()
        {

            string input = "#@.$ ###";
            bool expected = true;
            Filer filer = new Filer(Converter);
            // act
            bool actual = filer.PreCompressingCheck(input);

            // assert 
            Assert.AreEqual(expected, actual, "Did not detect only one player before compressing");
        }
        [TestMethod]
        public void TestChk05CheckMoreThanOnePlayerPreCompressing()
        {
            string input = "#.@+$@*"; 
            bool expected = false;
            Filer filer = new Filer(Converter);
            // act
            bool actual = filer.PreCompressingCheck(input);
            // assert 
            Assert.AreEqual(expected, actual, "Did not detect more than one player before compressing");
        }
        [TestMethod]
        public void TestChk06CheckNoPlayerPreCompressing()
        {
            string input = "#.# $ "; 
            bool expected = false;
            Filer filer = new Filer(Converter);
            // act
            bool actual = filer.PreCompressingCheck(input);
            // assert 
            Assert.AreEqual(expected, actual, "Did not detect more than one player before compressing");
        }
        [TestMethod]
        public void TestChk07CheckGoalAndBlockPreExpanding()
        {
            string input = "#.# $ @"; 
            bool expected = true;
            Filer filer = new Filer(Converter);
            // act
            bool actual = filer.PreExpandingCheck(input);
            // assert 
            Assert.AreEqual(expected, actual, "Did not find equal number of blocks and goals before expanding");
        }
        [TestMethod]
        public void TestChk08CheckGoalAndBlockPreCompression()
        {
            string input = "#.# $ @";
            bool expected = true;
            Filer filer = new Filer(Converter);
            // act
            bool actual = filer.PreCompressingCheck(input);
            // assert 
            Assert.AreEqual(expected, actual, "Did not find equal number of blocks and goals before compressing");
        }
        [TestMethod]
        public void TestChk09CheckPlayerCountPreCompression()
        {
            string input = "#.# $ @";
            int expected = 1;
            Filer filer = new Filer(Converter);
            // act
            filer.PreCompressingCheck(input);
            int actual = filer.NoPlayers;
            // assert 
            Assert.AreEqual(expected, actual, "Did not count only one player before compression");
        }
        [TestMethod]
        public void TestChk10CheckBoxCountPreCompression()
        {
            string input = "#.# $ @";
            int expected = 1;
            Filer filer = new Filer(Converter);
            // act
            filer.PreCompressingCheck(input);
            int actual = filer.NoBoxes;
            // assert 
            Assert.AreEqual(expected, actual, "Did not count one box before compressions");
        }
        [TestMethod]
        public void TestChk11CheckGoalCountPreCompression()
        {
            string input = "#.# $ @";
            int expected = 1;
            Filer filer = new Filer(Converter);
            // act
            filer.PreCompressingCheck(input);
            int actual = filer.NoGoals;
            // assert 
            Assert.AreEqual(expected, actual, "Did not count one goal before compression");
        }
        [TestMethod]
        public void TestChk12CheckPlayerCountPreExpansion()
        {
            string input = "3#3.3@3+3$3-3*";
            int expected = 6;
            Filer filer = new Filer(Converter);
            // act
            filer.PreExpandingCheck(input);
            int actual = filer.NoPlayers;
            // assert 
            Assert.AreEqual(expected, actual, "Did not count six players before expansion");
        }
        [TestMethod]
        public void TestChk13CheckBoxCountPreExpansion()
        {
            string input = "3#3.3@3+3$3-3*";
            int expected = 6;
            Filer filer = new Filer(Converter);
            // act
            filer.PreExpandingCheck(input);
            int actual = filer.NoBoxes;
            // assert 
            Assert.AreEqual(expected, actual, "Did not count six boxes before expansion");
        }
        [TestMethod]
        public void TestChk14CheckGoalCountPreExpansion()
        {
            string input = "3#3.3@3+3$3-3*";
            int expected = 9;
            Filer filer = new Filer(Converter);
            // act
            filer.PreExpandingCheck(input);
            int actual = filer.NoGoals;
            // assert 
            Assert.AreEqual(expected, actual, "Did not count six Goals before expansion");
        }
        [TestMethod]
        public void TestChk15CheckPlayerCountGreaterThan10PreExpansion()
        {
            string input = "11#11.11@11+11$11-11*";
            int expected = 22;
            Filer filer = new Filer(Converter);
            // act
            filer.PreExpandingCheck(input);
            int actual = filer.NoPlayers;
            // assert 
            Assert.AreEqual(expected, actual, "Did not count 22 players before expansion");
        }
        [TestMethod]
        public void TestChk16CheckBoxCountGreaterThan10PreExpansion()
        {
            string input = "11#11.11@11+11$11-11*"; ;
            int expected = 22;
            Filer filer = new Filer(Converter);
            // act
            filer.PreExpandingCheck(input);
            int actual = filer.NoBoxes;
            // assert 
            Assert.AreEqual(expected, actual, "Did not count 22 boxes before expansion");
        }
        [TestMethod]
        public void TestChk17CheckGoalCountGreaterThan10PreExpansion()
        {
            string input = "11#11.11@11+11$11-11*"; ;
            int expected = 33;
            Filer filer = new Filer(Converter);
            // act
            filer.PreExpandingCheck(input);
            int actual = filer.NoGoals;
            // assert 
            Assert.AreEqual(expected, actual, "Did not count 22 Goals before expansion");
        }
        [TestMethod]
        public void TestChk18CheckPlayerCountPreExpansion()
        {
            string input = "#.# $ @";
            int expected = 1;
            Filer filer = new Filer(Converter);
            // act
            filer.PreExpandingCheck(input);
            int actual = filer.NoPlayers;
            // assert 
            Assert.AreEqual(expected, actual, "Did not count only one player before Expansion");
        }
        [TestMethod]
        public void TestChk19CheckBoxCountPreExpansion()
        {
            string input = "#.# $ @";
            int expected = 1;
            Filer filer = new Filer(Converter);
            // act
            filer.PreExpandingCheck(input);
            int actual = filer.NoBoxes;
            // assert 
            Assert.AreEqual(expected, actual, "Did not count one box before Expansion");
        }
        [TestMethod]
        public void TestChk20CheckGoalCountPreExpansion()
        {
            string input = "#.# $ @";
            int expected = 1;
            Filer filer = new Filer(Converter);
            // act
            filer.PreExpandingCheck(input);
            int actual = filer.NoGoals;
            // assert 
            Assert.AreEqual(expected, actual, "Did not count one goal before Expansion");
        }
    }
}