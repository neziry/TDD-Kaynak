using System.Collections.Generic;
using System.Linq;
using TDDExample2.Entities;
using TDDExample2.Infrastructures;
using TDDExample2.UnitTests;

namespace TDDExample2.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> GetStudentListByGradeAverage(float average)
        {
            if (average == 0)
            {
                throw new ThereIsNoStudentException();
            }
            using(var context = new StudentDbContext())
            {
                return context.Students.Where(x => x.Average == average).ToList();
            }
        }

        public List<Student> GetStudents()
        {
            using (var context = new StudentDbContext())
            {
                return context.Students.ToList();
            }
        }
    }
}