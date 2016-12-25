using System.Collections.Generic;
using TDDExample2.Entities;
using TDDExample2.Repositories;

namespace TDDExample2.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> GetStudentListByGradeAverage(int average)
        {
            return _studentRepository.GetStudentListByGradeAverage(average);
        }
    }
}