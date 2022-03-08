using Common.Utils.Exceptions;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Model.Vet;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Pet;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services
{
    public class PetServices : IPetServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion


        #region Builder
        public PetServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region Methods
        public List<ConsultPetDto> GetAllMyPets(int idUser)
        {
            var pets = _unitOfWork.PetRepository.FindAll(x => x.UserPetEntity.IdUser == idUser,
                                                        p => p.UserPetEntity,
                                                        p => p.SexEntity,
                                                        p => p.TypePetEntity).ToList();

            List<ConsultPetDto> list = pets.Select(x => new ConsultPetDto
            {
                DateBorns = x.DateBorns,
                Id = x.Id,
                Name = x.Name,
                IdTypePet = x.IdTypePet,
                IdSex = x.IdSex,
                Sexo = x.SexEntity.Sex,
                TypePet = x.TypePetEntity.TypePet,
                Edad = CalculateAge(x.DateBorns)

            }).ToList();


            return list;
        }

        private string CalculateAge(DateTime dateBorn)
        {
            string result = string.Empty;

            int age = Math.Abs((DateTime.Now.Month - dateBorn.Month) + 12 * (DateTime.Now.Year - dateBorn.Year));

            if (age != 0)
                result = $"{age} meses";
            else
            {
                TimeSpan resultDate = DateTime.Now.Date - dateBorn.Date;
                result = $"{resultDate.Days} días";
            }

            return result;
        }

        public List<TypePetDto> GetAllTypePet()
        {
            List<TypePetEntity> typePets = _unitOfWork.TypePetRepository.GetAll().ToList();

            List<TypePetDto> list = typePets.Select(x => new TypePetDto
            {
                IdTypePet = x.Id,
                TypePet = x.TypePet
            }).ToList();

            return list;
        }

        public List<SexDto> GetAllSexs()
        {
            List<SexEntity> sexs = _unitOfWork.SexRepository.GetAll().ToList();

            List<SexDto> list = sexs.Select(x => new SexDto
            {
                IdSex = x.Id,
                Sex = x.Sex
            }).ToList();

            return list;
        }


        public async Task<ResponseDto> DeletePetAsync(int idPet)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.PetRepository.Delete(idPet);
            response.IsSuccess = await _unitOfWork.Save() > 0;
            if (response.IsSuccess)
                response.Message = "Se elminnó correctamente la Mascota";
            else
                response.Message = "Hubo un error al eliminar la Mascota, por favor vuelva a intentalo";

            return response;
        }

        public async Task<bool> InsertPetAsync(InsertPetDto pet, int idUser)
        {
            UserPetEntity userPetEntity = new UserPetEntity()
            {
                IdUser = idUser,
                PetEntity = new PetEntity()
                {
                    DateBorns = pet.DateBorns,
                    IdSex = pet.IdSex,
                    IdTypePet = pet.IdTypePet,
                    Name = pet.Name,
                }
            };

            _unitOfWork.UserPetRepository.Insert(userPetEntity);
            return await _unitOfWork.Save() > 0;
        }


        public async Task<bool> UpdatePetAsync(PetDto pet)
        {
            bool result = false;

            PetEntity petEntity = _unitOfWork.PetRepository.FirstOrDefault(x => x.Id == pet.Id);
            if (petEntity != null)
            {
                petEntity.DateBorns = pet.DateBorns;
                petEntity.IdSex = pet.IdSex;
                petEntity.IdTypePet = pet.IdTypePet;
                petEntity.Name = pet.Name;

                _unitOfWork.PetRepository.Update(petEntity);

                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }
        #endregion
    }
}
