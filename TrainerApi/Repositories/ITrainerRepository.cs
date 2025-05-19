namespace TrainerApi.Repositories;
using TrainerApi.Models;

public interface ITrainerRepository
{
    Task<Trainer?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<List<Trainer>> GetByNameAsync(string name, CancellationToken cancellationToken);
    Task<Trainer> CreateAsync(Trainer trainer, CancellationToken cancellationToken);
}