using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SokobanGame
{
    public class Converter : iConverter
    {
        public string Compressed{ get; set; }
        public string Expanded{ get; set; }
        public void Compress(string uncompressedLevel)
        {
            if (checkValidString(uncompressedLevel))
            {
                string str = Regex.Replace(uncompressedLevel, "\n", "|");
                str = Regex.Replace(str, "\\s", "-");
                str = CompressObjects(str);
                this.Compressed = str;
            }
            else this.Compressed = "";
        }
        public void Expand(string compressedLevel)
        {
            if (checkValidString(compressedLevel))
            {
                string str = Regex.Replace(compressedLevel, "-", " ");
                str = ExpandObjects(str);
                str = AddTrailingSpaces(str);
                str = str.TrimEnd(new char[] { '\r', '\n' });
                this.Expanded = str;
            }
            else this.Expanded = "";
        }
        private string AddTrailingSpaces(string compressedLevel)
        {
            int savedLength = 0;
            string[] lines = compressedLevel.Split('|');
            int length = lines[0].Length;
            savedLength = length;
            string result = "";
            // get maximum line length
            foreach (string line in lines)
            {
                if (length < line.Length)
                {
                    length = line.Length;
                }
            }
            foreach (string line in lines)
            {
                result += line;
                if (line.Length < length)
                {
                    int addSpaces = length - line.Length;
                    while (addSpaces > 0)
                    {
                        result += " ";
                        addSpaces -= 1; 
                    }
                }
                result += "\n";
            }
            return result;
        }
        public string ExpandObjects(string source)
        {
            char lastSeen = source.First();
            bool first = true;
            string expandedString = "";
            string number = "";
            foreach (var c in source.Skip(1))
            {
                if (Char.IsDigit(lastSeen))
                {
                    number += lastSeen;
                    if (!Char.IsDigit(c))
                    {
                        for (int i = 0; i < Int32.Parse(number); i++)
                        {
                            expandedString += c;
                            first = false;
                        }
                        number = "";
                    }
                }
                else
                {
                    if (first)
                    {
                        expandedString += lastSeen;
                        first = false;
                    }
                    if (!Char.IsDigit(c))
                        expandedString += c;
                }
                lastSeen = c;
            }
            return expandedString;
        }
        public bool checkValidString(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 1)
                return false;
            return true;
        }
        private string CompressObjects(string source)
        {
            char lastSeen = source.First();
            int count = 1;
            string compressedString = "";
            foreach (var c in source.Skip(1))
            {   
                if (lastSeen == c)
                {
                    count++;
                }
                else
                {
                    if (checkIfSpaceBeforePipe(lastSeen, c))
                    {
                        compressedString = addGroup(compressedString, count, lastSeen);
                    }
                    count = 1;
                    lastSeen = c;
                }
            }
            if (lastSeen != '-')
            {
                compressedString = addGroup(compressedString, count, lastSeen);
            }
            return compressedString;
        }
        private string addGroup(string input, int count, char lastSeen)
        {
            if (count > 1)
            {
                input += count.ToString();
            }
            input += lastSeen;
            return input;
        }
        private bool checkIfSpaceBeforePipe(char lastSeen, char c)
        {
            if (c == '|')
            {
                if (lastSeen == '-')
                    return false;
                else return true;
            }
            return true;
        }
    }
}
