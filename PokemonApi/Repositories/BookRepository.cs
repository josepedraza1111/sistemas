using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Models;
using PokemonApi.Mappers;

namespace PokemonApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly RelationalDbContext _context; // Cambiado a RelationalDbContext

        public BookRepository(RelationalDbContext context) // Cambiado a RelationalDbContext
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooksByNameAsync(string name, CancellationToken cancellationToken)
        {
            var book = await _context.Books.AsNoTracking().Where(s => s.Title.Contains(name)).ToListAsync(cancellationToken);
            return book.Select(h => h.ToModel()).ToList();
        }
    }
}