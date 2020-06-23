using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;

namespace Pokemon
{
    class Program
    {
        public static List<Pokemon> pokemons = new List<Pokemon> { };
      
        static void Main(string[] args)
        {
            string path = @"C:\Users\Erdem\source\repos\Pokemon\Pokemon\pokemonDB.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {

                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();


                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    Pokemon pokemon = new Pokemon(fields[0], int.Parse(fields[1]), int.Parse(fields[2]), int.Parse(fields[3]), int.Parse(fields[4]), fields[5]);
                    pokemons.Add(pokemon);
                }
            }

            Console.WriteLine("Pokemon1 = " + pokemons[0].Name + " Pokemon2 = " + pokemons[1].Name + " Last Pokemon = " + pokemons[pokemons.Count - 1].Name);

            Game newgame = new Game();
            newgame.NewGame();

            /*Pokemon pika = new Pokemon("Pikachu", 10, 10, 5, 10, "electric");
            Console.WriteLine(pika.HealthPoints);
            Potion potion = new Potion(20);
            Pokeball pokeball = new Pokeball();
            List<Pokemon> pokemons = new List<Pokemon>{ pika };
            List<Potion> potions = new List<Potion>{ potion };
            List<Pokeball> pokeballs = new List<Pokeball>{ pokeball };
            Trainer erdem = new Trainer(pokemons, potions, pokeballs);
            erdem.UseItem();
            Console.WriteLine(pika.HealthPoints);
            Console.WriteLine("Hello World!");
            Pokemon wildPoke = new Pokemon("Wild Pokemon", 10, 20, 5, 10, "fire");
            Console.WriteLine(wildPoke.HealthPoints);
            erdem.Encounter(wildPoke);
            Console.WriteLine(wildPoke.HealthPoints);
            Console.WriteLine(pika.HealthPoints);
            erdem.addPokemon(wildPoke);*/
        }
    }
}
