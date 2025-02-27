using System.ServiceModel;
using PokemonApi.Dtos;
[ServiceContract(Name ="JoseMariaPedrazaTorres",Namespace ="http://hobbie-api/hobbie-service")]
public interface IHobbyService
{
        [OperationContract ]
        Task<HobbysResponseDto> GetHobbyById(int id,CancellationToken cancellationToken);

        [OperationContract ]
        Task<bool> DeleteHobbyById(int id, CancellationToken cancellationToken);

        [OperationContract]
         Task<List<HobbysResponseDto>> GetHobbyByName(string name,CancellationToken cancellationToken);

}