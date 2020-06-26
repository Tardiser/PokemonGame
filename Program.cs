using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;

namespace Pokemon
{
    class Program
    {
        public static List<Pokemon> pokemons = new List<Pokemon> { };
        public static bool newGame = true;
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine("Choose one of the options below to start: ");
            Console.WriteLine("1 - New Game \n2 - Continue");
            if (Console.ReadLine().Equals("1"))
            {
                game.NewGame();
            }
            else
            {
                newGame = false;
                game.Continue();
            }
        }
    }
}
