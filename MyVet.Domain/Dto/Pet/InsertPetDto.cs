using System;
using System.ComponentModel.DataAnnotations;

namespace MyVet.Domain.Dto.Pet
{
    public class InsertPetDto
    {
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime DateBorns { get; set; }

        [Required(ErrorMessage = "El Sexo es requerido")]
        public int IdSex { get; set; }

        [Required(ErrorMessage = "El Tipo Mascota es requerido")]
        public int IdTypePet { get; set; }


        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}
