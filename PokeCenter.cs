using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Pokemon
{
    class PokeCenter
    {

        public static void Enter()
        {
            Console.WriteLine("\n--------------------------------");
            Console.WriteLine("Welcome to the PokeCenter! What do you wanna do?");
            Console.WriteLine("1 - Go to the Shop");
            Console.WriteLine("2 - Go to the Healer");
            Console.WriteLine("3 - Exit PokeCenter");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Shop();
            }
            else if(choice == 2)
            {
                Healer();
            }
            else
            {
                Game.trainer.Journey();
            }
        }
        
        public static void Shop()
        {
            while (true)
            {

                Console.WriteLine($"\nYou've got {Game.trainer.Gold}G!");
                Console.WriteLine("\nWhat do you wanna buy?");
                Console.WriteLine("1 - Potions");
                Console.WriteLine("2 - Pokeballs");
                Console.WriteLine("3 - Go back to the PokeCenter");

                string choice = Console.ReadLine();
                if (choice.Equals("1")) 
                {
                    Console.WriteLine("\nBuy 1 Potion for 25G? (1 - Yes, 2 - Cancel)");
                    if (Console.ReadLine().Equals("1"))
                    {
                        if (Game.trainer.Gold >= 25)
                        {
                            Game.trainer.Gold -= 25;
                            Potion potion = new Potion();
                            Game.trainer.addPotion(potion);
                        }
                        else { Console.WriteLine("You don't have enough gold!"); }
                    }
                    else { continue; }
                }
                else if (choice.Equals("2"))
                {
                    Console.WriteLine("\nBuy 1 Pokeball for 25G? (1 - Yes, 2 - Cancel)");
                    if (Console.ReadLine().Equals("1"))
                    {
                        if(Game.trainer.Gold >= 25)
                        {
                            Game.trainer.Gold -= 25;
                            Pokeball pokeball = new Pokeball();
                            Game.trainer.addPokeball(pokeball);
                        }
                        else { Console.WriteLine("You don't have enough gold!"); }
                        
                    }
                    else { continue; }
                }
                else { break; }
            }
            Enter();
        }

        public static void Healer()
        {
            Console.WriteLine($"\nYou've got {Game.trainer.Gold}G!");
            Console.WriteLine("\nWelcome to the Healer!");
            Console.WriteLine("Heal:");
            for(int i = 0; i < Game.trainer.Pokemons.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {Game.trainer.Pokemons[i].Name} HP: {Game.trainer.Pokemons[i].HealthPoints} / {Game.trainer.Pokemons[i].BaseHealth} (25G)");
            }
            Console.WriteLine($"{Game.trainer.Pokemons.Count} - Heal All ({Game.trainer.Pokemons.Count * 25}G)");
            Console.WriteLine($"{Game.trainer.Pokemons.Count + 1} - Go back to the PokeCenter");
            int choice = int.Parse(Console.ReadLine());
            if(choice == Game.trainer.Pokemons.Count + 1)
            {
                if(Game.trainer.Gold >= Game.trainer.Pokemons.Count * 25)
                {
                    for (int i = 0; i < Game.trainer.Pokemons.Count; i++)
                    {
                        Game.trainer.Pokemons[i].HealthPoints = Game.trainer.Pokemons[i].BaseHealth;
                    }
                    Game.trainer.Gold -= Game.trainer.Pokemons.Count * 25;
                    Enter();
                }
                else
                {
                    Console.WriteLine("You don't have enough gold to heal all of your Pokemons!");
                    Enter();
                }
   
            }

            else if(choice == Game.trainer.Pokemons.Count + 2)
            {
                Enter();
            }
            else
            {
                if(Game.trainer.Gold >= 25)
                {
                    Game.trainer.Pokemons[choice - 1].HealthPoints = Game.trainer.Pokemons[choice - 1].BaseHealth;
                    Game.trainer.Gold -= 25;
                    Console.WriteLine("Pokemon healed back to max health");
                    Enter();
                }
                else
                {
                    Console.WriteLine("You don't have enough gold to heal your Pokemon!");
                    Enter();
                }
                
            }

        }

    }
}
