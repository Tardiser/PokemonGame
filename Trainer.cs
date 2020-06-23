using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
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

        public void addPokemon(Pokemon pokemon, int index)
        {
            if (pokemons.Count < 6)
            {
                pokemons.Add(pokemon);
            }
            else
            {
                Console.WriteLine("Your bag is full! Pokemon has been sent to PokeCenter!");
            }
            Program.pokemons.RemoveAt(index);

        }

        public void addPotion(Potion potion)
        {
            if (potions.Count < 6)
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

        public void Journey()
        {
            Console.WriteLine("What do you wanna do now?");
            Console.WriteLine("1 - Wander around the Country");
            Console.WriteLine("2 - Go to PokeCenter");
            Console.WriteLine("3 - Save and Quit");
            int choice = int.Parse(Console.ReadLine());
            if (choice.Equals(1))
            {
                Wander();
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

        public void Wander()
        {
            Console.WriteLine("You've started to wander around the country!");
            Random random = new Random();
            int x = random.Next(1, 10);
            while (x > 0)
            {
                Console.WriteLine("...");
                System.Threading.Thread.Sleep(1000);
                x--;
            }
            if (Program.pokemons.Count > 0)
            {
                Encounter(Program.pokemons[random.Next(0, Program.pokemons.Count - 1)]);
            }
            else
            {
                Console.WriteLine("Congratulations! You've caught all of the Pokemons!");
                Console.WriteLine("YOU WIN!!!");
                Environment.Exit(0);
            }

        }

        public void Encounter(Pokemon rival)
        {
            Pokemon pokemon = pokemons[0];

            Console.WriteLine("You've encountered a Wild Pokemon: " + rival.Name);
            while (!rival.isFainted)
            {
                Console.WriteLine("What do you wanna do? (1 - Fight, 2 - Use Item, 3 - Change Pokemon): ");
                string choice = Console.ReadLine();
                if (choice.Equals("1"))
                {

                    pokemon.Attack(rival);
                    if (rival.isFainted)
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
                    for (int i = 0; i < pokemons.Count; i++)
                    {
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
            Journey();

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
}
