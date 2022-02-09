using System;
using System.ComponentModel.DataAnnotations;

namespace MyVet.Domain.Dto.Dates
{
    public class InsertDatesDto
    {
        public DateTime Date { get; set; }

        [MaxLength(100)]
        public string Contact { get; set; }

        public int IdServices { get; set; }

        public int IdPet { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
    }
}
