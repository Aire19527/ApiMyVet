using Infraestructure.Core.Data;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Model;
using Infraestructure.Entity.Model.Master;
using Infraestructure.Entity.Model.Vet;
using System;
using System.Threading.Tasks;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        #region Attributes

        private readonly DataContext _context;
        private bool disposed = false;

        #endregion Attributes

        #region builder

        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }

        #endregion builder

        #region Properties
        private IRepository<UserEntity> userRepository;
        private IRepository<RolEntity> rolRepository;
        private IRepository<RolUserEntity> rolUserRepository;
        private IRepository<TypeStateEntity> typeStateRepository;
        private IRepository<PermissionEntity> permissionRepository;
        private IRepository<TypePermissionEntity> typePermissionRepository;
        private IRepository<RolPermissionEntity> rolPermissionRepository;

        private IRepository<StateEntity> stateRepository;

        private IRepository<DatesEntity> datesRepository;
        private IRepository<PetEntity> petRepository;
        private IRepository<ServicesEtntity> servicesRepository;
        private IRepository<SexEntity> sexRepository;
        private IRepository<TypePetEntity> typePetRepository;
        private IRepository<UserPetEntity> userPetRepository;
        #endregion


        #region Members
        public IRepository<UserEntity> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new Repository<UserEntity>(_context);

                return userRepository;
            }
        }

        public IRepository<RolEntity> RolRepository
        {
            get
            {
                if (this.rolRepository == null)
                    this.rolRepository = new Repository<RolEntity>(_context);

                return rolRepository;
            }
        }

        public IRepository<RolUserEntity> RolUserRepository
        {
            get
            {
                if (this.rolUserRepository == null)
                    this.rolUserRepository = new Repository<RolUserEntity>(_context);

                return rolUserRepository;
            }
        }

        public IRepository<StateEntity> StateRepository
        {
            get
            {
                if (this.stateRepository == null)
                    this.stateRepository = new Repository<StateEntity>(_context);

                return stateRepository;
            }
        }

        public IRepository<TypeStateEntity> TypeStateRepository
        {
            get
            {
                if (this.typeStateRepository == null)
                    this.typeStateRepository = new Repository<TypeStateEntity>(_context);

                return typeStateRepository;
            }
        }

        public IRepository<PermissionEntity> PermissionRepository
        {
            get
            {
                if (this.permissionRepository == null)
                    this.permissionRepository = new Repository<PermissionEntity>(_context);

                return permissionRepository;
            }
        }

        public IRepository<TypePermissionEntity> TypePermissionRepository
        {
            get
            {
                if (this.typePermissionRepository == null)
                    this.typePermissionRepository = new Repository<TypePermissionEntity>(_context);

                return typePermissionRepository;
            }
        }

        public IRepository<RolPermissionEntity> RolesPermissionRepository
        {
            get
            {
                if (this.rolPermissionRepository == null)
                    this.rolPermissionRepository = new Repository<RolPermissionEntity>(_context);

                return rolPermissionRepository;
            }
        }

        public IRepository<DatesEntity> DatesRepository
        {
            get
            {
                if (this.datesRepository == null)
                    this.datesRepository = new Repository<DatesEntity>(_context);

                return datesRepository;
            }
        }

        public IRepository<PetEntity> PetRepository
        {
            get
            {
                if (this.petRepository == null)
                    this.petRepository = new Repository<PetEntity>(_context);

                return petRepository;
            }
        }

        public IRepository<ServicesEtntity> ServicesRepository
        {
            get
            {
                if (this.servicesRepository == null)
                    this.servicesRepository = new Repository<ServicesEtntity>(_context);

                return servicesRepository;
            }
        }

        public IRepository<SexEntity> SexRepository
        {
            get
            {
                if (this.sexRepository == null)
                    this.sexRepository = new Repository<SexEntity>(_context);

                return sexRepository;
            }
        }

        public IRepository<TypePetEntity> TypePetRepository
        {
            get
            {
                if (this.typePetRepository == null)
                    this.typePetRepository = new Repository<TypePetEntity>(_context);

                return typePetRepository;
            }
        }
        public IRepository<UserPetEntity> UserPetRepository
        {
            get
            {
                if (this.userPetRepository == null)
                    this.userPetRepository = new Repository<UserPetEntity>(_context);

                return userPetRepository;
            }
        }


        #endregion


        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save() => await _context.SaveChangesAsync();
    }
}
