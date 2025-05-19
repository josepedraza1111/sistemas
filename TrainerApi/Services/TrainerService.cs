using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using TrainerApi.Repositories;
using TrainerApi.Mappers;

namespace TrainerApi.Services;

public class TrainerService : TrainerApi.TrainerService.TrainerServiceBase
{

    private readonly ITrainerRepository _trainerRepository; 

    public TrainerService(ITrainerRepository trainerRepository){
        _trainerRepository = trainerRepository;
    }
    public override async Task<TrainerResponse> GetTrainer(TrainerByIdRequest request, ServerCallContext context)
    {
        var trainer = await _trainerRepository.GetByIdAsync(request.Id, context.CancellationToken);
        if (trainer is null){
            throw new RpcException(new Status(StatusCode.NotFound,"Trainer not found")); 
        }
        return trainer.ToResponse(); 
    }

    public override async Task<CreateTrainersResponse> CreateTrainer(IAsyncStreamReader<CreateTrainerRequest> requestStream, ServerCallContext context)
    {
        var createTrainers = new List<TrainerResponse>();
        while (await requestStream.MoveNext(context.CancellationToken))
        {
            var request = requestStream.Current; //Trainer in pogress
            var trainer = request.ToModel();// Trainer model
            var trainerExists = await _trainerRepository.GetByNameAsync(trainer.Name, context.CancellationToken);
            if (trainerExists.Any())
            {
                continue;
            }
            var createdTrainer = await _trainerRepository.CreateAsync(trainer, context.CancellationToken);
            createTrainers.Add(createdTrainer.ToResponse());
        }
        
        return new CreateTrainersResponse
        {
            SuccessCount = createTrainers.Count,
            Trainers = { createTrainers }
        };
    }

}