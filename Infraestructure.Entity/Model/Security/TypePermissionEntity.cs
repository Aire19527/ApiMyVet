using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Model
{
    [Table("TypePermission", Schema = "Security")]
    public class TypePermissionEntity
    {
        [Key]
        public int IdTypePermission { get; set; }

        [MaxLength(50)]
        public string TypePermission { get; set; }

        public IEnumerable<PermissionEntity> PermissionEntities { get; set; }
    }
}
