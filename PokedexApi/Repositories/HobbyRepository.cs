using System.ServiceModel;
using PokedexApi.Infrastructure.Soap.Contracts;
using PokedexApi.Mappers;
using PokedexApi.Models;

namespace PokedexApi.Repositories;

public class HobbyRepository : IHobbyRepository
{
    private readonly ILogger<HobbyRepository> _logger;
    private readonly IHobbyService _hobbyService;

    public HobbyRepository(ILogger<HobbyRepository>logger, IConfiguration configuration){
        _logger = logger;
        var endpoint = new EndpointAddress(configuration.GetValue<string>("HobbyServiceEndpoint"));
        var binding = new BasicHttpBinding();
        _hobbyService = new ChannelFactory<IHobbyService>(binding, endpoint).CreateChannel();
    }

    public async Task<Hobby?> GetHobbyByIdAsync(int id, CancellationToken cancellationToken){
        try
        {
            var hobby = await _hobbyService.GetHobbyById(id, cancellationToken);
            return hobby.ToModel();
        }
        catch(FaultException ex) when (ex.Message =="Hobby not found ")
        {
            _logger.LogWarning(ex, "Hobby not found: {id}", id);
            return null;
        }
    }

    public async Task<Hobby?> GetHobbyByNameAsync(string name, CancellationToken cancellationToken)
    {
        try
        {
             var hobby = await _hobbyService.GetHobbyByName(name, cancellationToken);
                return hobby.ToModel();
        }
            catch (FaultException ex) when (ex.Message == "Hobby not found")
            {
                _logger.LogWarning(ex, "Failed to get hobby {name}", name);
                return null;
            }
        }     public async Task<bool> DeleteHobbyByIdAsync(int id, CancellationToken cancellationToken){
        try
        {
            await _hobbyService.DeleteHobbyById(id, cancellationToken);
            return true;
        }
        catch(FaultException ex) when (ex.Message =="Hobby not found ")
        {
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Hobby not found {id}", id);
            throw;
        }
}
}