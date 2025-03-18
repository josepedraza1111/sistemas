using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Repositories;
using PokemonApi.Mappers;
using PokemonApi.Validators;

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
 public async Task<HobbysResponseDto> CreateHobby(CreateHobbyDto createHobby, CancellationToken cancellationToken)
{
    if (createHobby == null)
    {
        throw new ArgumentNullException(nameof(createHobby), "El objeto CreateHobbyDto es null.");
    }

    var hobbyToCreate = createHobby.ToModel();
    hobbyToCreate.ValidateName().ValidateTop();

    await _hobbyRepository.AddAsync(hobbyToCreate, cancellationToken);
    return hobbyToCreate.ToDto();
}



    public async Task<HobbysResponseDto> UpdateHobby(UpdateHobbyDto hobby,CancellationToken cancellationToken){

        var hobbyToUpdate=await _hobbyRepository.GetHobbyByIdAsync(hobby.Id,cancellationToken);

        if(hobbyToUpdate is null){
            throw new FaultException("Hobby no encontrado");
        }

        hobbyToUpdate.Name=hobby.Name;
        hobbyToUpdate.Top=hobby.Top;

        await _hobbyRepository.UpdateAsync(hobbyToUpdate,cancellationToken);
        return hobbyToUpdate.ToDto();
     

    }

}
