using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SokobanGame;

namespace SokobanGameTests
{
    [TestClass]
    public class SokobanFilerUnitTests
    {
        [TestMethod]
        public void TestCpr01FilerEmptyStringCompression()
        {
            string input = "";
            string expected = "";
            Converter compressor = new Converter();
            // act
            compressor.Compress(input);
            string actual = compressor.Compressed;
            // assert 
            Assert.AreEqual(expected, actual, "Tried to decompress an empty string");
        }
        [TestMethod]
        public void TestCpr02FilerNullStringCompression()
        {
            string input = null;
            string expected = "";
            Converter compressor = new Converter();
            // act
            compressor.Compress(input);
            string actual = compressor.Compressed;
            // assert 
            Assert.AreEqual(expected, actual, "Tried to decompress an null string");
        }
        [TestMethod]
        public void TestCpr03FilerSinglesAreNotCompressed()
        {
            string input = "#.@+$ *";
            string expected = "#.@+$-*";
            Converter compressor = new Converter();
            // act
            compressor.Compress(input);
            string actual = compressor.Compressed;
            // assert 
            Assert.AreEqual(expected, actual, "Did not leave singles alone");
        }
        [TestMethod]
        public void TestCpr04FilerShortRunCompression()
        {
            string input = "###...@@@+++$$$   ***";
            string expected = "3#3.3@3+3$3-3*";
            Converter compressor = new Converter();
            // act
            compressor.Compress(input);
            string actual = compressor.Compressed;
            // assert
            Assert.AreEqual(expected, actual, "Runs of 3 symbols were not compressed to digit and symbol pairs");
        }
        [TestMethod]
        public void TestCpr05FilerLongRunCompression()
        {
            string input = "##########..........@@@@@@@@@@++++++++++$$$$$$$$$$          **********";
            string expected = "10#10.10@10+10$10-10*";
            Converter compressor = new Converter();
            // act
            compressor.Compress(input); 
            string actual = compressor.Compressed;
            // assert
            Assert.AreEqual(expected, actual, "Runs of 10 symbols were not compressed to digits followed by a symbol");
        }
        [TestMethod]
        public void TestCpr06FilerRunsAndSinglesCompression()
        {
            string input = "###.@@@+$$$ ***";
            string expected = "3#.3@+3$-3*";
            Converter compressor = new Converter();
            // act 
            compressor.Compress(input);
            string actual = compressor.Compressed;
            // assert  
            Assert.AreEqual(expected, actual, "runs were not compressed and singles left alone");
        }
        [TestMethod]
        public void TestCpr07FilerTwoLinesCompressedToOne()
        {
            string input = "#######\n#.@ # #";
            string expected = "7#|#.@-#-#";
            Converter compressor = new Converter();
            // act
            compressor.Compress(input);
            string actual = compressor.Compressed;
            // assert 
            Assert.AreEqual(expected, actual, "Line seperator not right");
        }
        [TestMethod]
        public void TestCpr08FilerRemoveTrailingBlanksWhenCompressing()
        {
            string input = "#######    \n#.@ # #   ";
            string expected = "7#|#.@-#-#";
            Converter compressor = new Converter();
            // act 
            compressor.Compress(input);
            string actual = compressor.Compressed;
            // assert 
            Assert.AreEqual(expected, actual, "Trailing Blanks at end of line");
        }
        [TestMethod]
        public void TestCpr09FilerRemoveonlyOnlyTrailingBlanksWhenCompressing()
        {
            string input = "#######    \n    #######\n#.@ # #   ";
            string expected = "7#|4-7#|#.@-#-#";
            Converter compressor = new Converter();
            // act 
            compressor.Compress(input);
            string actual = compressor.Compressed;
            // assert 
            Assert.AreEqual(expected, actual, "Trailing Blanks at end of line");
        }
        [TestMethod]
        public void TestExp01FilerEmptyStringExpansion()
        {
            string input = "";
            string expected = "";
            Converter expander = new Converter();
            // act
            expander.Expand(input);
            string actual = expander.Expanded;
            // assert 
            Assert.AreEqual(expected, actual, "Tried to expand an empty string");
        }
        [TestMethod]
        public void TestExp02FilerNullStringExpansion()
        {
            string input = null;
            string expected = "";
            Converter expander = new Converter();
            // act
            expander.Expand(input);
            string actual = expander.Expanded;
            // assert 
            Assert.AreEqual(expected, actual, "Tried to decompress null string");
        }
        [TestMethod]
        public void TestExp03FilerSinglesExpanded()
        {
            string input = "#.@+$-*";
            string expected = "#.@+$ *";
            Converter expander = new Converter();
            // act
            expander.Expand(input);
            string actual = expander.Expanded;
            // assert 
            Assert.AreEqual(expected, actual, "Did not leave singles alone");
        }
        [TestMethod]
        public void TestExp04FilerOneLineExpandedToTwo()
        {
            string input = "#.#@|-#-#";
            string expected = "#.#@\n # #";
            Converter expander = new Converter();
            // act
            expander.Expand(input);
            string actual = expander.Expanded;
            // assert 
            Assert.AreEqual(expected, actual, "Line seperator not right");
        }
        [TestMethod]
        public void TestExp05FilerNewLineAndSingleDigit()
        {
            string input = "4#.|@-#-#";
            string expected = "####.\n@ # #";
            Converter expander = new Converter();
            // act
            expander.Expand(input);
            string actual = expander.Expanded;
            // assert 
            Assert.AreEqual(expected, actual, "Line seperator not right");
        }
        [TestMethod]
        public void TestExp06FilerShortRunExpansion()
        {
            string input = "3#3.3@3+3$3-3*";
            string expected = "###...@@@+++$$$   ***";
            Converter expander = new Converter();
            // act
            expander.Expand(input);
            string actual = expander.Expanded;
            // assert
            Assert.AreEqual(expected, actual, "Runs of 3 symbols were not compressed to digit and symbol pairs");
        }
        [TestMethod]
        public void TestExp07FilerLongRunExpansion()
        {
            string input = "10#10.10@10+10$10-10*";
            string expected = "##########..........@@@@@@@@@@++++++++++$$$$$$$$$$          **********";
            Converter expander = new Converter();
            // act
            expander.Expand(input);
            string actual = expander.Expanded;
            // assert
            Assert.AreEqual(expected, actual, "Runs of 10 symbols were not compressed to digits followed by a symbol");
        }
        [TestMethod]
        public void TestExp08FilerRunsAndSinglesExpansion()
        {
            string input = "3#.3@+3$-3*";
            string expected = "###.@@@+$$$ ***";
            Converter expander = new Converter();
            // act
            expander.Expand(input);
            string actual = expander.Expanded;
            // assert  
            Assert.AreEqual(expected, actual, "runs were not compressed and singles left alone");
        }
        [TestMethod]
        public void TestExp09FilerExpandRowToEqualLength()
        {
            string input = "5#|#3-#|3#|5#";
            string expected = "#####\n#   #\n###  \n#####";
            Converter expander = new Converter();
            // act
            expander.Expand(input);
            string actual = expander.Expanded;
            // assert
            Assert.AreEqual(expected, actual, "Did not expand line to have trailing spaces");
        }
    }
}
