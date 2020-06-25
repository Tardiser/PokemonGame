using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Game
    {
        public static Trainer trainer = new Trainer();

        public void NewGame()
        {
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
            trainer.Wander();

        }
    }
}
