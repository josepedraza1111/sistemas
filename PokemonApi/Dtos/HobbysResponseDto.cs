using System.Runtime.Serialization;
namespace PokemonApi.Dtos;

[DataContract(Name = "HobbysDto", Namespace = "http://hobby-api/hobby-service")]
public class HobbysResponseDto
{
        [DataMember(Name = "Id", Order = 1)]
        public int Id { get; set; }

        [DataMember(Name = "Name", Order = 2)]
        public string Name { get; set; }

        [DataMember(Name = "Top", Order = 3)]
        public int Top { get; set; }
}