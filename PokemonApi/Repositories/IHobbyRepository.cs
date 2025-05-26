
using HobbyApi.Models;
namespace HobbyApi.Repositories;

    public interface IHobbyRepository
    {
<<<<<<< HEAD
        Task<Hobby> GetHobbyByIdAsync(int id, CancellationToken cancellationToken);
=======
        Task<Hobby> GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken);

>>>>>>> 8d421da23b5c10fd10253551a2ef077f60f8d007
        Task DeleteHobbyAsync(Hobby hobby, CancellationToken cancellationToken);
        Task<List<Hobby>> GetHobbyByNameAsync(string name, CancellationToken cancellationToken);
        Task AddAsync(Hobby hobby, CancellationToken cancellationToken);
        Task UpdateAsync(Hobby hobby, CancellationToken cancellationToken);
    }

}

