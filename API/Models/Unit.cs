using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Unit
    {
        [Key]
        public Guid Id { get; set; }

        public string Naam { get; set; }

        [NotMapped]
        public bool Edit { get; set; }

        //Foreign key for Order
        public Guid OrderId { get; set; }
        // Navigation property
        public virtual Order Order { get; set; }

        //Foreign key for Status
        public Guid StatusId { get; set; }
        // Navigation property
        public virtual Status Status { get; set; }
    }
}