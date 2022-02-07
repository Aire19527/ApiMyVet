using Infraestructure.Entity.Model.Vet;
using MyVet.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IDatesServices
    {
        List<DatesDto> GetAllMyDates(int idUser);
        Task<bool> InsertDatesAsync(DatesDto data);
        Task<bool> UpdateDatesAsync(DatesDto data);
        Task<ResponseDto> DeleteDatesAsync(int idDates);
        List<ServicesEtntity> GetAllServices();

        Task<bool> CancelDatesAsync(int idDates, int? idUserVet);


        List<DatesDto> GetAllDates(int idUser);
        Task<bool> UpdateDatesVetAsync(DatesDto data);
    }
}
