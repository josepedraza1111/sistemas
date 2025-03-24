using HobbyApi.Models;
using System.ServiceModel;
namespace HobbyApi.Validators;

public static class HobbyValidator
{
    public static Hobby ValidateName(this Hobby hobby)=>
       string.IsNullOrEmpty(hobby.Name) ? throw new FaultException("Nombre de Hobby requerio") : hobby;


         public static Hobby ValidateTop(this Hobby hobby)=>
         hobby.Top<= 0 ? throw new FaultException("Ingrese el top del hobby") : hobby;
}