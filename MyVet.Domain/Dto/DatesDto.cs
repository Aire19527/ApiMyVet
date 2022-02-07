using System;
using System.ComponentModel.DataAnnotations;

namespace MyVet.Domain.Dto
{
    public class DatesDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [MaxLength(100)]
        public string Contact { get; set; }

        public int IdServices { get; set; }

        public int IdPet { get; set; }

        public DateTime? ClosingDate { get; set; }

        public int IdState { get; set; }

        [MaxLength(300)]
        public string Description { get; set; } 
        [MaxLength(300)]
        public string Observation { get; set; }

        public int? IdUserVet { get; set; }

        public string Estado { get; set; }
        public string Servicio { get; set; }
        public string Mascota { get; set; }
        public string StrClosingDate { get; set; }
        public string StrDate{ get; set; }

    }
}
