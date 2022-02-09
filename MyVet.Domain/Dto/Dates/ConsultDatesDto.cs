namespace MyVet.Domain.Dto.Dates
{
    public class ConsultDatesDto : DatesDto
    {
        public string Estado { get; set; }
        public string Servicio { get; set; }
        public string Mascota { get; set; }
        public string StrClosingDate { get; set; }
        public string StrDate { get; set; }
    }
}
