using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Model
{
    [Table("Rol", Schema = "Security")]
    public class RolEntity
    {
        [Key]
        public int IdRol { get; set; }

        [MaxLength(100)]
        public string Rol { get; set; }

        public IEnumerable<RolUserEntity> RolUserEntities { get; set; }
        public IEnumerable<RolPermissionEntity> RolPermissionEntities { get; set; }
    }
}
