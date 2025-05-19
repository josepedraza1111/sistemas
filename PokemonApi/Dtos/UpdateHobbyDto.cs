using System.Runtime.Serialization;

namespace HobbyApi.Dtos;

    [DataContract(Name = "UpdateHobbyDto", Namespace = "http://hobby-api/hobby-service")]
    public class UpdateHobbyDto : HobbyCommon
    {
        [DataMember(Name = "Id", Order = 1)]
        public int Id { get; set; }
    }

