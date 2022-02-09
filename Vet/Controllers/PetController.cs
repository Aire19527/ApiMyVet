using Common.Utils.Enums;
using Common.Utils.Helpers;
using Common.Utils.Resorces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Pet;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vet.Handlers;
using static Common.Utils.Constant.Const;

namespace Vet.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class PetController : ControllerBase
    {
        #region Attribute
        private readonly IPetServices _petServices;
        #endregion

        #region Buider
        public PetController(IPetServices petServices)
        {
            _petServices = petServices;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Obtener todas las mascotas de un usuario
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllMyPets")]
        [CustomPermissionFilter(Enums.Permission.ConsultarMascota)]
        public IActionResult GetAllMyPets()
        {
            string idUser = Utils.GetClaimValue(Request.Headers["Authorization"], TypeClaims.IdUser);
            List<ConsultPetDto> list = _petServices.GetAllMyPets(Convert.ToInt32(idUser));

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };

            return Ok(response);
        }
        /// <summary>
        /// Eliminar una mascota en específico
        /// </summary>
        /// <param name="idPet"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpDelete]
        [Route("DeletePet")]
        [CustomPermissionFilter(Enums.Permission.EliminarMascota)]
        public async Task<IActionResult> DeletePet(int idPet)
        {
            IActionResult response;
            ResponseDto result = await _petServices.DeletePetAsync(idPet);
            if (result.IsSuccess)
                response = Ok(result);
            else
                response = BadRequest(result);

            return response;
        }

        /// <summary>
        /// Obtener listado de sexos
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllSexs")]
        [CustomPermissionFilter(Enums.Permission.ConsultarMascota)]
        public IActionResult GetAllSexs()
        {
            List<SexDto> result = _petServices.GetAllSexs();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = result,
                Message = string.Empty
            };
            return Ok(response);
        }

        /// <summary>
        /// Obtener todos los tipos de mascota
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllTypePet")]
        [CustomPermissionFilter(Enums.Permission.ConsultarMascota)]
        public IActionResult GetAllTypePet()
        {
            List<TypePetDto> result = _petServices.GetAllTypePet();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = result,
                Message = string.Empty
            };
            return Ok(response);
        }

        /// <summary>
        /// Agregar una nueva mascota (para el usuario que hace el proceso)
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertPet")]
        [CustomPermissionFilter(Enums.Permission.CrearMascota)]
        public async Task<IActionResult> InsertPet(InsertPetDto pet)
        {
            IActionResult response;
            string idUser = Utils.GetClaimValue(Request.Headers["Authorization"], TypeClaims.IdUser);

            bool result = await _petServices.InsertPetAsync(pet, Convert.ToInt32(idUser));
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
        /// Actualziar una mascota en específico
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPut]
        [Route("UpdatePet")]
        [CustomPermissionFilter(Enums.Permission.ActualizarMascota)]
        public async Task<IActionResult> UpdatePet(PetDto pet)
        {
            IActionResult response;

            bool result = await _petServices.UpdatePetAsync(pet);
            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.ItemUpdated : GeneralMessages.ItemNoUpdated
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
