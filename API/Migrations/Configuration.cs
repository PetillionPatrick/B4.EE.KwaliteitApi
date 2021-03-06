namespace API.Migrations
{
    using API.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<API.Models.APIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(API.Models.APIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Users.AddOrUpdate(
            new User() { Id = Guid.Empty}
            );

            //context.Beuks.AddOrUpdate(
            //new Beuk() { Id = Guid.NewGuid(), Naam = "beuk 1", OwnerId = Guid.Empty },
            // new Beuk() { Id = Guid.NewGuid(), Naam = "beuk 2", OwnerId = Guid.Empty }
            //);
        }
    }
}
