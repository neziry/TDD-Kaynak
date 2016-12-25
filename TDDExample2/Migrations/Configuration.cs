using TDDExample2.Entities;

namespace TDDExample2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TDDExample2.Infrastructures.StudentDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TDDExample2.Infrastructures.StudentDbContext context)
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

            context.Students.AddOrUpdate(
                new Student { Name = "Student", Average = 4 },
                new Student { Name = "Student", Average = 4 },
                new Student { Name = "Student", Average = 4 },
                new Student { Name = "Student", Average = 3 },
                new Student { Name = "Student", Average = 3 }
                );
        }
    }
}
