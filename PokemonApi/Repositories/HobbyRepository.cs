
using HobbyApi.Mappers;
using PokemonApi.Infrastructure;
using HobbyApi.Models;
using Microsoft.EntityFrameworkCore;
using HobbyApi.Repositories;


namespace PokemonApi.Repositories;

    public class HobbyRepository :  IHobbyRepository
    {
        private readonly RelationalDbContext _context;

        public HobbyRepository(RelationalDbContext context)
        {
            _context = context;
        }
<<<<<<< HEAD
        public async Task<Hobby> GetHobbyByIdAsync(int id, CancellationToken cancellationToken)
    {
        var hobby = await _context.Hobbys.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        return hobby?.ToModel();
    }
=======


        public async Task<Hobby> GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken)

        {
            var hobby = await _context.Hobbys.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
            if (hobby == null)
            {

                throw new Exception("Hobby not found");

            }
            return hobby.ToModel();
        }

>>>>>>> 8d421da23b5c10fd10253551a2ef077f60f8d007
        public async Task DeleteHobbyAsync(Hobby hobby, CancellationToken cancellationToken)
        {
            _context.Hobbys.Remove(hobby.ToEntity());
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Hobby>> GetHobbyByNameAsync(string name, CancellationToken cancellationToken)
        {
              return await _context.Hobbys
            .Where(s => s.Name.Contains(name))
            .Select(s => s.ToModel())
            .ToListAsync(cancellationToken);
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

                throw new Exception("Hobby not found");
            }
        }
    }

