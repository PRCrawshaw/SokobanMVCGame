using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanConsoleGame
{
    public enum ConversionType { expand, compress};
    public class Filer : iFiler, iLoader, iSaver, iChecker     
    {
        protected iLoader Loader;
        protected iSaver Saver;
        protected iConverter Converter;
        protected iChecker Checker;
        private int noPlayers;
        private int noGoals;
        private int noBoxes;
        public int NoPlayers{get{return noPlayers;} set{noPlayers = value;}}
        public int NoGoals {get{return noGoals;}set{noGoals = value;}}
        public int NoBoxes {get { return noBoxes;}set { noBoxes = value; }}
        public Filer(iLoader loader, iSaver saver, iConverter converter, iChecker checker) 
        {
            Loader = loader;
            Saver = saver;
            Converter = converter;
            Checker = checker;
        }
        public string Load(string filename)
        {
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
            Converter convert = new SokobanConsoleGame.Converter();
            if (type == ConversionType.expand)
            {
                convert.Expand(input);
                input = convert.Expanded;
            }
            else
            {
                convert.Compress(input);
                input = convert.Compressed;
            }
            return input;
        }
        public bool PreExpandingCheck(string input)
        {
            Converter convert = new SokobanConsoleGame.Converter();
            string temp = convert.ExpandObjects(input);
            return checkPlayersGoalsBlocks(temp);
        }
        public bool PreCompressingCheck(string input)
        {
            bool check = checkLineLengths(input);
            if (check) { check = checkPlayersGoalsBlocks(input); }
            return check;
        }

        public bool checkLineLengths(string input)
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

        private bool checkPlayersGoalsBlocks(string input)
        {
            bool playerCheck = false;
            bool GoalBlockCheck = false;
            playerCheck = CheckOnePlayer(input);
            GoalBlockCheck = checkGoalsAgainstPlayers(input);
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
        private bool checkGoalsAgainstPlayers(string input)
        {
            int goalCount = input.Count(f => f == '.');
            goalCount += input.Count(f => f == '*');
            int boxCount = input.Count(f => f == '$');
            boxCount += input.Count(f => f == '*');
            this.noGoals = goalCount;
            this.NoBoxes = boxCount;
            if (boxCount == goalCount && boxCount > 0)
                return true;
            else return false;
        }
    }
}
