using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class LineInspector
    {
        [Key]
        public Guid Id { get; set; }

        public string Nummer { get; set; }

        public string Naam { get; set; }

        [NotMapped]
        public bool Edit { get; set; }

        public virtual List<Status> StatussenLi { get; set; }
    }
}