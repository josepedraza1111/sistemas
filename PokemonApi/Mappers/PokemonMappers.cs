using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

public static class PokemonMappers
{
    public static Pokemon ToModel(this PokemonEntity entity)
    {
        if (entity is null)
        {
            return null;
        }
        return new Pokemon
        {
            Id = entity.Id,
            Name = entity.Name,
            Level = entity.Level,
            Type = entity.Type,
            Stats = new Stats
            {
                Attack = entity.Attack,
                Defense = entity.Defense,
                Speed = entity.Speed,
                Height = entity.Height
            }
        };
    }

    public static Hobby ToModel(this HobbysEntity entity)
    {
        if (entity is null)
        {
            return null;
        }
        return new Hobby
        {
            Id = entity.Id,
            Name = entity.Name,
            Top = entity.Top
        };
    }

    public static PokemonResponseDto ToDto(this Pokemon pokemon)
    {
        return new PokemonResponseDto
        {
            Id = pokemon.Id,
            Level = pokemon.Level,
            Name = pokemon.Name,
            Type = pokemon.Type,
            Stats = new StatsDto
            {
                Attack = pokemon.Stats.Attack,
                Defense = pokemon.Stats.Defense,
                Speed = pokemon.Stats.Speed,
                Height = pokemon.Stats.Height
            }
        };
    }

    public static HobbysResponseDto ToDto(this Hobby hobby)
    {
        return new HobbysResponseDto
        {
            Id = hobby.Id,
            Name = hobby.Name,
            Top = hobby.Top
        };
    }

    public static PokemonEntity ToEntity(this Pokemon pokemon)
    {
        return new PokemonEntity
        {
            Id = pokemon.Id,
            Name = pokemon.Name,
            Type = pokemon.Type,
            Level = pokemon.Level,
            Attack = pokemon.Stats.Attack,
            Defense = pokemon.Stats.Defense,
            Speed = pokemon.Stats.Speed,
            Height = pokemon.Stats.Height
        };
    }

    public static HobbysEntity ToEntity(this Hobby hobby)
    {
        return new HobbysEntity
        {
            Id = hobby.Id,
            Name = hobby.Name,
            Top = hobby.Top
        };
    }
}
