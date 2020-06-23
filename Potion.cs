using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Potion
    {
        private int increaseAmount;
        public Potion(int amount)
        {
            increaseAmount = amount;
        }

        public void healthPotion(Pokemon pokemon)
        {
            //pokemon.IncHP(increaseAmount);
            pokemon.HealthPoints += increaseAmount;
        }
    }
}
