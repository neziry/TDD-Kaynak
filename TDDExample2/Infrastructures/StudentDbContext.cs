
using System.Data.Entity;
using TDDExample2.Entities;

namespace TDDExample2.Infrastructures
{
    public class StudentDbContext  : DbContext
    {
        public StudentDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<StudentDbContext>());
        }

        public virtual DbSet<Student> Students { get; set; }
    }
}