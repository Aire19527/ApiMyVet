using Common.Utils.Enums;
using Common.Utils.Exceptions;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Model.Vet;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Dates;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services
{
    public class DatesServices : IDatesServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public DatesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        public List<ConsultDatesDto> GetAllMyDates(int idUser)
        {
            var dates = _unitOfWork.DatesRepository.FindAll(x => x.PetEntity.UserPetEntity.IdUser == idUser,
                                                             p => p.PetEntity.UserPetEntity,
                                                             p => p.PetEntity.TypePetEntity,
                                                             p => p.StateEntity,
                                                             p => p.ServicesEtntity);

            List<ConsultDatesDto> listDates = dates.Select(x => new ConsultDatesDto
            {
                Id = x.Id,
                Contact = x.Contact,
                Description = x.Description,
                IdPet = x.IdPet,
                IdServices = x.IdServices,
                IdState = x.IdState,
                IdUserVet = x.IdUserVet,
                Date = x.Date,
                ClosingDate = x.ClosingDate,
                StrClosingDate = x.ClosingDate == null ? "No disponible" : x.ClosingDate.Value.ToString("yyyy-MM-dd"),
                Estado = x.StateEntity.State,
                Mascota = $"{x.PetEntity.Name}  [{x.PetEntity.TypePetEntity.TypePet}]",
                Servicio = x.ServicesEtntity.Services,
                StrDate = x.Date.ToString("yyyy-MM-dd")
            }).OrderByDescending(f => f.Date).ToList();

            return listDates;
        }

        public List<ConsultDatesDto> GetAllDates(int idUser)
        {
            var dates = _unitOfWork.DatesRepository.FindAll(x => (x.IdUserVet == idUser || x.IdUserVet == null),
                                                             p => p.PetEntity.UserPetEntity,
                                                             p => p.PetEntity.TypePetEntity,
                                                             p => p.StateEntity,
                                                             p => p.ServicesEtntity);


            var datesDeleteList = dates.Where(x => (x.IdState == (int)Enums.State.CitaCancelada
                                                  && x.IdUserVet == null)).ToList();


            var datesSelect = (from t in dates
                               where !datesDeleteList.Any(x => x.Id == t.Id)
                               select t).ToList();



            List<ConsultDatesDto> listDates = datesSelect.Select(x => new ConsultDatesDto
            {
                Id = x.Id,
                Contact = x.Contact,
                Description = x.Description,
                IdPet = x.IdPet,
                IdServices = x.IdServices,
                IdState = x.IdState,
                IdUserVet = x.IdUserVet,
                Date = x.Date,
                ClosingDate = x.ClosingDate,
                StrClosingDate = x.ClosingDate == null ? "No disponible" : x.ClosingDate.Value.ToString("yyyy-MM-dd"),
                Estado = x.StateEntity.State,
                Mascota = $"{x.PetEntity.Name}  [{x.PetEntity.TypePetEntity.TypePet}]",
                Servicio = x.ServicesEtntity.Services,
                StrDate = x.Date.ToString("yyyy-MM-dd")
            }).OrderByDescending(f => f.Date).ToList();

            return listDates;
        }

        public async Task<bool> InsertDatesAsync(InsertDatesDto data)
        {
            if (data.Date.Date<= DateTime.Now.Date)
                throw new BusinessException("La fecha no puede ser inferior al dia actual");


            DatesEntity dates = new DatesEntity()
            {
                Contact = data.Contact,
                Date = data.Date,
                Description = data.Description,
                IdPet = data.IdPet,
                IdServices = data.IdServices,
                IdState = (int)Enums.State.CitaActiva,
            };
            _unitOfWork.DatesRepository.Insert(dates);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateDatesAsync(DatesDto data)
        {
            bool result = false;

            DatesEntity dates = _unitOfWork.DatesRepository.FirstOrDefault(x => x.Id == data.Id);
            if (dates != null)
            {
                dates.Contact = data.Contact;
                dates.Date = data.Date;
                dates.Description = data.Description;
                dates.IdPet = data.IdPet;
                dates.IdServices = data.IdServices;
                dates.IdState = dates.IdState;

                _unitOfWork.DatesRepository.Update(dates);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }

        public async Task<bool> UpdateDatesVetAsync(DatesDto data)
        {
            bool result = false;

            DatesEntity dates = _unitOfWork.DatesRepository.FirstOrDefault(x => x.Id == data.Id);
            if (dates != null)
            {
                dates.Contact = data.Contact;
                dates.Date = data.Date;
                dates.Description = data.Description;
                dates.IdPet = data.IdPet;
                dates.IdServices = data.IdServices;
                dates.IdState = dates.IdState;
                dates.IdUserVet = data.IdUserVet;
                dates.ClosingDate = DateTime.Now;
                dates.IdState = (int)Enums.State.CitaFinalizada;
                dates.Observation = data.Observation;

                _unitOfWork.DatesRepository.Update(dates);
                result = await _unitOfWork.Save() > 0;
            }

            return result;

        }
        public async Task<ResponseDto> DeleteDatesAsync(int idDates)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.DatesRepository.Delete(idDates);
            response.IsSuccess = await _unitOfWork.Save() > 0;
            if (response.IsSuccess)
                response.Message = "Se elminnó correctamente la cita";
            else
                response.Message = "Hubo un error al eliminar la cita, por favor vuelva a intentalo";

            return response;
        }
        public List<ServicesEtntity> GetAllServices() => _unitOfWork.ServicesRepository.GetAll().ToList();

        public async Task<bool> CancelDatesAsync(int idDates, int? idUserVet)
        {
            bool result = false;

            DatesEntity dates = _unitOfWork.DatesRepository.FirstOrDefault(x => x.Id == idDates);
            if (dates != null)
            {
                dates.IdState = (int)Enums.State.CitaCancelada;
                dates.ClosingDate = DateTime.Now;
                dates.IdUserVet = idUserVet ?? null;
                _unitOfWork.DatesRepository.Update(dates);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }

        #endregion
    }
}
