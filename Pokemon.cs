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

        public Pokemon(string pname, int basehp, int realhp, int att, int def, int spd, string type, int xp = 0, int lvl = 1, bool fainted = false)
        {
            BaseHealth = basehp;
            AttackPoints = att;
            DefencePoints = def;
            Speed = spd;
            Xp = xp;
            Type = type;
            Level = lvl;
            Name = pname;
            healthPoints = realhp;
        }

        public string Name { get; private set; }
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
        public int AttackPoints { get; private set; }

        public int DefencePoints { get; private set; }

        public int Speed { get; private set; }

        public string Type { get; private set; }

        public int Xp { get; set; }

        public int Level { get; set; }
        public bool isFainted { get; set; } = false;

        

        

        

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
            
            // System.Threading.Thread.Sleep(1000); // Comment out if fights are too fast
        }

        public void WildFainted(int index)
        {
            Console.WriteLine($"{Name} is fainted! Do you wanna try catching it?");
            Console.WriteLine("1 - Use PokeBall");
            Console.WriteLine("2 - Continue");
            if (Console.ReadLine().Equals("1"))
            {
                Game.trainer.Bag.UsePokeball(this, index);
            }
            else
            {
                Game.trainer.Gold += 25;
                this.isFainted = false;
                this.HealthPoints = this.BaseHealth;
                Game.trainer.Journey();
            }
        }

        public void PokemonFainted()
        {
            Console.WriteLine("Your Pokemon is fainted. Please, choose another one!");
            bool gameOver = true;
            for (int i = 0; i < Game.trainer.Bag.Pokemons.Count; i++)
            {
                if (!Game.trainer.Bag.Pokemons[i].isFainted)
                {
                    gameOver = false;
                    break;
                }
            }
            if (gameOver)
            {
                Console.WriteLine("All of your Pokemons are fainted!");
                Console.WriteLine("GAME OVER!");
                Environment.Exit(0);
            }
            for (int i = 0; i < Game.trainer.Bag.Pokemons.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {Game.trainer.Bag.Pokemons[i].Name} {Game.trainer.Bag.Pokemons[i].HealthPoints} / {Game.trainer.Bag.Pokemons[i].BaseHealth}");
            }
            
        }

    }
}
