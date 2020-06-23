﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Game
    {
        Trainer trainer = new Trainer();

        public void NewGame()
        {
            Console.WriteLine("Please, enter your trainer's name: ");
            trainer.Name = Console.ReadLine();

            Console.WriteLine("Please, choose a Pokemon (1 - Bulbasaur, 2 - Charmander, 3 - Squirtle): ");
            int index = int.Parse(Console.ReadLine()) - 1;
            trainer.addPokemon(Program.pokemons[index], index);
            Console.WriteLine("You've caught a " + trainer.Pokemons[0].Name + "!");
            trainer.Wander();

        }
    }
}