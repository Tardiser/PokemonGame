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
                Game.trainer.addPokemon(pokemon, index);
                Console.WriteLine($"You've a successfully caught a wild Pokemon: {pokemon.Name}");
                pokemon.Wild = false;
            }
            else
            {
                if(pokemon.HealthPoints == 0)
                {
                    pokemon.isFainted = false;
                    pokemon.HealthPoints = pokemon.BaseHealth;
                    Console.WriteLine($"You couldn't catch the Pokemon. {pokemon.Name} has escaped.");
                }
                else
                {
                    Console.WriteLine($"You couldn't catch the Pokemon, {pokemon.Name} strikes back");
                }
                
            }
        }
    }
}
