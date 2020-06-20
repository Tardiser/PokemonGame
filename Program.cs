using System;

namespace Pokemon
{

    class Pokemon
    {
        private int attack, defence, speed, healthPoints, exPoints, level;
        private string pokemonType;
        private int power = 50;
        private double modifier = 1;
        
        public Pokemon(int att, int def, int spd, int hp, int xp, string type, int lvl = 1)
        {
            attack = att;
            defence = def;
            speed = spd;
            healthPoints = hp;
            exPoints = xp;
            pokemonType = type;
            level = lvl;
        }

        public int HealthPoints
        {
            get { return healthPoints; }
            set { healthPoints = value; }
        }

        public int AttackPoints
        {
            get { return attack; }
        }

        public int DefencePoints
        {
            get { return defence; }
        }

        public void Attack(Pokemon rival)
        {
            Random random = new Random();
            modifier *= random.NextDouble() * 0.15 + 0.85;
            int damage = Convert.ToInt32((((((level * 2 / 5) + 2) * power * attack / rival.DefencePoints) / 50) + 2) * modifier);
            rival.HealthPoints -= damage;
        }
    }

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

    class Pokeball
    {

    }

    class Trainer
    {
        private Pokemon[] pokemons;
        private Potion[] potions;
        private Pokeball[] pokeballs;

        public Trainer()
        {

        }

        public Trainer(Pokemon[] poks, Potion[] pots, Pokeball[] pokballs)
        {
            pokemons = poks;
            potions = pots;
            pokeballs = pokballs;
        }

        public void UseItem()
        {
            Console.WriteLine("What do you wanna use? (potion / pokeball): ");
            
            if (Console.ReadLine().Equals("potion"))
            {
                Console.WriteLine("Choose a potion from the inventory (1/2/3/4/5/6): ");
                potions[Int32.Parse(Console.ReadLine()) - 1].healthPotion(pokemons[0]);
            }
            else { }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Pokemon pika = new Pokemon(10,10,5,10,10,"electric");
            Console.WriteLine(pika.HealthPoints);
            Potion potion = new Potion(20);
            Pokeball pokeball = new Pokeball();
            Pokemon[] pokemons = { pika };
            Potion[] potions = { potion };
            Pokeball[] pokeballs = { pokeball };
            Trainer erdem = new Trainer(pokemons, potions, pokeballs);
            erdem.UseItem();
            Console.WriteLine(pika.HealthPoints);
            Console.WriteLine("Hello World!");
            Pokemon wildPoke = new Pokemon(10, 10, 5, 100, 10, "fire");
            Console.WriteLine(wildPoke.HealthPoints);
            pika.Attack(wildPoke);
            Console.WriteLine(wildPoke.HealthPoints);
            pika.Attack(wildPoke);
            Console.WriteLine(wildPoke.HealthPoints);
        }
    }
}
