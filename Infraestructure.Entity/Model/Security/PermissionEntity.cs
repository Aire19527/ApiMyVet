using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Model
{
    [Table("Permission", Schema = "Security")]
    public class PermissionEntity
    {
        [Key]
        public int IdPermission { get; set; }

        [MaxLength(100)]
        public string Permission { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        [ForeignKey("TypePermissionEntity")]
        public int IdTypePermission { get; set; }

        public TypePermissionEntity TypePermissionEntity { get; set; }

        public IEnumerable<RolPermissionEntity> RolPermissionEntities { get; set; }
    }
}
