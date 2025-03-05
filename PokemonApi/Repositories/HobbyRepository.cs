using PokemonApi.Mappers;
using PokemonApi.Infrastructure;
using PokemonApi.Models;
using Microsoft.EntityFrameworkCore;


namespace PokemonApi.Repositories
{
    public class HobbyRepository :  IHobbyRepository
    {
        private readonly RelationalDbContext _context;

        public HobbyRepository(RelationalDbContext context)
        {
            _context = context;
        }

        public async Task<Hobby> GetHobbyByIdAsync(int id, CancellationToken cancellationToken)
        {
            var hobby = await _context.Hobbys.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
            if (hobby == null)
            {
                throw new Exception("Hobby no encontrado");
            }
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

        public async Task AddAsync(Hobby hobby, CancellationToken cancellationToken)
        {
            await _context.Hobbys.AddAsync(hobby.ToEntity(), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Hobby hobby, CancellationToken cancellationToken)
        {
            var existingHobbie = await _context.Hobbys.FirstOrDefaultAsync(h => h.Id == hobby.Id, cancellationToken);

            if (existingHobbie != null)
            {
                existingHobbie.Name = hobby.Name;
                existingHobbie.Top = hobby.Top;

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception("Hobby no encontrado");
            }
        }
    }
}
