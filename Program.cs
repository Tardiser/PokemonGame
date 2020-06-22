using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;

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
            Console.WriteLine(name + " inflicted " +  damage + " damage to the " + rival.name + "!");
            Console.WriteLine("------------");
            Console.WriteLine(name + " HP: " + healthPoints);
            Console.WriteLine(rival.Name + " HP: " + rival.healthPoints);
            Console.WriteLine("------------");
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
        private string name;
        private List<Pokemon> pokemons = new List<Pokemon> { };
        private List<Potion> potions = new List<Potion> { };
        private List<Pokeball> pokeballs = new List<Pokeball> { };

        public Trainer()
        {

        }

        public Trainer(List<Pokemon> poks, List<Potion> pots, List<Pokeball> pokballs)
        {
            pokemons = poks;
            potions = pots;
            pokeballs = pokballs;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
        }

        public void addPokemon(Pokemon pokemon, int index, List<Pokemon> allPokemons)
        {
            if(pokemons.Count < 6)
            {
                pokemons.Add(pokemon);
            }
            else
            {
                Console.WriteLine("Your bag is full! Pokemon has been sent to PokeCenter!");
            }
            allPokemons.RemoveAt(index);
            
        }

        public void addPotion(Potion potion)
        {
            if(potions.Count < 6)
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

        public void Journey(List<Pokemon> allPokemons)
        {
            Console.WriteLine("What do you wanna do now?");
            Console.WriteLine("1 - Wander around the Country");
            Console.WriteLine("2 - Go to PokeCenter");
            Console.WriteLine("3 - Save and Quit");
            int choice = int.Parse(Console.ReadLine());
            if (choice.Equals(1))
            {
                Wander(allPokemons);
            }
            else if (choice.Equals(2))
            {
                //PokeCenter(allPokemons);
            }
            else
            {
                //Save();
                Environment.Exit(0);
            }
        }

        public void Wander(List<Pokemon> allPokemons)
        {
            Console.WriteLine("You've started to wander around the country!");
            Random random = new Random();
            int x = random.Next(1, 10);
            while (x > 0)
            {
                Console.WriteLine("...");
                x--;
            }
            if(allPokemons.Count > 0)
            {
                Encounter(allPokemons[random.Next(0, allPokemons.Count - 1)], allPokemons);
            }
            else
            {
                Console.WriteLine("Congratulations! You've caught all of the Pokemons!");
                Console.WriteLine("YOU WIN!!!");
                Environment.Exit(0);
            }
            
        }

        public void Encounter(Pokemon rival, List<Pokemon> allPokemons)
        {
            Pokemon pokemon = pokemons[0];

            Console.WriteLine("You've encountered a Wild Pokemon: " + rival.Name);
            while(!rival.isFainted)
            {
                Console.WriteLine("What do you wanna do? (1 - Fight, 2 - Use Item, 3 - Change Pokemon): ");
                string choice = Console.ReadLine();
                if (choice.Equals("1"))
                {

                    pokemon.Attack(rival);
                    if(rival.isFainted)
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
                if (pokemon.isFainted)
                {
                    Console.WriteLine("Your Pokemon is fainted. Please, choose another one!");
                    bool gameOver = true;
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (!pokemons[i].isFainted)
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
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        Console.WriteLine(i + 1 + " - " + pokemons[i].Name);
                    }
                    pokemon = pokemons[int.Parse(Console.ReadLine()) - 1];
                }
            }
            Journey(allPokemons);
            
        }

        public void UseItem()
        {
            Console.WriteLine("What do you wanna use? (1 - Potion, 2 - Pokeball): ");
            
            if (Console.ReadLine().Equals("1"))
            {
                Console.WriteLine("Choose a potion from the inventory (1/2/3/4/5/6): ");
                potions[Int32.Parse(Console.ReadLine()) - 1].healthPotion(pokemons[0]);
            }
            else { }
        }
    }



    class Game
    {
        Trainer trainer = new Trainer();

        public void NewGame(List<Pokemon> pokemons)
        {
            Console.WriteLine("Please, enter your trainer's name: ");
            trainer.Name = Console.ReadLine();

            Console.WriteLine("Please, choose a Pokemon (1 - Bulbasaur, 2 - Charmander, 3 - Squirtle): ");
            int index = int.Parse(Console.ReadLine()) - 1;
            trainer.addPokemon(pokemons[index], index, pokemons);
            Console.WriteLine("You've caught a " + trainer.Pokemons[0].Name + "!");
            trainer.Wander(pokemons);
     
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            List<Pokemon> pokemons = new List<Pokemon> { }; // A list that will hold all of the pokemons in the database.

            var path = @"C:\Users\Erdem\source\repos\Pokemon\Pokemon\pokemonDB.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {

                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();


                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    Pokemon pokemon = new Pokemon(fields[0], int.Parse(fields[1]), int.Parse(fields[2]), int.Parse(fields[3]), int.Parse(fields[4]), fields[5]);
                    pokemons.Add(pokemon);
                }
            }

            Console.WriteLine("Pokemon1 = " + pokemons[0].Name + " Pokemon2 = " + pokemons[1].Name + " Last Pokemon = " + pokemons[pokemons.Count - 1].Name);

            Game newgame = new Game();
            newgame.NewGame(pokemons);

            /*Pokemon pika = new Pokemon("Pikachu", 10, 10, 5, 10, "electric");
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
            Pokemon wildPoke = new Pokemon("Wild Pokemon", 10, 20, 5, 10, "fire");
            Console.WriteLine(wildPoke.HealthPoints);
            erdem.Encounter(wildPoke);
            Console.WriteLine(wildPoke.HealthPoints);
            Console.WriteLine(pika.HealthPoints);
            erdem.addPokemon(wildPoke);*/
        }
    }
}
