using PokemonApi.Mappers;
using PokemonApi.Infrastructure;
using PokemonApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PokemonApi.Repositories
{
    public class HobbyRepository : IHobbyRepository
    {
        private readonly RelationalDbContext _context;

        public HobbyRepository(RelationalDbContext context)
        {
            _context = context;
        }

        public async Task<Hobby> GetHobbyByIdAsync(int id, CancellationToken cancellationToken)
        {
            var hobby = await _context.Hobbys.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
            return hobby.ToModel();
        }

        public async Task DeleteHobbyAsync(Hobby hobby, CancellationToken cancellationToken)
        {
            _context.Hobbys.Remove(hobby.ToEntity());
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Hobby>> GetHobbyByNameAsync(string name, CancellationToken cancellationToken)
        {
            var hobbys = await _context.Hobbys.AsNoTracking().Where(s => s.Name.Contains(name)).ToListAsync(cancellationToken);
            return hobbys.Select(h => h.ToModel()).ToList();
        }
    }
}