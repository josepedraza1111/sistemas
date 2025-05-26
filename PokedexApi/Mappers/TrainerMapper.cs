using PokedexApi.Dtos;
using PokedexApi.Infraestructure.Grpc;
using PokedexApi.Models;

namespace PokedexApi.Mappers;

public static class TrainerMappers
{
    public static TrainerResponseDto ToDto(this Trainer trainer)
    {
        return new TrainerResponseDto
        {
            Id = trainer.Id,
            Name = trainer.Name,
            Age = trainer.Age,
            BirthDate = trainer.BirthDate,
            CreatedAt = trainer.CreatedAt,
            Medals = trainer.Medals.Select(s => new MedalDto
            {
                Region = s.Region,
                Type = s.Type
            }).ToList()
        };
    }

    public static Trainer ToModel(this TrainerResponse trainer)
    {
        return new Trainer
        {
            Id = trainer.Id,
            Name = trainer.Name,
            Age = trainer.Age,
            BirthDate = trainer.Birthdate.ToDateTime(),
            CreatedAt = trainer.CreatedAt.ToDateTime(),
            Medals = trainer.Medals.Select(s => new Medal
            {
                Region = s.Region,
                Type = s.Type.ToString()
            }).ToList()
        };
    }
}