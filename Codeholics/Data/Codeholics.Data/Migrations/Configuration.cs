namespace Codeholics.Data.Migrations
{
    using System;
    using System.Linq;
    using System.Data.Entity.Migrations;

    using Models;


    public sealed class Configuration : DbMigrationsConfiguration<CodeholicsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CodeholicsDbContext context)
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

            context.Projects.AddOrUpdate(
                pr => pr.Title,
                    new Project
                    {
                        StartDate = DateTime.Now,
                        Title = "StudentSystem",
                        Description = "This is vary meanongfull description, so much that i can't stop writing",
                        Creator = "Pesho"
                    }
                );

            context.SaveChanges();
        }
    }
}
