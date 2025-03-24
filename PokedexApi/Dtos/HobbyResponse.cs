namespace PokedexApi.Dtos;

public class HobbyResponse
{
    public Guid Id {get; set;}
    public required string Name {get; set;}
    public int Top {get; set;}
}