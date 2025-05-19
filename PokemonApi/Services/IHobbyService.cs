using System.ServiceModel;

using HobbyApi.Dtos;

[ServiceContract(Name ="JoseMariaPedrazaTorres",Namespace ="http://hobby-api/hobby-service")]
public interface IHobbyService
{
        [OperationContract ]
        Task<HobbysResponseDto> GetHobbyById(Guid id,CancellationToken cancellationToken);

        [OperationContract ]
        Task<bool> DeleteHobbyById(Guid id, CancellationToken cancellationToken);


        [OperationContract]
         Task<List<HobbysResponseDto>> GetHobbyByName(string name,CancellationToken cancellationToken);

           [OperationContract]
        Task<HobbysResponseDto> CreateHobby(CreateHobbyDto createHobbieDto,CancellationToken cancellationToken);

        [OperationContract]
        Task<HobbysResponseDto> UpdateHobby(UpdateHobbyDto hobbie,CancellationToken cancellationToken);

}