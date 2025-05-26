using System.ServiceModel;
using HobbyApi.Dtos;
using HobbyApi.Mappers;
using HobbyApi.Repositories;
using HobbyApi.Validators;


namespace HobbyApi.Services;


public class HobbyService : IHobbyService
{
    private readonly IHobbyRepository _hobbyRepository;

    public HobbyService(IHobbyRepository hobbyRepository){
         _hobbyRepository= hobbyRepository;
    }

<<<<<<< HEAD
    public  async Task<HobbysResponseDto> GetHobbyById(int id,CancellationToken cancellationToken){
=======
    public  async Task<HobbysResponseDto> GetHobbyById(Guid id,CancellationToken cancellationToken){

>>>>>>> 8d421da23b5c10fd10253551a2ef077f60f8d007
         var hobby =await _hobbyRepository.GetHobbyByIdAsync(id,cancellationToken);
   if (hobby is null)
   {
    throw new FaultException("Hobby not found");
   }
   return hobby.ToDto();

    }

<<<<<<< HEAD
      
        public async Task<bool> DeleteHobbyById(int id, CancellationToken cancellationToken){
=======

        public async Task<bool> DeleteHobbyById(Guid id, CancellationToken cancellationToken){

>>>>>>> 8d421da23b5c10fd10253551a2ef077f60f8d007
            var hobby = await _hobbyRepository.GetHobbyByIdAsync(id,cancellationToken);
        if(hobby is null)
{
    throw new FaultException("Hobby not found");
}   
    await _hobbyRepository.DeleteHobbyAsync(hobby, cancellationToken);
    return true;
        }

<<<<<<< HEAD
     public async Task<HobbysResponseDto> GetHobbyByName(string name, CancellationToken cancellationToken)
=======
    

     public async Task<List<HobbysResponseDto>> GetHobbyByName(string name,CancellationToken cancellationToken){

    var hobbys = await _hobbyRepository.GetHobbyByNameAsync(name, cancellationToken);


    if (hobbys== null || !hobbys.Any())
>>>>>>> 8d421da23b5c10fd10253551a2ef077f60f8d007
    {
        var hobby = await _hobbyRepository.GetHobbyByNameAsync(name, cancellationToken);
        if (hobby.Count == 0)
        {
            throw new FaultException("Hobby not found");
        }
        return hobby.First().ToDto();
    }
  
 public async Task<HobbysResponseDto> CreateHobby(CreateHobbyDto createHobby, CancellationToken cancellationToken)
{
    if (createHobby == null)
    {
        throw new ArgumentNullException(nameof(createHobby), "El objeto CreateHobbyDto es null.");
    }

    var hobbyToCreate = createHobby.ToModel();
    hobbyToCreate.ValidateName();

    await _hobbyRepository.AddAsync(hobbyToCreate, cancellationToken);
    return hobbyToCreate.ToDto();
}



    public async Task<HobbysResponseDto> UpdateHobby(UpdateHobbyDto hobby,CancellationToken cancellationToken){

        var hobbyToUpdate=await _hobbyRepository.GetHobbyByIdAsync(hobby.Id,cancellationToken);

        if(hobbyToUpdate is null){

            throw new FaultException("Hobby not found");

        }

        hobbyToUpdate.Name=hobby.Name;
        hobbyToUpdate.Top=hobby.Top;

        await _hobbyRepository.UpdateAsync(hobbyToUpdate,cancellationToken);
        return hobbyToUpdate.ToDto();
     

    }

}
