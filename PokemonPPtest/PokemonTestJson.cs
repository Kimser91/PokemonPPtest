using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPPtest
{
    internal class PokemonTestJson
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Health { get; private set; }
        public int Attack { get; private set; }
        public string Type { get; private set; }

        public PokemonTestJson(string name, int level, int health, int attack, string type)
        {
            Name = name;
            Level = level;
            Health = health;
            Attack = attack;
            Type = type;
        }
    }
}
