using System.ServiceModel;
using PokemonApi.Dtos;


namespace PokemonApi.Services
{
[ServiceContract (Name = "PokemonService", Namespace = "http://pokemon-api/pokemon-service" )]
    public interface IPokemonService
    {
        [OperationContract]
        Task<PokemonResponseDto> GetPokemonById(Guid id, CancellationToken cancellationToken);

        [OperationContract]
        Task<bool> DeletePokemon(Guid id, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<PokemonResponseDto> CreatePokemon(CreatePokemonDto createPokemonDto, CancellationToken cancellationToken);

        [OperationContract]
        Task<PokemonResponseDto> UpdatePokemon(UpdatePokemonDto pokemon, CancellationToken cancellationToken);


         [OperationContract]
<<<<<<< HEAD
         Task<PokemonResponseDto> GetPokemonByName(string name,CancellationToken cancellationToken);
=======
         Task<List<PokemonResponseDto>> GetPokemonByName(string name,CancellationToken cancellationToken);

>>>>>>> 8d421da23b5c10fd10253551a2ef077f60f8d007
    }
}