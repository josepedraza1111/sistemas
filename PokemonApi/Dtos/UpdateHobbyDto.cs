using System.Runtime.Serialization;

namespace HobbyApi.Dtos;


    [DataContract(Name = "UpdateHobbyDto", Namespace = "http://hobby-api/hobby-service")]
    public class UpdateHobbyDto : HobbyCommon
    {
<<<<<<< HEAD
        [DataMember(Name = "Id", Order = 1)]
        public int Id { get; set; }
=======
        [DataMember(Name = "Id", Order = 3)]

        public Guid Id { get; set; }
>>>>>>> 8d421da23b5c10fd10253551a2ef077f60f8d007
    }

