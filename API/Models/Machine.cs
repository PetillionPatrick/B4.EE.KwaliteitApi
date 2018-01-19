using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Machine
    {
        [Key]
        public Guid Id { get; set; }

        public string Naam { get; set; }

        [NotMapped]
        public bool Edit { get; set; }

        //Foreign key for Beuk
        public Guid BeukId { get; set; }
        // Navigation property
        public virtual Beuk Beuk { get; set; }

        public virtual List<Status> Statussen { get; set; }
    }
}