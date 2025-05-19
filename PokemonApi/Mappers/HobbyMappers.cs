using HobbyApi.Models;
using HobbyApi.Infrastructure.Entities;
using HobbyApi.Dtos;
using Org.BouncyCastle.Crypto.Parameters;


namespace HobbyApi.Mappers;

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
        Id= new Random().Next(1,int.MaxValue),
        Name=hobby.Name,
        Top=hobby.Top,
    };
}

}