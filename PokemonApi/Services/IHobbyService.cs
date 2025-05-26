using System.ServiceModel;

using HobbyApi.Dtos;

[ServiceContract(Name ="JoseMariaPedrazaTorres",Namespace ="http://hobby-api/hobby-service")]
public interface IHobbyService
{
        [OperationContract ]
        Task<HobbysResponseDto> GetHobbyById(int id,CancellationToken cancellationToken);

        [OperationContract ]
        Task<bool> DeleteHobbyById(int id, CancellationToken cancellationToken);


        [OperationContract]
        Task<HobbysResponseDto> GetHobbyByName(string name, CancellationToken cancellationToken);


           [OperationContract]
        Task<HobbysResponseDto> CreateHobby(CreateHobbyDto createHobbieDto,CancellationToken cancellationToken);

        [OperationContract]
        Task<HobbysResponseDto> UpdateHobby(UpdateHobbyDto hobbie,CancellationToken cancellationToken);

}