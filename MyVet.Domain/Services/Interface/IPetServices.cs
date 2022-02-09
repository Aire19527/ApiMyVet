using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Pet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IPetServices
    {
        List<ConsultPetDto> GetAllMyPets(int idUser);
        List<TypePetDto> GetAllTypePet();
        List<SexDto> GetAllSexs();
        Task<ResponseDto> DeletePetAsync(int idPet);

        Task<bool> InsertPetAsync(InsertPetDto pet, int idUser);

        Task<bool> UpdatePetAsync(PetDto pet);
    }
}
