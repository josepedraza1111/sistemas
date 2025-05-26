using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;


namespace PokemonApi.Mappers;

public static class PokemonMapper{
    public static PokemonEntity ToEntity(this Pokemon pokemon){
        return new PokemonEntity{
            Id = pokemon.Id,
            Name = pokemon.Name,
            Level = pokemon.Level,
            Type = pokemon.Type,
            Height = pokemon.Height,
            Attack = pokemon.Stats.Attack,
            Defense = pokemon.Stats.Defense,
            Speed = pokemon.Stats.Speed,
            
        };
    }
    public static Pokemon ToModel(this PokemonEntity entity){
        if(entity is null){
            return null;
        }
        return new Pokemon{

            Id = entity.Id,
            Name = entity.Name,
            Level = entity.Level,
            Type = entity.Type,
<<<<<<< HEAD
            Height = entity.Height,
=======

>>>>>>> 8d421da23b5c10fd10253551a2ef077f60f8d007
            Stats = new Stats{

                Attack = entity.Attack,
                Defense = entity.Defense,
                Speed = entity.Speed,
            }
        };
    }

    public static PokemonResponseDto ToDto(this Pokemon pokemon){
        return new PokemonResponseDto{

            Id = pokemon.Id,
            Level = pokemon.Level,
            Name = pokemon.Name,
            Type = pokemon.Type,
<<<<<<< HEAD
            Height = pokemon.Height,
=======

>>>>>>> 8d421da23b5c10fd10253551a2ef077f60f8d007
            Stats = new StatsDto {

                Attack = pokemon.Stats.Attack,
                Defense = pokemon.Stats.Defense,
<<<<<<< HEAD
             
=======
                Speed = pokemon.Stats.Speed,

                Defense = pokemon.Stats.Defense,

                Height = pokemon.Stats.Height
>>>>>>> 8d421da23b5c10fd10253551a2ef077f60f8d007
            }
        };
    }


    public static Pokemon ToModel(this CreatePokemonDto pokemon)
    {
        return new Pokemon{
            Id=Guid.NewGuid(),
            Name = pokemon.Name,
            Type = pokemon.Type,
            Level = pokemon.Level,
<<<<<<< HEAD
            Height = pokemon.Height,
=======

>>>>>>> 8d421da23b5c10fd10253551a2ef077f60f8d007
            Stats = pokemon.Stats.ToModel()
        };
    }


    public static Stats ToModel (this StatsDto stats){
        return new Stats{
            Attack = stats.Attack,
            Defense = stats.Defense,
            Speed = stats.Speed,
        };
    }

<<<<<<< HEAD
   
=======
    public static List<Pokemon> ToModelList(this List<PokemonEntity> entities)
    {
        return entities?.Select(e => e.ToModel()).ToList() ?? new List<Pokemon>();
    }

    public static List<PokemonResponseDto> ToDtoList(this List<Pokemon> pokemons)
    {
        return pokemons?.Select(b => b.ToDto()).ToList() ?? new List<PokemonResponseDto>();

    }
>>>>>>> 8d421da23b5c10fd10253551a2ef077f60f8d007


}

