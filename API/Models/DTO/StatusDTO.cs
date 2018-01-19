using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.DTO
{
    public class StatusDTO
    {
        public Guid Id { get; set; }

        public string GekozenStatus { get; set; }

        public DateTime Datum { get; set; }

        public string VormNr { get; set; }

        public string PartNummer { get; set; }

        public string ArchiefNr { get; set; }

        public string ReparatieNummer { get; set; }

        public bool ProefSpuiting { get; set; }

        public Guid OperatorId { get; set; }

        public Guid OperatorLiId { get; set; }

        public Guid MachineId { get; set; }

        public Guid OrderId { get; set; }

    }
}