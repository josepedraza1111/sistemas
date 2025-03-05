using System.Runtime.Serialization;

namespace PokemonApi.Dtos
{
    [DataContract(Name = "UpdateHobbyDto", Namespace = "http://hobby-api/hobby-service")]
    public class UpdateHobbyDto : HobbyCommon
    {
        [DataMember(Name = "Id", Order = 3)]
        public int Id { get; set; }
    }
}
