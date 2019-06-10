using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            var trainers = new List<Trainer>();

            while ((line = Console.ReadLine()) != "Tournament")
            {
                var lineSplit = line.Split();
                var trainerName = lineSplit[0];
                var pokemonName = lineSplit[1];
                var pokemonElement = lineSplit[2];
                var pokemonHealth = int.Parse(lineSplit[3]);

                var trainer = trainers.FirstOrDefault(x => x.Name == trainerName);

                var pokemon = new Pokemon
                {
                    Name = pokemonName,
                    Element = pokemonElement,
                    Health = pokemonHealth
                };

                if (trainer != null)
                {
                    trainer.Pokemons.Add(pokemon);
                }
                else
                {
                    trainers.Add(new Trainer
                    {
                        Name = trainerName,
                        Pokemons = new List<Pokemon>() { pokemon }
                    });
                }
            }

            while ((line = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == line))
                    {
                        trainer.NumberOfBadges += 1;
                    }
                    else
                    {
                        var newPokemons = new List<Pokemon>();

                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;

                            if (pokemon.Health <= 0)
                            {
                                continue;
                            }

                            newPokemons.Add(pokemon);
                        }

                        trainer.Pokemons = newPokemons;
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
