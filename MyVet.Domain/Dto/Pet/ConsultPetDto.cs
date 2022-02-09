namespace MyVet.Domain.Dto.Pet
{
    public class ConsultPetDto : PetDto
    {
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string TypePet { get; set; }
        public int IdUser { get; set; }
    }
}
