using System.ServiceModel;
using PokedexApi.Exceptions;
using PokedexApi.Exceptions;
using PokedexApi.Infrastructure.Soap.Contracts;
using PokedexApi.Mappers;
using PokedexApi.Models;

namespace PokedexApi.Repositories;

public class PokemonRepository : IPokemonRepository {
    private readonly ILogger<PokemonRepository> _logger;
    private readonly IPokemonService _pokedexService;

    public PokemonRepository(ILogger<PokemonRepository>logger, IConfiguration configuration){
        _logger = logger;
        var endpoint = new EndpointAddress(configuration.GetValue<string>("PokemonServiceEndpoint"));
        var binding = new BasicHttpBinding();
        _pokedexService = new ChannelFactory<IPokemonService>(binding, endpoint).CreateChannel();
    }

    public async Task<Pokemon?> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken){
        try
        {
            var pokemon = await _pokedexService.GetPokemonById(id, cancellationToken);
            return pokemon.ToModel();
        }
        catch(FaultException ex) when (ex.Message =="Pokemon not found ")
        {
            _logger.LogWarning(ex, "Pokemon not found {id}", id);
            return null;
        }
    }

    public async Task<Pokemon?> GetPokemonByNameAsync(string name, CancellationToken cancellationToken)
    {
        try
        {
            var pokemon = await _pokedexService.GetPokemonByName(name, cancellationToken);
            return pokemon.ToModel();
        }
        catch(FaultException ex) when (ex.Message == "Pokemon not found")
        {
            _logger.LogWarning(ex, "Pokemon not found {name}", name);
            return null;
        }
    }

    public async Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken){
        try
        {
            await _pokedexService.DeletePokemon(id, cancellationToken);
            return true;
        }
        catch(FaultException ex) when (ex.Message =="Pokemon not found ")
        {
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Pokemon not found {id}", id);
            throw;
        }
    }
       public async Task<Pokemon> CreatePokemonAsync(Pokemon pokemon, CancellationToken cancellationToken)
    {
        try
        {
            var pokemonCreated = await _pokedexService.CreatePokemon(pokemon.ToSoapDto(), cancellationToken);
            return pokemonCreated.ToModel();
        }
        catch(FaultException ex) when (ex.Message.Contains("Pokemon"))
        {
            throw new PokemonValidationException(ex.Message);
        }
        catch(FaultException ex)
        {
            _logger.LogError(ex, "Error creating pokemon");
            throw;
        }
    }
    public async Task UpdatePokemonAsync( Pokemon pokemon, CancellationToken cancellationToken)
    {
        try
        {
            await _pokedexService.UpdatePokemon( pokemon.ToUpdateSoapDto(), cancellationToken);
        }
        catch(FaultException ex) when (ex.Message.Contains("Pokemon not found "))
        {
            throw new PokemonNotFoundException();
        }
        catch(FaultException ex)
        {
            _logger.LogError(ex, "Error updating pokemon");
            throw;
        }
    }
}

