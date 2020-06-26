using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace Pokemon
{
    class PokemonDB
    {
        // Using Singleton design pattern to obtain data from a csv file.
        private static PokemonDB instance = new PokemonDB();

        private PokemonDB() { }

        public static PokemonDB getInstance() { return instance; }
        public void RetrievePokemons(string path, List<Pokemon> pokemons)
        {
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {

                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();


                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    Pokemon pokemon = new Pokemon(fields[0], int.Parse(fields[1]), int.Parse(fields[2]), int.Parse(fields[3]), int.Parse(fields[4]), int.Parse(fields[5]), fields[6]);
                    pokemons.Add(pokemon);
                }
            }
        }

    }
}
