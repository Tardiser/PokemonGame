using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

namespace Pokemon
{
    class Pokemon
    {
        private int power = 50, healthPoints;
        private double modifier = 1;

        public Pokemon(string pname, int hp, int att, int def, int spd, string type, int xp = 0, int lvl = 1)
        {
            BaseHealth = hp;
            AttackPoints = att;
            DefencePoints = def;
            Speed = spd;
            Xp = xp;
            Type = type;
            Level = lvl;
            Name = pname;
            healthPoints = hp;
        }

        public bool isFainted { get; set; } = false;

        public int BaseHealth { get; }
        public int HealthPoints
        {
            get { return healthPoints; }
            set
            {
                healthPoints = value;
                if (healthPoints <= 0)
                {
                    healthPoints = 0;
                    isFainted = true;
                }
            }
        }

        public string Name { get; private set; }

        public int AttackPoints { get; private set; }

        public int DefencePoints { get; private set; }

        public int Speed { get; private set; }

        public string Type { get; private set; }

        public int Xp { get; set;}

        public int Level { get; set; }

        public void Attack(Pokemon rival)
        {
            Random random = new Random();
            modifier = random.NextDouble() * 0.15 + 0.85;
            int damage = Convert.ToInt32((((((Level * 2 / 5) + 2) * power * AttackPoints / rival.DefencePoints) / 50) + 2) * modifier);
            rival.HealthPoints -= damage;
            Console.WriteLine("\n\n");
            Console.WriteLine(Name + " inflicted " + damage + " damage to the " + rival.Name + "!");
            Console.WriteLine("---------------------------");
            if(Speed > rival.Speed)
            {
                Console.WriteLine($"{Name} HP: {HealthPoints} / {BaseHealth}");
                Console.WriteLine($"{rival.Name} HP: {rival.HealthPoints} / {rival.BaseHealth}");
            }
            else
            {
                Console.WriteLine($"{rival.Name} HP: {rival.HealthPoints} / {rival.BaseHealth}");
                Console.WriteLine($"{Name} HP: {HealthPoints} / {BaseHealth}");
            }      
            Console.WriteLine("---------------------------");
            // System.Threading.Thread.Sleep(1000); // Commemnt out if fights are too fast
        }

    }
}
