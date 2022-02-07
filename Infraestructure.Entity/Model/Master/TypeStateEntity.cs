using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Model.Master
{
    [Table("TypeState", Schema = "Master")]
    public class TypeStateEntity
    {
        [Key]
        public int IdTypeState { get; set; }

        [MaxLength(100)]
        public string TypeState { get; set; }
    }
}
