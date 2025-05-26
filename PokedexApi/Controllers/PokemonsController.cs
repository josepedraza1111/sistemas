using Microsoft.AspNetCore.Mvc;
using PokedexApi.Services;
using PokedexApi.Dtos;
using PokedexApi.Mappers;
using PokedexApi.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

namespace PokedexApi.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public class PokemonsController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonsController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }
 
    [HttpGet("{id}")]
    [Authorize( "Read")]
    public async Task<ActionResult<PokemonResponse>> GetPokemonById(Guid id, CancellationToken cancellationToken)
    {
        var pokemon = await _pokemonService.GetPokemonByIdAsync(id, cancellationToken);
        if (pokemon == null){
            return NotFound();
        }
        return Ok(pokemon.ToDto());
    }
    [HttpGet]
    public async Task<ActionResult<PokemonResponse>> GetPokemonByName([FromQuery]string name, CancellationToken cancellationToken)
    {
         var pokemon = await _pokemonService.GetPokemonByNameAsync(name, cancellationToken);
        if (pokemon is null){
            return NotFound();
        }
        return Ok(pokemon.ToDto());
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
    //400 Bad Request Usuario ingresa valor incorrecto
    //409 - Conflict - Usuario intenta crear un recurso que ya existe
    //200 - Ok - Todo salio bien pokemon creado
    //201 - Created - Todo salio bien pokemon creado

    [HttpPost]
    public async Task<ActionResult<PokemonResponse>> CreatePokemon([FromBody] CreatePokemonRequest pokemon, CancellationToken cancellationToken)
    {
        try{
        var createdPokemon = await _pokemonService.CreatePokemonAsync(pokemon.ToModel(), cancellationToken);
        return CreatedAtAction(nameof(GetPokemonById), new {id = createdPokemon.Id}, createdPokemon.ToDto());
        }
        catch(PokemonValidationException ex){
            return BadRequest(new{message = ex.Message});
        }
        catch (PokemonAlreadyExistsException ex)
        {
            return Conflict(new { message = $"Pokemon '{ex.PokemonName}' already exists", exception = ex.Message });
        }
    }
    //Fut-localh:port/api/pokemons/id
    //404-Not Found no existe el pokmemon con el id que se manda
    //400-Bar request (usuario Ingreso Un valor Incorrecto=
    //409 conflict ( ya existe el pokemon con el mismo nombre)
    //204 - Nocontent
    //200 - ok (pokemon actualizado)
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePokemon(Guid id, [FromBody] UpdatePokemonRequest pokemon,CancellationToken cancellationToken){
       
       try{
            await _pokemonService.UpdatePokemonAsync(id, pokemon.ToModel(), cancellationToken);
            return NoContent();
        }
        catch(NameValidationException){
            return Conflict(new {message=$"Pokemon alredy exists with the name:",pokemon.Name});
        }
        catch (PokemonValidationException ex){
            return BadRequest(new{message = ex.Message});
        }
        catch(PokemonNotFoundException){
            return NotFound();
        }
    }

}

