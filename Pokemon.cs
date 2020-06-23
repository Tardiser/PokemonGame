using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Pokemon
    {
        private int attack, defence, speed, healthPoints, exPoints, level;
        private string pokemonType, name;
        private int power = 50;
        private double modifier = 1;
        private bool fainted = false;

        public Pokemon(string pname, int hp, int att, int def, int spd, string type, int xp = 0, int lvl = 1)
        {
            healthPoints = hp;
            attack = att;
            defence = def;
            speed = spd;
            exPoints = xp;
            pokemonType = type;
            level = lvl;
            name = pname;
        }

        public bool isFainted
        {
            get { return fainted; }
        }

        public int HealthPoints
        {
            get { return healthPoints; }
            set
            {
                healthPoints = value;
                if (healthPoints <= 0)
                {
                    healthPoints = 0;
                    fainted = true;
                }
            }
        }

        public int AttackPoints
        {
            get { return attack; }
        }

        public int DefencePoints
        {
            get { return defence; }
        }

        public string Name
        {
            get { return name; }
        }

        public void Attack(Pokemon rival)
        {
            Random random = new Random();
            modifier = random.NextDouble() * 0.15 + 0.85;
            int damage = Convert.ToInt32((((((level * 2 / 5) + 2) * power * attack / rival.DefencePoints) / 50) + 2) * modifier);
            rival.HealthPoints -= damage;
            Console.WriteLine("\n\n");
            Console.WriteLine(name + " inflicted " + damage + " damage to the " + rival.name + "!");
            Console.WriteLine("------------");
            Console.WriteLine(name + " HP: " + healthPoints);
            Console.WriteLine(rival.Name + " HP: " + rival.healthPoints);
            Console.WriteLine("------------");
        }

    }
}
