using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SokobanConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Parts.Wall + " " + (char)Parts.Wall);
            Console.WriteLine(Parts.Goal + " " + (char)Parts.Goal);
            Console.WriteLine(Parts.Player + " " + (char)Parts.Player);
            Console.WriteLine(Parts.PlayerOnGoal + " " + (char)Parts.PlayerOnGoal);
            Console.WriteLine(Parts.Block + " " + (char)Parts.Block);
            Console.WriteLine(Parts.BlockOnGoal + " " + (char)Parts.BlockOnGoal);
            Console.WriteLine(Parts.Empty + " " + (char)Parts.Empty);
            Console.ReadKey();
        }
    }
}
