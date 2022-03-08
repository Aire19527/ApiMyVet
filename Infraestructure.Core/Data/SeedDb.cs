using Common.Utils.Enums;
using Infraestructure.Entity.Model;
using Infraestructure.Entity.Model.Master;
using Infraestructure.Entity.Model.Vet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        #region Builder
        public SeedDb(DataContext context)
        {
            _context = context;
        }
        #endregion


        public async Task ExecSeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTypeStateAsync();
            //await CheckStateAsync();
            await CheckTypePermissionAsync();
            await CheckPermissionAsync();
            await CheckRolAsync();
            await CheckRolPermissonAsync();
            //await CheckServicesAsync();

        }

        private async Task CheckTypeStateAsync()
        {
            if (!_context.TypeStateEntity.Any())
            {
                _context.TypeStateEntity.AddRange(new List<TypeStateEntity>
                {
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoUsuario,
                        TypeState="Estado de Usuarios"
                    },
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoCitas,
                        TypeState="Estado de las Citas"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckStateAsync()
        {
            if (!_context.StateEntity.Any())
            {
                _context.StateEntity.AddRange(new List<StateEntity>
                {
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoUsuario,
                        IdState=(int)Enums.State.UsuarioActivo,
                        State="Activo"
                    },
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoUsuario,
                        IdState=(int)Enums.State.UsuarioInactivo,
                        State="Inactivo"
                    },
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoUsuario,
                        IdState=(int)Enums.State.UsuarioSuspendido,
                        State="Suspendido"
                    },
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoCitas,
                        IdState=(int)Enums.State.CitaActiva,
                        State="Cita Activa"
                    },
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoCitas,
                        IdState=(int)Enums.State.CitaCancelada,
                        State="Cita Cancelada"
                    },
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoCitas,
                        IdState=(int)Enums.State.CitaFinalizada,
                        State="Cita Finalizada"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckTypePermissionAsync()
        {
            if (!_context.TypePermissionEntity.Any())
            {
                _context.TypePermissionEntity.AddRange(new List<TypePermissionEntity>
                {
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        TypePermission="Usuarios"
                    },
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        TypePermission="Roles"
                    },
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        TypePermission="Permisos"
                    },
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        TypePermission="Estados"
                    },
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Mascota,
                        TypePermission="Mascotas"
                    },
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Veterinaria,
                        TypePermission="Veterinaria"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckPermissionAsync()
        {
            if (!_context.PermissionEntity.Any())
            {
                _context.PermissionEntity.AddRange(new List<PermissionEntity>
                {
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Crear Usuarios",
                        Description="Crear usuarios en el sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Actualizar Usuarios",
                        Description="Actualizar datos de un usuario en el sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Eliminar Usuarios",
                        Description="Eliminar un usuairo del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Consultar Usuarios",
                        Description="Consulta todos los usuarios"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Actualizar Roles",
                        Description="Actualizar datos de un Roles en el sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Consultar Roles",
                        Description="Consultar Roles del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Actualizar Permisos",
                        Description="Actualizar datos de un Permiso en el sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Consultar Permisos",
                        Description="Consultar Permisos del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.DenegarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Denegar Permisos Rol",
                        Description="Denegar permisos a un rol del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarEstados,
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        Permission="Consultar Estado",
                        Description="Consultar los estados del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarEstado,
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        Permission="Actualizar Estados",
                        Description="Actualizar los estados del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearMascota,
                        IdTypePermission=(int)Enums.TypePermission.Mascota,
                        Permission="Crear Mascota",
                        Description="Crear la información de la mascota"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarMascota,
                        IdTypePermission=(int)Enums.TypePermission.Mascota,
                        Permission="Actualizar Mascota",
                        Description="Actualizar la información de la mascota"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarMascota,
                        IdTypePermission=(int)Enums.TypePermission.Mascota,
                        Permission="Eliminar Mascota",
                        Description="Eliminar la información de la mascota"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarMascota,
                        IdTypePermission=(int)Enums.TypePermission.Mascota,
                        Permission="Consultar Mascota",
                        Description="Consultar la información de la mascota"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearCitas,
                        IdTypePermission=(int)Enums.TypePermission.Veterinaria,
                        Permission="Crear Citas",
                        Description="Crear la información de la citas"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarCitas,
                        IdTypePermission=(int)Enums.TypePermission.Veterinaria,
                        Permission="Consultar Citas",
                        Description="Consultar la información de la citas"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CancelarCitas,
                        IdTypePermission=(int)Enums.TypePermission.Veterinaria,
                        Permission="Cancelar Citas",
                        Description="Cancelar la citas"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarCitas,
                        IdTypePermission=(int)Enums.TypePermission.Veterinaria,
                        Permission="Actualizar Citas",
                        Description="Actualizar la citas"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CancelarCitasVeterinario,
                        IdTypePermission=(int)Enums.TypePermission.Veterinaria,
                        Permission="Cancelar Citas por un Veterinario",
                        Description="Cancelar la citas del veterinario"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarCitasVeterinario,
                        IdTypePermission=(int)Enums.TypePermission.Veterinaria,
                        Permission="Actualizar Citas por un Veterinario",
                        Description="Actualizar la citas del veterinario"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarCitasVetrinario,
                        IdTypePermission=(int)Enums.TypePermission.Veterinaria,
                        Permission="Consultar Citas por un Veterinario",
                        Description="Consultar la citas del veterinario"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarCita,
                        IdTypePermission=(int)Enums.TypePermission.Veterinaria,
                        Permission="Eliminar Citas",
                        Description="Eliminar la citas"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckRolAsync()
        {
            if (!_context.RolEntity.Any())
            {
                _context.RolEntity.AddRange(new List<RolEntity>
                {
                    new RolEntity
                    {
                        IdRol=(int)Enums.RolUser.Administrador,
                        Rol="Administrador"
                    },
                    new RolEntity
                    {
                        IdRol=(int)Enums.RolUser.Veterinario,
                        Rol="Veterinario"
                    },
                     new RolEntity
                    {
                        IdRol=(int)Enums.RolUser.Estandar,
                        Rol="Estandar"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckRolPermissonAsync()
        {
            if (!_context.RolPermissionEntity.Where(x => x.IdRol == (int)Enums.RolUser.Administrador).Any())
            {
                var rolesPermisosAdmin = _context.PermissionEntity.Select(x => new RolPermissionEntity
                {
                    IdRol = (int)Enums.RolUser.Administrador,
                    IdPermission = x.IdPermission
                }).ToList();

                _context.RolPermissionEntity.AddRange(rolesPermisosAdmin);


                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckServicesAsync()
        {
            if (!_context.ServicesEtntity.Any())
            {
                _context.ServicesEtntity.AddRange(new List<ServicesEtntity>
                {
                    new ServicesEtntity
                    {
                        Services="Consulta General",
                        Description="Consulta general de una mascota"
                    },
                    new ServicesEtntity
                    {
                        Services="Motilada",
                        Description="Motilada de la mascota"
                    },
                    new ServicesEtntity
                    {
                        Services="Cortar Uñas",
                        Description="Cortar uñas a un perro o gato"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}