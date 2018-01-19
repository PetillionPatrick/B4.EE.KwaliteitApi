using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Beuk
    {
        [Key]
        public Guid Id { get; set; }

        public string Naam { get; set; }

        [NotMapped]
        public bool Edit { get; set; }

        public virtual List<Machine> Machines { get; set; }

        //Foreign key for Owner
        public Guid OwnerId { get; set; }
        // Navigation property
        public virtual User Owner { get; set; }
    }
}