using Grpc.Core;
using PokedexApi.Infraestructure.Grpc;
using PokedexApi.Mappers;
using PokedexApi.Models;

namespace PokedexApi.Repositories;

public class TrainerRepository : ITrainerRepository
{
    private readonly TrainerService.TrainerServiceClient _client;

    public TrainerRepository(TrainerService.TrainerServiceClient client)
    {
        _client = client;
    }

    public async Task<Trainer?> GetTrainerByIdAsync(string id, CancellationToken cancellationToken)
    {
        try
        {
            var trainer = await _client.GetTrainerAsync(new TrainerByIdRequest { Id = id }, cancellationToken: cancellationToken);

            return trainer.ToModel();
        }
        catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
        {
            return null;
        }
    }
}