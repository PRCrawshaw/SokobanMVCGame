using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SokobanGame;

namespace SokobanConsoleGameTests
{
    [TestClass]
    public class TestOutsideWalls
    {
        protected Converter Converter = new Converter();
        [TestMethod]
        public void TestWalls01WallsOnOutsideEdgesPass()
        {
            string input = "#####\n#   #\n#   #\n#   #\n#####";
            bool expected = true;
            Filer filer = new Filer(Converter);
            bool actual = filer.CheckWallsOnEdges(input);
            // assert 
            Assert.AreEqual(expected, actual, "Did not find walls on outside edges");
        }
        [TestMethod]
        public void TestWalls02WallsOnOutsideEdgesFail()
        {
            string input = "#####\n#   #\n#   #\n#    \n#####";
            bool expected = false;
            Filer filer = new Filer(Converter);
            bool actual = filer.CheckWallsOnEdges(input);
            // assert 
            Assert.AreEqual(expected, actual, "Did not find missing wall on outside edges");
        }
    }
}
