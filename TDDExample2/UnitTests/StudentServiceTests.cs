#region Scenario

/*
 * Mezuniyet ortalamas�na g�re ��renci listesi getirme 
 * 1- Ortalamas� 4'e e�it olan 2 ��renci getir
 * 2- Ortalamas� 3'e e�it olan 3 ��renci getir
 * 3- ortalamas� 0 olan ��rencileri �a��r exception at
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