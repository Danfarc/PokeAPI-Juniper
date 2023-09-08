using ConsoleTables;
using Newtonsoft.Json;
using PokeAPI.Models;
using PokeAPI.Pokemon;

internal class Program
{
    private static async Task Main(string[] args)
    {
        
        string url = "https://pokeapi.co/api/v2/pokemon/";
        var listPokemones = await Pokemon.GetListPokemones(url);

        Console.WriteLine("Lista de Pokemones");
        foreach (var pokemon in listPokemones.results)
        {
            await Console.Out.WriteLineAsync(pokemon.name);
        }

        List<String> pokemons = new List<string>();
        pokemons.Add("bulbasaur");
        pokemons.Add("charmeleon");
        pokemons.Add("beedrill");


        await Pokemon.GetListPokemonesDetails(url, pokemons);

        
        
    }

}