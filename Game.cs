using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Pokemon
{
    class Game
    {
        public static Trainer trainer = new Trainer();
        PokemonDB x = PokemonDB.getInstance();
        
        public void NewGame()
        {
            string path = @"C:\Users\Erdem\source\repos\Pokemon\Pokemon\pokemonDB.csv";
            x.RetrievePokemons(path, Program.pokemons);
            Console.WriteLine("Please, enter your trainer's name: ");
            trainer.Name = Console.ReadLine();

            Potion potion = new Potion();
            Pokeball pokeball = new Pokeball();
            for(int i = 0; i < 3; i++)
            {
                trainer.Bag.addPotion(potion);
                trainer.Bag.addPokeball(pokeball);
            }

            Console.WriteLine("Please, choose a Pokemon (1 - Bulbasaur, 2 - Charmander, 3 - Squirtle): ");
            int index = int.Parse(Console.ReadLine()) - 1;
            trainer.Bag.addPokemon(Program.pokemons[index], index);
            Console.WriteLine("You've caught a " + trainer.Bag.Pokemons[0].Name + "!");
            trainer.Journey();

        }

        public void Continue()
        {
            string trainerPokemons = @"C:\Users\Erdem\source\repos\Pokemon\Pokemon\playerPokemonsSave.csv";
            string wildPokemons = @"C:\Users\Erdem\source\repos\Pokemon\Pokemon\wildPokemonsSave.csv";
            string storedPokemons = @"C:\Users\Erdem\source\repos\Pokemon\Pokemon\storedPokemonsSave.csv";

            x.RetrievePokemons(trainerPokemons, Game.trainer.Bag.Pokemons);
            x.RetrievePokemons(wildPokemons, Program.pokemons);
            x.RetrievePokemons(storedPokemons, PokeCenter.StoredPokemons);
            
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Erdem\source\repos\Pokemon\Pokemon\inventory.txt");
            Game.trainer.Gold = int.Parse(lines[0]);
            

            Console.WriteLine("Please, enter your trainer's name: ");
            trainer.Name = Console.ReadLine();

            Potion potion = new Potion();
            Pokeball pokeball = new Pokeball();
            for (int i = 0; i < int.Parse(lines[1]); i++)
            {
                trainer.Bag.addPokeball(pokeball);
            }
            for (int i = 0; i < int.Parse(lines[2]); i++)
            {
                trainer.Bag.addPotion(potion);
            }


            trainer.Journey();
        }
    }
}
