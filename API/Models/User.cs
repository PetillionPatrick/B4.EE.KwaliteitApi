using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public virtual List<Beuk> Beuken { get; set; }
    }
}