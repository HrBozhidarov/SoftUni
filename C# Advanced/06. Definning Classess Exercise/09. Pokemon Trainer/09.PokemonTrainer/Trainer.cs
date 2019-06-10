using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public ICollection<Pokemon> Pokemons { get; set; }
    }
}
