using Infraestructure.Entity.Model;
using Infraestructure.Entity.Model.Master;
using Infraestructure.Entity.Model.Vet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Core.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<RolEntity> RolEntity { get; set; }
        public DbSet<RolUserEntity> RolUserEntity { get; set; }
        public DbSet<PermissionEntity> PermissionEntity { get; set; }
        public DbSet<RolPermissionEntity> RolPermissionEntity { get; set; }
        public DbSet<TypePermissionEntity> TypePermissionEntity { get; set; }

        public DbSet<StateEntity> StateEntity { get; set; }
        public DbSet<TypeStateEntity> TypeStateEntity { get; set; }

        public DbSet<DatesEntity> DatesEntity { get; set; }
        public DbSet<PetEntity> PetEntity { get; set; }
        public DbSet<ServicesEtntity> ServicesEtntity { get; set; }
        public DbSet<SexEntity> SexEntity { get; set; }
        public DbSet<TypePetEntity> TypePetEntity { get; set; }
        public DbSet<UserPetEntity> UserPetEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
               .HasIndex(b => b.Email)
               .IsUnique();

            modelBuilder.Entity<TypeStateEntity>().Property(t => t.IdTypeState).ValueGeneratedNever();
            modelBuilder.Entity<TypePermissionEntity>().Property(t => t.IdTypePermission).ValueGeneratedNever();
            modelBuilder.Entity<StateEntity>().Property(t => t.IdState).ValueGeneratedNever();
            modelBuilder.Entity<RolEntity>().Property(t => t.IdRol).ValueGeneratedNever();
            modelBuilder.Entity<PermissionEntity>().Property(t => t.IdPermission).ValueGeneratedNever();
        }
    }
}
