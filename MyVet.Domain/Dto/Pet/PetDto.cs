using MyVet.Domain.Dto.Pet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto
{
    public class PetDto: InsertPetDto
    {
        [Key]
        public int Id { get; set; }

    }
}
