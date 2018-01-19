using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.DTO
{
    public class OperatorDTO
    {
        public Guid Id { get; set; }

        public string Nummer { get; set; }

        public string Naam { get; set; }

        public bool Technisch { get; set; }
    }
}