using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Potion
    {

        public void usePotion(Pokemon pokemon)
        {
            Console.WriteLine($"Your Pokemon's HP increased by 20 points.");
            pokemon.HealthPoints += 20;
            if (pokemon.HealthPoints > pokemon.BaseHealth)
            {
                pokemon.HealthPoints = pokemon.BaseHealth;
            }
        }
    }
}
