using HobbyApi.Models;
using System.ServiceModel;
namespace HobbyApi.Validators;

public static class HobbyValidator
{
    public static Hobby ValidateName(this Hobby hobby)=>
       string.IsNullOrEmpty(hobby.Name) ? throw new FaultException("Nombre de Hobby requerio") : hobby;


        
}