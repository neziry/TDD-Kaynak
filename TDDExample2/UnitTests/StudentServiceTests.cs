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
        [Test]
        public void GetStudentListByGradeAverage_GetStudentListWhoGradeAverageIsEqualToFour_GivenTwoStudent()
        {
            //arrange
            Mock<IStudentRepository> mockStudentRepository = new Mock<IStudentRepository>();
            mockStudentRepository.Setup(m => m.GetStudentListByGradeAverage(4)).Returns(new List<Student>
            {
                new Student(),
                new Student()
            });
            IStudentRepository studentRepository = mockStudentRepository.Object;
            var service = new StudentService(studentRepository);

            //act 
            var list = service.GetStudentListByGradeAverage(4);

            //assert
            Assert.AreEqual(list.Count, 2);
        }

        [Test]
        public void GetStudentListByGradeAverage_GetStudentListWhoGradeAverageIsEqualToThree_GivenThreeStudent()
        {
            //arrange
            Mock<IStudentRepository> mockStudentRepository = new Mock<IStudentRepository>();
            mockStudentRepository.Setup(m => m.GetStudentListByGradeAverage(3)).Returns(new List<Student>
            {
                new Student(),
                new Student(),
                new Student()
            });
            IStudentRepository studentRepository = mockStudentRepository.Object;
            var service = new StudentService(studentRepository);

            //act 
            var list = service.GetStudentListByGradeAverage(3);

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
            Assert.Throws<ThereIsNoStudentException>(() => service.GetStudentListByGradeAverage(0));
        }
    }
}