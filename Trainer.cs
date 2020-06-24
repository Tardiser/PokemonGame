using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Trainer
    {
        private List<Potion> potions = new List<Potion> { };
        private List<Pokeball> pokeballs = new List<Pokeball> { };

        public int Gold { get; set; } = 100;

        public Trainer()
        {

        }

        public Trainer(List<Pokemon> poks, List<Potion> pots, List<Pokeball> pokballs)
        {
            Pokemons = poks;
            potions = pots;
            pokeballs = pokballs;
        }

        public string Name { get; set; }

        public List<Pokemon> Pokemons { get; } = new List<Pokemon> { };

        public void addPokemon(Pokemon pokemon, int index)
        {
            if (Pokemons.Count < 6)
            {
                Pokemons.Add(pokemon);
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
            Console.WriteLine("\nWhat do you wanna do now?");
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
                PokeCenter.Enter();
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
                int rand = random.Next(0, Program.pokemons.Count - 1);
                Encounter(Program.pokemons[rand], rand);
            }
            else
            {
                Console.WriteLine("Congratulations! You've caught all of the Pokemons!");
                Console.WriteLine("YOU WIN!!!");
                Environment.Exit(0);
            }

        }

        public void Encounter(Pokemon rival, int index)
        {

            Console.WriteLine("You've encountered a Wild Pokemon: " + rival.Name);
            Console.WriteLine("Please, choose your Pokemon: ");
            for (int i = 0; i < Pokemons.Count; i++)
            {
                Console.WriteLine($"{i+1} - {Pokemons[i].Name} {Pokemons[i].HealthPoints} / {Pokemons[i].BaseHealth}");
            }
            Pokemon pokemon = Pokemons[int.Parse(Console.ReadLine()) - 1];

            while (!rival.isFainted)
            {
                Console.WriteLine("\nWhat do you wanna do? (1 - Fight, 2 - Use Item, 3 - Change Pokemon): ");
                string choice = Console.ReadLine();
                if (choice.Equals("1"))
                {

                    pokemon.Attack(rival);
                    if (rival.isFainted)
                    {
                        Console.WriteLine($"{rival.Name} is fainted! You wanna try to catch it?");
                        Console.WriteLine("1 - Use PokeBall");
                        Console.WriteLine("2 - Continue");
                        if (Console.ReadLine().Equals("1"))
                        {
                            // Items could be another class, like inventory maybe?
                            // You could call usePokeball method of that class in here.
                        }
                        else
                        {
                            Gold += 25;
                            Journey();
                        }
                        break;
                    }

                }
                else if (choice.Equals("2"))
                {
                    UseItem(pokemon, rival, index);
                    if (!rival.Wild)
                    {
                        Gold += 50;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Choose your Pokemon: ");
                    for (int i = 0; i < Pokemons.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {Pokemons[i].Name} {Pokemons[i].HealthPoints} / {Pokemons[i].BaseHealth}");
                    }
                    pokemon = Pokemons[int.Parse(Console.ReadLine()) - 1];
                }


                rival.Attack(pokemon);
                if (pokemon.isFainted)
                {
                    Console.WriteLine("Your Pokemon is fainted. Please, choose another one!");
                    bool gameOver = true;
                    for (int i = 0; i < Pokemons.Count; i++)
                    {
                        if (!Pokemons[i].isFainted)
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
                    for (int i = 0; i < Pokemons.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {Pokemons[i].Name} {Pokemons[i].HealthPoints} / {Pokemons[i].BaseHealth}");
                    }
                    pokemon = Pokemons[int.Parse(Console.ReadLine()) - 1];
                }
            }
            Journey();

        }

        public void UseItem(Pokemon pokemon, Pokemon rival, int rivalIndex)
        {
            Console.WriteLine("What do you wanna use? (1 - Potion, 2 - Pokeball): ");

            if (Console.ReadLine().Equals("1"))
            {
                if (potions.Count > 0)
                {
                    potions[0].usePotion(pokemon);
                    potions.RemoveAt(potions.Count - 1);
                    Console.WriteLine($"You've got {potions.Count} potions left in your inventory!");
                }
                else
                {
                    Console.WriteLine($"You don't have any potions. You could buy one from the PokeCenter.");
                }

            }
            else
            {
                if (pokeballs.Count > 0)
                {
                    pokeballs[0].Catch(rival, rivalIndex);
                    pokeballs.RemoveAt(pokeballs.Count - 1);
                    Console.WriteLine($"You've got {pokeballs.Count} pokeballs left in your inventory!");
                }
                else
                {
                    Console.WriteLine($"You don't have any pokeballs. You could buy one from the PokeCenter.");
                }
            }
        }
    }
}
