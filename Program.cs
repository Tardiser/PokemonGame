using System;
using System.Collections.Generic;

namespace Pokemon
{

    class Pokemon
    {
        private int attack, defence, speed, healthPoints, exPoints, level;
        private string pokemonType, name;
        private int power = 50;
        private double modifier = 1;
        
        public Pokemon(string pname, int hp, int att, int def, int spd, string type, int xp = 0, int lvl = 1)
        {
            attack = att;
            defence = def;
            speed = spd;
            healthPoints = hp;
            exPoints = xp;
            pokemonType = type;
            level = lvl;
            name = pname;
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

        public string Name
        {
            get { return name; }
        }

        public void Attack(Pokemon rival)
        {
            Random random = new Random();
            modifier *= random.NextDouble() * 0.15 + 0.85;
            int damage = Convert.ToInt32((((((level * 2 / 5) + 2) * power * attack / rival.DefencePoints) / 50) + 2) * modifier);
            rival.HealthPoints -= damage;
            Console.WriteLine(name + " inflicted " +  damage + " damage to the " + rival.name + "!");
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
        private List<Pokemon> pokemons;
        private List<Potion> potions;
        private List<Pokeball> pokeballs;

        public Trainer()
        {

        }

        public Trainer(List<Pokemon> poks, List<Potion> pots, List<Pokeball> pokballs)
        {
            pokemons = poks;
            potions = pots;
            pokeballs = pokballs;
        }

        public void addPokemon(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
        }

        public void Encounter(Pokemon rival)
        {
            Pokemon pokemon = pokemons[0];

            Console.WriteLine("You've encountered a Wild Pokemon!");
            while(rival.HealthPoints > 0)
            {
                Console.WriteLine("What do you wanna do? (1 - Fight, 2 - Use Item, 3 - Change Pokemon): ");
                string choice = Console.ReadLine();
                if (choice.Equals("1"))
                {

                    pokemon.Attack(rival);
                    if(rival.HealthPoints <= 0)
                    {
                        break;
                    }

                }
                else if (choice.Equals("2"))
                {
                    UseItem();
                }
                else
                {
                    Console.WriteLine("Choose your Pokemon: ");
                    for(int i = 0; i < pokemons.Count; i++) {
                        Console.WriteLine(i + 1 + " - " + pokemons[i].Name);
                    }
                    pokemon = pokemons[int.Parse(Console.ReadLine()) - 1];
                }

                rival.Attack(pokemon);
            }
            
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

    class Game
    {
        string trainerName;

        public void NewGame(Pokemon[] startingPokemons, Trainer trainer)
        {
            Console.WriteLine("Please, enter your trainer's name: ");
            trainerName = Console.ReadLine();

            Console.WriteLine("Please, choose a Pokemon (1 - Bulbasaur, 2 - Charmander, 3 - Squirtle): ");
            
        
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Pokemon pika = new Pokemon("Pikachu", 10, 10, 5, 10, "electric");
            Console.WriteLine(pika.HealthPoints);
            Potion potion = new Potion(20);
            Pokeball pokeball = new Pokeball();
            List<Pokemon> pokemons = new List<Pokemon>{ pika };
            List<Potion> potions = new List<Potion>{ potion };
            List<Pokeball> pokeballs = new List<Pokeball>{ pokeball };
            Trainer erdem = new Trainer(pokemons, potions, pokeballs);
            erdem.UseItem();
            Console.WriteLine(pika.HealthPoints);
            Console.WriteLine("Hello World!");
            Pokemon wildPoke = new Pokemon("Wild Pokemon", 10, 10, 5, 10, "fire");
            Console.WriteLine(wildPoke.HealthPoints);
            erdem.Encounter(wildPoke);
            Console.WriteLine(wildPoke.HealthPoints);
            Console.WriteLine(pika.HealthPoints);
            erdem.addPokemon(wildPoke);
        }
    }
}
