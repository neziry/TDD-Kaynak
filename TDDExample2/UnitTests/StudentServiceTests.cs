#region Scenario

/*
 * Mezuniyet ortalamasýna göre öðrenci listesi getirme 
 * 1- Ortalamasý 4'e eþit olan 2 öðrenci getir
 * 2- Ortalamasý 3'e eþit olan 3 öðrenci getir
 * 3- ortalamasý 0 olan öðrencileri çaðýr exception at
 * 
 *****************************************************
 * Material
 * StudentService
 * IStudentRepository
 */

#endregion


using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TDDExample2.Entities;
using TDDExample2.Repositories;
using TDDExample2.Services;

namespace TDDExample2.UnitTests
{
    [TestFixture]
    public class StudentServiceTests
    {
        private IStudentRepository _studentRepository;
        private readonly Mock<IStudentRepository> _mockStudentRepository;
        private List<Student> _students;

        public StudentServiceTests()
        {
            _mockStudentRepository = new Mock<IStudentRepository>();
        }


        [SetUp]
        public void BeforeRun()
        {
            _studentRepository = _mockStudentRepository.Object;
            _students = new List<Student>()
            {
                new Student() {Name = "nezir", Average= 4},
                new Student() {Name = "mesut", Average= 2.6f},
                new Student() {Name = "fatih", Average= 3},
                new Student() {Name = "Aytül", Average= 3.5f},
                new Student() {Name = "Halil", Average= 3},
                new Student() {Name = "Salih", Average= 3},
                new Student() {Name = "Beytullah", Average= 4},
                new Student() {Name = "mesut2", Average= 1.5f},
                new Student() {Name = "mesut3", Average= 1.6f},
            };
        }

        [Test]
        public void GetStudentListByGradeAverage_GetStudentListWhoGradeAverageIsEqualToFour_GivenTwoStudent()
        {
            //Arrange
            _mockStudentRepository.Setup(x => x.GetStudents()).Returns(_students);
            var service = new StudentService(_studentRepository);

            //act
            var result = service.GetStudentListByGradeAverage(4, true);

            //assert
            Assert.AreEqual(result.Count, 2);
        }

        [Test]
        public void GetStudentListByGradeAverage_GetStudentListWhoGradeAverageIsEqualToThree_GivenOneStudent()
        {
            //Arrange
            _mockStudentRepository.Setup(x => x.GetStudents()).Returns(_students);
            var service = new StudentService(_studentRepository);

            //act 
            var list = service.GetStudentListByGradeAverage(4, true);

            //assert
            Assert.AreEqual(list.Count, 2);
        }

        [Test]
        public void GetStudentListByGradeAverage_GetStudentListWhoGradeAverageIsEqualToThree_GivenThreeStudent()
        {
            //Arrange
            _mockStudentRepository.Setup(x => x.GetStudents()).Returns(_students);
            var service = new StudentService(_studentRepository);

            //act 
            var list = service.GetStudentListByGradeAverage(3, true);

            //assert
            Assert.AreEqual(list.Count, 3);
        }

        [Test]
        public void GetStudentListByGradeAverage_GetStudentListWhoGradeAverageIsEqualToZero_ThrowThereIsNoStudentException()
        {
            //arrange
            Mock<IStudentRepository> mockStudentRepository = new Mock<IStudentRepository>();
            mockStudentRepository.Setup(m => m.GetStudentListByGradeAverage(0)).Throws<ThereIsNoStudentException>();
            IStudentRepository studentRepository = mockStudentRepository.Object;
            var service = new StudentService(studentRepository);

            //act
            //assert
            Assert.Throws<ThereIsNoStudentException>(() => service.GetStudentListByGradeAverage(0, false));
        }
    }
}