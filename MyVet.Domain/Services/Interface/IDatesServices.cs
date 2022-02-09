using Infraestructure.Entity.Model.Vet;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Dates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IDatesServices
    {
        List<ConsultDatesDto> GetAllMyDates(int idUser);
        Task<bool> InsertDatesAsync(InsertDatesDto data);
        Task<bool> UpdateDatesAsync(DatesDto data);
        Task<ResponseDto> DeleteDatesAsync(int idDates);
        List<ServicesEtntity> GetAllServices();

        Task<bool> CancelDatesAsync(int idDates, int? idUserVet);


        List<ConsultDatesDto> GetAllDates(int idUser);
        Task<bool> UpdateDatesVetAsync(DatesDto data);
    }
}
