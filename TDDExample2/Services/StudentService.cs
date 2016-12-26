using System.Collections.Generic;
using System.Linq;
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

        public List<Student> GetStudentListByGradeAverage(float average, bool fromUnitTest)
        {
            return fromUnitTest ? _studentRepository.GetStudents().Where(x => x.Average == average).ToList() 
                                : _studentRepository.GetStudentListByGradeAverage(average);
        }

        public List<Student> GetStudents()
        {
            return _studentRepository.GetStudents();
        }
    }
}