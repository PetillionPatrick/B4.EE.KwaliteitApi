using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Status
    {
        [Key]
        public Guid Id { get; set; }

        public string[] StatusKeuze { get; set; }

        public string GekozenStatus { get; set; }

        public virtual DateTime Datum { get; set; }

        public string VormNr { get; set; }

        public string PartNummer { get; set; }

        public string ArchiefNr { get; set; }

        public string ReparatieNummer { get; set; }

        public bool ProefSpuiting { get; set; }

        [NotMapped]
        public bool Edit { get; set; }

        //Foreign key for Operator
        public Guid OperatorId { get; set; }

        public virtual Operator Operator { get; set; }

        //Foreign key for OperatorLi
        public Guid LiId { get; set; }

        public virtual LineInspector Li { get; set; }

        public virtual List<Unit> Units { get; set; }

        public virtual List<Afkeur> Afkeuren { get; set; }

        //Foreign key for Machine
        public Guid MachineId { get; set; }
        // Navigation property
        public virtual Machine Machine { get; set; }

        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }

        public Status()
        {
            StatusKeuze = new string[]
            {
                "Geen produktie", "Start", "Reparatie", "Einde", "Afkeur"
            };
        }
    }
}