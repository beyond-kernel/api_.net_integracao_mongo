using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pokedex_api.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Microsoft.AspNetCore.Authorization;

namespace pokedex_api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/Pokedex/[action]")]
    public class PokedexController
    {
        [HttpGet]
        public IEnumerable<Pokemon> GetPokemonList()
        {
            var client = new MongoClient(
                        "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false"
                    );

            var database = client.GetDatabase("pokemon_center");

            var pokemonCollection = database.GetCollection<Pokemon>("pokemon");

            var PokemonsDocumets = pokemonCollection.AsQueryable<Pokemon>().ToList();

            var pokemons = new List<Pokemon>();

            foreach (var pokemon in PokemonsDocumets)
            {
                pokemons.Add(new Pokemon(){  
                    Id = pokemon.Id,
                    Types = pokemon.Types,
                    Name = pokemon.Name,  
                    Legendary = pokemon.Legendary,
                    Hp = pokemon.Hp,
                    Attack = pokemon.Attack,
                    Defense = pokemon.Defense,
                    Speed = pokemon.Speed,
                    Generation = pokemon.Generation
                });
             
            }   


            return pokemons;
        }

        [HttpPost]
        public Pokemon GetPokemonByName([FromBody] string name)
        {
            var client = new MongoClient(
                      "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false"
                  );
            
            var database = client.GetDatabase("pokemon_center");
            

            var pokemonCollection = database.GetCollection<Pokemon>("pokemon");

            var PokemonsDocumets = pokemonCollection.AsQueryable<Pokemon>().ToList();

            return PokemonsDocumets.Find(n => n.Name == name);
        }
    }
}