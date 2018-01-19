using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }

        public string Naam { get; set; }
    }
}