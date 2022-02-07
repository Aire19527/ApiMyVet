using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Model.Master
{
    [Table("State", Schema = "Master")]
    public class StateEntity
    {
        [Key]
        public int IdState { get; set; }

        [MaxLength(100)]    
        public string State { get; set; }

        [ForeignKey("TypeStateEntity")]
        public int IdTypeState { get; set; }
        public TypeStateEntity TypeStateEntity { get; set; }

    }
}
