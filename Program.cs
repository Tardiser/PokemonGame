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
            PokemonDB.RetrievePokemons(path, pokemons);

            Console.WriteLine("Pokemon1 = " + pokemons[0].Name + " Pokemon2 = " + pokemons[1].Name + " Last Pokemon = " + pokemons[pokemons.Count - 1].Name);

            Game newgame = new Game();
            newgame.NewGame();
           
            /*
            Potion potion = new Potion(20);
            Pokeball pokeball = new Pokeball();
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
