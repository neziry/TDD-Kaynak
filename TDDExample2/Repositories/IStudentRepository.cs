using System.Collections.Generic;
using TDDExample2.Entities;

namespace TDDExample2.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetStudentListByGradeAverage(int average);
    }
}