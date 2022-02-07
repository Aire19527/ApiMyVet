using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto
{
    public class PetDto
    {
        [Key]
        public int Id { get; set; }

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


        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string TypePet { get; set; }
        public int IdUser { get; set; }
    }
}
