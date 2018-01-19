using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Afkeur
    {
        [Key]
        public Guid Id { get; set; }

        public string Reden { get; set; }

        [NotMapped]
        public bool Edit { get; set; }

        //Foreign key for Status
        public Guid StatusId { get; set; }

        // Navigation property
        public virtual Status Status { get; set; }
    }
}