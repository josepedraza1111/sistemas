using PokemonApi.Dtos;
using PokemonApi.Mappers;
using PokemonApi.Repositories;

namespace PokemonApi.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository){
        _bookRepository = bookRepository;
    }

    public async Task<List<BooksResponseDto>> GetBooksByName(string name,CancellationToken cancellationToken){
            
    var  books = await _bookRepository.GetBooksByNameAsync(name, cancellationToken);

    
    if (books == null || !books.Any())
    {
        return new List<BooksResponseDto>();
    }
    
   
    return books.Select(h => h.ToDto()).ToList();

         }
}