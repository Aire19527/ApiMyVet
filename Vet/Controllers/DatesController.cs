using Common.Utils.Enums;
using Common.Utils.Helpers;
using Common.Utils.Resorces;
using Infraestructure.Entity.Model.Vet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Dates;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vet.Handlers;
using static Common.Utils.Constant.Const;

namespace Vet.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class DatesController : ControllerBase
    {
        #region Attributes
        private readonly IDatesServices _datesServices;
        #endregion

        #region Builder
        public DatesController(IDatesServices datesServices)
        {
            _datesServices = datesServices;
        }
        #endregion


        #region Methods

        /// <summary>
        /// Obtiene todas las citas disponibles del usuario que consulta 
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllDates")]
        [CustomPermissionFilter(Enums.Permission.ConsultarCitasVetrinario)]
        public IActionResult GetAllDates()
        {
            string idUser = Utils.GetClaimValue(Request.Headers["Authorization"], TypeClaims.IdUser);
            List<ConsultDatesDto> result = _datesServices.GetAllDates(Convert.ToInt32(idUser));
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = result,
                Message = string.Empty
            };

            return Ok(response);
        }

        /// <summary>
        /// Obtener mis citas 
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllMyDates")]
        [CustomPermissionFilter(Enums.Permission.ConsultarCitas)]
        public IActionResult GetAllMyDates()
        {
            string idUser = Utils.GetClaimValue(Request.Headers["Authorization"], TypeClaims.IdUser);
            List<ConsultDatesDto> result = _datesServices.GetAllMyDates(Convert.ToInt32(idUser));
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = result,
                Message = string.Empty
            };
            return Ok(response);
        }

        /// <summary>
        /// Obtener listado de servicios
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllServices")]
        [CustomPermissionFilter(Enums.Permission.ConsultarCitas)]
        public IActionResult GetAllServices()
        {
            List<ServicesEtntity> result = _datesServices.GetAllServices();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = result,
                Message = string.Empty
            };
            return Ok(response);
        }

        /// <summary>
        /// Crear una nueva cita
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertDates")]
        [CustomPermissionFilter(Enums.Permission.CrearCitas)]
        public async Task<IActionResult> InsertDates(InsertDatesDto dates)
        {
            IActionResult response;

            bool result = await _datesServices.InsertDatesAsync(dates);
            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }

        /// <summary>
        /// Actualizar una cita
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPut]
        [Route("UpdateDates")]
        [CustomPermissionFilter(Enums.Permission.ActualizarCitas)]
        public async Task<IActionResult> UpdateDates(DatesDto dates)
        {
            IActionResult response;

            bool result = await _datesServices.UpdateDatesAsync(dates);
            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }

        /// <summary>
        /// Eliminar una cita
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpDelete]
        [Route("DeleteDates")]
        [CustomPermissionFilter(Enums.Permission.EliminarCita)]
        public async Task<IActionResult> DeleteDates(int idDates)
        {
            IActionResult response;
            ResponseDto result = await _datesServices.DeleteDatesAsync(idDates);

            if (result.IsSuccess)
                response = Ok(result);
            else
                response = BadRequest(result);

            return Ok(response);
        }

        /// <summary>
        /// Cancelar una cita por parte del usuario
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("CancelDates")]
        [CustomPermissionFilter(Enums.Permission.CancelarCitas)]
        public async Task<IActionResult> CancelDates(int idDates)
        {
            IActionResult response;

            bool result = await _datesServices.CancelDatesAsync(idDates, idUserVet: null);
            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.DatesCancel : GeneralMessages.DatesNotCancel
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }


        /// <summary>
        /// Actualizar una cita por parte del Veterinario
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPut]
        [Route("UpdateDatesVet")]
        [CustomPermissionFilter(Enums.Permission.ActualizarCitasVeterinario)]
        public async Task<IActionResult> UpdateDatesVet(DatesDto dates)
        {
            IActionResult response;
            string idUser = Utils.GetClaimValue(Request.Headers["Authorization"], TypeClaims.IdUser);
            dates.IdUserVet = Convert.ToInt32(idUser);
            bool result = await _datesServices.UpdateDatesVetAsync(dates);
            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }

        /// <summary>
        /// Cancelar una cita por parte del Veterinario
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("CancelDatesVet")]
        [CustomPermissionFilter(Enums.Permission.CancelarCitasVeterinario)]
        public async Task<IActionResult> CancelDatesVet(int idDates)
        {
            IActionResult response;

            string idUser = Utils.GetClaimValue(Request.Headers["Authorization"], TypeClaims.IdUser);
            bool result = await _datesServices.CancelDatesAsync(idDates, Convert.ToInt32(idUser));
            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.DatesCancel : GeneralMessages.DatesNotCancel
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }


        #endregion
    }
}
