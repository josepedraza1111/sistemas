

namespace PokemonApi.Models;

public class Pokemon
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Level { get; set; }
    public int Height { get; set; }
    public Stats Stats { get; set; }
}