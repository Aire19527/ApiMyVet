using MyVet.Domain.Dto.Dates;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyVet.Domain.Dto
{
    public class DatesDto : InsertDatesDto
    {
        public int Id { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int IdState { get; set; }

        [MaxLength(300)]
        public string Observation { get; set; }
        public int? IdUserVet { get; set; }

    }
}
