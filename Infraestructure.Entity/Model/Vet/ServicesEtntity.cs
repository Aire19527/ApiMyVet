using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Model.Vet
{
    [Table("Services", Schema = "Vet")]
    public class ServicesEtntity
    {
        [Key]
        public int Id { get; set; }

        public string Services { get; set; }
        public string Description { get; set; }
    }
}
