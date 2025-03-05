using System.Runtime.Serialization;
using PokemonApi.Dtos;

namespace PokemonApi.Dtos;
[DataContract(Name ="CreateHobbyDto", Namespace="http://hobby-api/hobby-service")]

public class CreateHobbyDto : HobbyCommon
{
    
}