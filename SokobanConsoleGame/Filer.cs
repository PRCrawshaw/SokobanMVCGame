using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SokobanGame
{
    public enum ConversionType { expand, compress};
    public class Filer : iFiler, iLoader, iSaver, iChecker     
    {
        public Converter Converter;
        protected const string EXTENSION = @".txt";
        protected const string DIR = @"levels\";
        public int NoPlayers{ get; set; }
        public int NoGoals { get; set; }
        public int NoBoxes { get; set; }
        public Filer(Converter converter) 
        {
            Converter = converter;
        }
        public string[] GetFileList()
        {
            string[] txtfiles = Directory.GetFiles(DIR, "*.txt");
            return txtfiles;
        }
        public string Load(string filename)
        {
            if (!filename.Contains("Levels")) // used for unit tests
                filename = DIR + filename;
            if (File.Exists(filename))
            {
                var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string temp = streamReader.ReadToEnd().Replace(Environment.NewLine, "");
                    return convertString(temp, ConversionType.expand);
                }
            }
            else return "File does not exist";
        }
        public string LoadDontExpand(string filename)
        {
            if (File.Exists(filename))
            {
                var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    return streamReader.ReadToEnd().Replace(Environment.NewLine, "");
                }
            }
            else return "File does not exist";
        }
        public void Save(string filename, iFileable callMeBackforDetails)
        {
            //    using (StreamWriter writer = new StreamWriter("important.txt"))
            //        {
            //            writer.Write("Word ");
            //            writer.WriteLine("word 2");
            //            writer.WriteLine("Line");
            //        }
        }
        public string Save(string filename, string text)
        {
            //filename = DIR + filename;
            if (!File.Exists(filename))
            {
                text = convertString(text, ConversionType.compress);
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine(text);
                    return "File saved";
                }
            }
            else return "Overwrite existing file?";
        }
        private string convertString(string input, ConversionType type)
        {
            if (type == ConversionType.expand)
            {
                Converter.Expand(input);
                input = Converter.Expanded;
            }
            else
            {
                Converter.Compress(input);
                input = Converter.Compressed;
            }
            return input;
        }
        public bool PreExpandingCheck(string input)
        {
            string temp = Converter.ExpandObjects(input);
            return CheckPlayersGoalsBlocks(temp);
        }
        public bool PreCompressingCheck(string input)
        {
            bool check = CheckLineLengths(input);
            if (check) { check = CheckPlayersGoalsBlocks(input); }
            return check;
        }
        public bool CheckLineLengths(string input)
        {
            string[] lines = input.Split('\n');
            int lineLength = lines[0].Length;
            for (int i=0; i<lines.Length; i++)
            {
                if (lineLength != lines[i].Length)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckPlayersGoalsBlocks(string input)
        {
            bool playerCheck = false;
            bool GoalBlockCheck = false;
            playerCheck = CheckOnePlayer(input);
            GoalBlockCheck = CheckGoalsAgainstPlayers(input);
            if (playerCheck && GoalBlockCheck)
                return true;
            else return false;
        }
        private bool CheckOnePlayer(string input)
        {
            int count = input.Count(f => f == '@');
            count += input.Count(f => f == '+');
            this.NoPlayers = count;
            if (count == 1)
                return true;
            else return false;
        }
        private bool CheckGoalsAgainstPlayers(string input)
        {
            int goalCount = input.Count(f => f == '.'); // goal
            goalCount += input.Count(f => f == '*'); // box on goal
            goalCount += input.Count(f => f == '+'); // player on goal
            int boxCount = input.Count(f => f == '$'); // box
            boxCount += input.Count(f => f == '*'); // box on goal
            this.NoGoals = goalCount;
            this.NoBoxes = boxCount;
            if (boxCount == goalCount && boxCount > 0)
                return true;
            else return false;
        }
        public bool CheckWallsOnEdges(string input)
        {
            Converter.Compress(input);
            bool firstRowOk = false;
            bool lastRowOK = false;
            bool middleLinesOk = false;
            string compressedInput = Converter.Compressed;
            string[] compressedLines = compressedInput.Split('|');
            string[] inputLines = input.Split('\n');
            int length = inputLines[0].Length;
            int noOfLines = compressedLines.Length -1;
            
            // check first and last rows
            string lastLine = compressedLines[noOfLines];
            string firstLine = compressedLines[0];
            if (firstLine[1] == '#' && firstLine.Length == 2)
                firstRowOk = true;
            if (lastLine[1] == '#' && lastLine.Length == 2 )
                lastRowOK = true;

            // check middle rows
            // add trailing spaces
            for (int j=0; j< inputLines.Length; j++)
            {
                if (inputLines[j][length-1] == ' ')
                {
                    // find out how many spaces TODO

                    compressedLines[j] += "-";
                }
            }
            // start on second line 
            for (int i=1; i < noOfLines; i++)
            {
                if (compressedLines[i].StartsWith("#") && compressedLines[i].EndsWith("#"))
                    middleLinesOk = true;
                else middleLinesOk = false;
            }

            if (lastRowOK && firstRowOk && middleLinesOk)
                return true;
            else return false;
        }
    }
}
