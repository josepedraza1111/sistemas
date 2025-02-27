using PokemonApi.Models;
namespace PokemonApi.Repositories;

public interface IHobbyRepository
    {
        Task<Hobby> GetHobbyByIdAsync(int id, CancellationToken cancellationToken);
        Task DeleteHobbyAsync(Hobby hobby, CancellationToken cancellationToken);
        Task<List<Hobby>> GetHobbyByNameAsync(string name, CancellationToken cancellationToken);
    }
