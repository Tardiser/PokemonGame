using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Inventory
    {

        public List<Potion> potions = new List<Potion> { };
        public List<Pokeball> pokeballs = new List<Pokeball> { };
        public List<Pokemon> Pokemons { get; } = new List<Pokemon> { };
        public Inventory() { }

        public void Potions()
        {

        }

        public void addPokemon(Pokemon pokemon, int index)
        {
            if (Pokemons.Count < 6)
            {
                Pokemons.Add(pokemon);
            }
            else
            {
                Console.WriteLine("Your bag is full! Pokemon has been sent to PokeCenter!");
            }
            Program.pokemons.RemoveAt(index);

        }

        public void addPotion(Potion potion)
        {
            if (potions.Count < 6)
            {
                potions.Add(potion);
            }
            else
            {
                Console.WriteLine("Your bag is full!");
            }
        }

        public void addPokeball(Pokeball pokeball)
        {
            if (pokeballs.Count < 6)
            {
                pokeballs.Add(pokeball);
            }
            else
            {
                Console.WriteLine("Your bag is full!");
            }
        }

        public void UsePokeball(Pokemon rival, int rivalIndex)
        {
            if (pokeballs.Count > 0)
            {
                pokeballs[0].Catch(rival, rivalIndex);
            }
            else
            {
                Console.WriteLine($"You don't have any pokeballs. You could buy one from the PokeCenter.");
            }
        }

        public void UsePotion(Pokemon pokemon)
        {
            if (potions.Count > 0)
            {
                potions[0].usePotion(pokemon);
                potions.RemoveAt(potions.Count - 1);
                Console.WriteLine($"You've got {potions.Count} potions left in your inventory!");
            }
            else
            {
                Console.WriteLine($"You don't have any potions. You could buy one from the PokeCenter.");
            }
        }

        public void UseItem(Pokemon pokemon, Pokemon rival, int rivalIndex)
        {
            Console.WriteLine("What do you wanna use? (1 - Potion, 2 - Pokeball): ");

            if (Console.ReadLine().Equals("1"))
            {
                UsePotion(pokemon);
            }
            else
            {
                UsePokeball(rival, rivalIndex);
            }
        }

    }
}
