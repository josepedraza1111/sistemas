using Microsoft.AspNetCore.Mvc;
using PokedexApi.Services;
using PokedexApi.Dtos;
using PokedexApi.Mappers;

namespace PokedexApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PokemonsController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonsController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }
 
    [HttpGet("{id}")]
    public async Task<ActionResult<PokemonResponse>> GetPokemonById(Guid id, CancellationToken cancellationToken)
    {
        var pokemon = await _pokemonService.GetPokemonByIdAsync(id, cancellationToken);
        if (pokemon == null){
            return NotFound();
        }
        return Ok(pokemon.ToDto());
    }
    [HttpGet]
    public async Task<ActionResult<List<PokemonResponse>>> GetPokemonByName([FromQuery]string name, CancellationToken cancellationToken)
    {
        var pokemon = await _pokemonService.GetPokemonByNameAsync(name, cancellationToken);
        return Ok(pokemon.ToDtoList());
    }

    [HttpDelete("{id}")]
       public async Task<ActionResult> DeletePokemonById(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _pokemonService.DeletePokemonByIdAsync(id, cancellationToken);
        if (deleted){
            return NoContent(); //204
        }
        return NotFound(); //404
    }
}