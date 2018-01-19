using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class APIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public APIContext() : base("name=APIContext")
        {
        }

        public System.Data.Entity.DbSet<API.Models.Afkeur> Afkeurs { get; set; }

        public System.Data.Entity.DbSet<API.Models.Status> Status { get; set; }

        public System.Data.Entity.DbSet<API.Models.Beuk> Beuks { get; set; }

        public System.Data.Entity.DbSet<API.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<API.Models.Machine> Machines { get; set; }

        public System.Data.Entity.DbSet<API.Models.Operator> Operators { get; set; }

        public System.Data.Entity.DbSet<API.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<API.Models.Unit> Units { get; set; }

        public System.Data.Entity.DbSet<API.Models.LineInspector> LineInspectors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>()
                .HasRequired(m => m.Order)
                .WithMany(t => t.Statussen)
                .HasForeignKey(m => m.OrderId)
                .WillCascadeOnDelete(false);
        }

        
    }
}
