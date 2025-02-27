using PokemonApi.Models;

namespace PokemonApi.Repositories;
public interface IBookRepository
{
     Task <List<Book>> GetBooksByNameAsync (string name, CancellationToken cancellationToken);
}