using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Enums
{
    public class Enums
    {
        public enum TypeState
        {
            //Usuario
            EstadoUsuario = 1,

            EstadoCitas = 2,
        }

        public enum State
        {
            //Usuario
            UsuarioActivo = 1,

            UsuarioInactivo = 2,
            UsuarioSuspendido = 3,

            //Citas
            CitaActiva = 4,

            CitaCancelada = 5,
            CitaFinalizada = 6,
        }

        public enum TypePermission
        {
            Usuarios = 1,
            Roles = 2,
            Permisos = 3,
            Veterinaria = 4,
            Estados = 5,
            Mascota = 6,
        }

        public enum Permission
        {
            //Usuarios
            CrearUsuarios = 1,

            ActualizarUsuarios = 2,
            EliminarUsuarios = 3,
            ConsultarUsuarios = 4,

            //Roles
            ActualizarRoles = 5,
            ConsultarRoles = 6,

            //Permisos
            ActualizarPermisos = 7,
            ConsultarPermisos = 8,
            DenegarPermisos = 9,

            //Mascota
            CrearMascota = 10,
            ActualizarMascota = 11,
            EliminarMascota = 12,
            ConsultarMascota = 13,

            //Veterinatia
            CrearCitas=14,
            ConsultarCitas=15,
            CancelarCitas=16,
            ActualizarCitas=17,
            ActualizarCitasVeterinario=18,
            ConsultarCitasVetrinario = 19,
            CancelarCitasVeterinario=20,
            EliminarCita=21,

            //Estados
            ConsultarEstados = 22,
            ActualizarEstado = 23,
        }
       
        public enum RolUser
        {
            Administrador = 1,
            Veterinario = 2,
            Estandar= 3
        }

    }
}
