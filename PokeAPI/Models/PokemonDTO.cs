using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPI.Models
{
    public class PokemonDTO
    {
        public List<Results> results { get; set; }
    }

    public class Results
    {
        public string name { get; set; }
        public string  url { get; set; }
    }

    public class PokemonResponseDetails
    {
        public string name { get; set; }
        public List<TypesOf> types { get; set; }
        public List<AbilitiesOf> abilities { get; set; }
    }

    public class AbilitiesOf
    {
        public Ability ability { get; set; }
    }

    public class Ability
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class TypesOf
    {
        public Type type { get; set; }

    }

    public class Type
    {
        public string name { get; set; }
        public string url { get; set; }
    }




}
