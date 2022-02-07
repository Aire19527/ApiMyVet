using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Model.Vet
{
    [Table("UserPet", Schema = "Vet")]
    public class UserPetEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PetEntity")]
        public int IdPet { get; set; }

        public PetEntity PetEntity { get; set; }

        [ForeignKey("UserEntity")]
        public int IdUser { get; set; }

        public UserEntity UserEntity { get; set; }
    }
}
