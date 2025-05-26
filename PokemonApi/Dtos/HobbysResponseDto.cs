using System.Runtime.Serialization;

namespace HobbyApi.Dtos;


[DataContract(Name = "HobbysDto", Namespace = "http://hobby-api/hobby-service")]
public class HobbysResponseDto
{
        [DataMember(Name = "Id", Order = 1)]
<<<<<<< HEAD
        public int Id { get; set; }
=======

        public Guid Id { get; set; }
>>>>>>> 8d421da23b5c10fd10253551a2ef077f60f8d007

        [DataMember(Name = "Name", Order = 2)]
        public string Name { get; set; }

        [DataMember(Name = "Top", Order = 3)]
        public int Top { get; set; }
}