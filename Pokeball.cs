using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Pokemon
{
    class Pokeball
    {
        public void Catch(Pokemon pokemon, int index)
        {
            double catchProb = (9.0 * pokemon.BaseHealth - 8.0 * pokemon.HealthPoints) / (9.0 * pokemon.BaseHealth);
            Random random = new Random();

            if(random.NextDouble() < catchProb)
            {
                Game.trainer.Bag.addPokemon(pokemon, index);
                Console.WriteLine($"You've successfully caught a wild Pokemon: {pokemon.Name}");
                Game.trainer.Bag.pokeballs.RemoveAt(Game.trainer.Bag.pokeballs.Count - 1);
                Console.WriteLine($"You've got {Game.trainer.Bag.pokeballs.Count} pokeballs left in your inventory!");
                Game.trainer.Gold += 50;
                Game.trainer.Journey();
            }
            else
            {
                Game.trainer.Bag.pokeballs.RemoveAt(Game.trainer.Bag.pokeballs.Count - 1);
                Console.WriteLine($"You've got {Game.trainer.Bag.pokeballs.Count} pokeballs left in your inventory!");
                if (pokemon.HealthPoints == 0)
                {
                    pokemon.isFainted = false;
                    pokemon.HealthPoints = pokemon.BaseHealth;
                    Console.WriteLine($"You couldn't catch the Pokemon. {pokemon.Name} has escaped.");
                    Game.trainer.Journey();
                }
                else
                {
                    Console.WriteLine($"You couldn't catch the Pokemon, {pokemon.Name} strikes back");
                } 
            }
            
        }
    }
}
