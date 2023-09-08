using ConsoleTables;
using Newtonsoft.Json;
using PokeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPI.Pokemon
{
    public static class Pokemon
    {
        public static async Task<PokemonDTO> GetListPokemones(string url)
        {
            PokemonDTO pokemonResponse = new PokemonDTO();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonContent = await response.Content.ReadAsStringAsync();
                        pokemonResponse = JsonConvert.DeserializeObject<PokemonDTO>(jsonContent);
                        return pokemonResponse;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }            
            }
            return pokemonResponse;
        }


        public static async Task GetListPokemonesDetails(string url)
        {
            var listPokemones = await GetListPokemones(url);
            var table = new ConsoleTable("Nombre", "Tipos", "Habilidades");

            using (var client = new HttpClient())
            {
                try
                {
                    foreach (var pokemon in listPokemones.results)
                    {
                        var response = await client.GetAsync(pokemon.url);
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonContent = await response.Content.ReadAsStringAsync();
                            PokemonResponseDetails pokemonResponseDetails = JsonConvert.DeserializeObject<PokemonResponseDetails>(jsonContent);
                            table.AddRow(pokemonResponseDetails.name, GetTypes(pokemonResponseDetails), GetAbilities(pokemonResponseDetails));
                        }
                    }
                }catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message); 
                }
                
            }
            Console.WriteLine(table);
        }

        public static async Task GetListPokemonesDetails(string url,List<string> Pokemons)
        {
            var listPokemones = await GetListPokemones(url);
 
            listPokemones.results = listPokemones.results.Where(x => Pokemons.Contains(x.name)).ToList();
            
            
            var table = new ConsoleTable("Nombre", "Tipos", "Habilidades");

            using (var client = new HttpClient())
            {
                try
                {

                    foreach (var pokemon in listPokemones.results)
                    {
                        var response = await client.GetAsync(pokemon.url);
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonContent = await response.Content.ReadAsStringAsync();
                            PokemonResponseDetails pokemonResponseDetails = JsonConvert.DeserializeObject<PokemonResponseDetails>(jsonContent);
                            table.AddRow(pokemonResponseDetails.name, GetTypes(pokemonResponseDetails), GetAbilities(pokemonResponseDetails));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            Console.WriteLine(table);
        }
        private static object GetAbilities(PokemonResponseDetails pokemonResponseDetails)
        {
            List<string> abilities = new List<string>();
            foreach (var ability in pokemonResponseDetails.abilities)
            {
                abilities.Add(ability.ability.name);
            }
            return String.Join("-", abilities);
        }

        private static string GetTypes(PokemonResponseDetails pokemonResponseDetails)
        {
            List<string> types = new List<string>();
            foreach (var type in pokemonResponseDetails.types)
            {
                types.Add(type.type.name);
            }
            return String.Join("-", types);
        }

    }
}
