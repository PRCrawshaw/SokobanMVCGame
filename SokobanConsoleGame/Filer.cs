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
        //protected iLoader Loader;
        //protected iSaver Saver;
        public Converter Converter;
        //protected iChecker Checker;
        public int NoPlayers{ get; set; }
        public int NoGoals { get; set; }
        public int NoBoxes { get; set; }
        public Filer(Converter converter) 
        {
            //Loader = loader;
            //Saver = saver;
            Converter = converter;
            //Checker = checker;
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
            int goalCount = input.Count(f => f == '.');
            goalCount += input.Count(f => f == '*');
            int boxCount = input.Count(f => f == '$');
            boxCount += input.Count(f => f == '*');
            this.NoGoals = goalCount;
            this.NoBoxes = boxCount;
            if (boxCount == goalCount && boxCount > 0)
                return true;
            else return false;
        }
    }
}
