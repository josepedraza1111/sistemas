using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Repositories;
using PokemonApi.Mappers;

namespace PokemonApi.Services;

public class HobbyService : IHobbyService
{
    private readonly IHobbyRepository _hobbyRepository;

    public HobbyService(IHobbyRepository hobbyRepository){
         _hobbyRepository= hobbyRepository;
    }

    public  async Task<HobbysResponseDto> GetHobbyById(int id,CancellationToken cancellationToken){
         var hobby =await _hobbyRepository.GetHobbyByIdAsync(id,cancellationToken);
   if (hobby is null)
   {
    throw new FaultException("Hobby not found");
   }
   return hobby.ToDto();

    }

      
        public async Task<bool> DeleteHobbyById(int id, CancellationToken cancellationToken){
            var hobby = await _hobbyRepository.GetHobbyByIdAsync(id,cancellationToken);
        if(hobby is null)
{
    throw new FaultException("Hobby not found");
}   
    await _hobbyRepository.DeleteHobbyAsync(hobby, cancellationToken);
    return true;
        }

    
         public async Task<List<HobbysResponseDto>> GetHobbyByName(string name,CancellationToken cancellationToken){
            
    var hobbys = await _hobbyRepository.GetHobbyByNameAsync(name, cancellationToken);


    if (hobbys== null || !hobbys.Any())
    {
        return new List<HobbysResponseDto>();
    }
    
 
    return hobbys.Select(h => h.ToDto()).ToList();

         }

}