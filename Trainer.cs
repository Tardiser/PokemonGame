using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Trainer
    {
        public string Name { get; set; }
        public int Gold { get; set; } = 100;
        public Inventory Bag { get; } = new Inventory();

        public Trainer() { }

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
                Save.SaveGame();
                Environment.Exit(0);
            }
        }

        public void Wander()
        {
            Console.WriteLine("\nYou've started to wander around the country!");
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
            Console.WriteLine("\nPlease, choose your Pokemon: ");
            for (int i = 0; i < Bag.Pokemons.Count; i++)
            {
                Console.WriteLine($"{i+1} - {Bag.Pokemons[i].Name} {Bag.Pokemons[i].HealthPoints} / {Bag.Pokemons[i].BaseHealth}");
            }
            Pokemon pokemon = Bag.Pokemons[int.Parse(Console.ReadLine()) - 1];

            while (!rival.isFainted)
            {
                Console.WriteLine("\nWhat do you wanna do? (1 - Fight, 2 - Use Item, 3 - Change Pokemon, 4 - Flee): ");
                string choice = Console.ReadLine();
                if (choice.Equals("1"))
                {
                    if(pokemon.Speed >= rival.Speed)
                    {
                        pokemon.Attack(rival);
                        if (rival.isFainted)
                        {
                            rival.WildFainted(index);
                            break;
                        }
                    }
                    else
                    {
                        rival.Attack(pokemon);
                        if (pokemon.isFainted)
                        {
                            rival.PokemonFainted();
                            pokemon = Game.trainer.Bag.Pokemons[int.Parse(Console.ReadLine()) - 1]; 
                        }
                        else
                        {
                            pokemon.Attack(rival);
                            if (rival.isFainted)
                            {
                                rival.WildFainted(index);
                            }
                        }
                        continue;
                    }
                }
                else if (choice.Equals("2"))
                {
                    Bag.UseItem(pokemon, rival, index);
                }
                else if(choice.Equals("2"))
                {
                    Console.WriteLine("Choose your Pokemon: ");
                    for (int i = 0; i < Bag.Pokemons.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {Bag.Pokemons[i].Name} {Bag.Pokemons[i].HealthPoints} / {Bag.Pokemons[i].BaseHealth}");
                    }
                    pokemon = Bag.Pokemons[int.Parse(Console.ReadLine()) - 1];
                }
                else
                {
                    rival.HealthPoints = rival.BaseHealth;
                    Journey();
                }

                rival.Attack(pokemon);
                if (pokemon.isFainted)
                {
                    rival.PokemonFainted();
                    pokemon = Game.trainer.Bag.Pokemons[int.Parse(Console.ReadLine()) - 1];
                }
            }
            Journey();

        }
        
    }
}
