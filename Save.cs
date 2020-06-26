using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Pokemon
{
    public static class Save
    {
        public static void SaveGame()
        {
            using (var writer = new StreamWriter(@"C:\Users\Erdem\source\repos\Pokemon\Pokemon\playerPokemonsSave.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(Game.trainer.Bag.Pokemons); // Save Player's Pokemons
            }

            using (var writer = new StreamWriter(@"C:\Users\Erdem\source\repos\Pokemon\Pokemon\wildPokemonsSave.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(Program.pokemons); // Save All wild Pokemons
            }

            using (var writer = new StreamWriter(@"C:\Users\Erdem\source\repos\Pokemon\Pokemon\storedPokemonsSave.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(PokeCenter.StoredPokemons); // Save stored Pokemons
            }

            List<string> inventory = new List<string>() { Game.trainer.Gold.ToString(), Game.trainer.Bag.pokeballs.Count.ToString(), Game.trainer.Bag.potions.Count.ToString() };
            System.IO.File.WriteAllLines(@"C:\Users\Erdem\source\repos\Pokemon\Pokemon\inventory.txt", inventory);
        }
    }
}
