using PokemonApi.Models;
using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;


namespace PokemonApi.Mappers;

public static class HobbysMappers
{
    public static Hobby ToModel(this HobbysEntity entity){
        if(entity is null){
            return null;
        }
        return new Hobby{
            Id = entity.Id,
            Name = entity.Name,
            Top=entity.Top
        };

    }

public static HobbysResponseDto ToDto(this Hobby hobby){
return new HobbysResponseDto{
    Id=hobby.Id,
    Name=hobby.Name,
    Top=hobby.Top
};
}



public static HobbysEntity ToEntity(this Hobby hobbys){
    return new HobbysEntity{
        Id=hobbys.Id,
        Name=hobbys.Name,
        Top=hobbys.Top
    };
}

public static Hobby ToModel(this CreateHobbyDto hobby){
    return new Hobby{
        Name=hobby.Name,
        Top=hobby.Top,
    };
}

}