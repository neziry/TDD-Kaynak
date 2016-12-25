#region Scenario

/*
 * Mezuniyet ortalamasına göre öğrenci listesi getirme 
 * 1- Ortalaması 4'e eşit olan 2 öğrenci getir
 * 2- Ortalaması 3'e eşit olan 3 öğrenci getir
 * 3- ortalaması 0 olan öğrencileri çağır exception at
 * 
 *****************************************************
 * Material
 * StudentService
 * StudentRepository
 */

#endregion


using NUnit.Framework;
using TDDExample2.Repositories;
using TDDExample2.UnitTests;

namespace TDDExample2.IntegrationTests
{
    [TestFixture]
    public class StudentRepositoryTests
    {
        [Test]
        public void GetStudentListByGradeAverage_GetStudentListWhoGradeAverageIsEqualToFour_GivenThreeStudent()
        {
            //arrange
            var repository = new StudentRepository();

            //act 
            var list = repository.GetStudentListByGradeAverage(4);

            //assert
            Assert.AreEqual(list.Count, 3);
        }

        [Test]
        public void GetStudentListByGradeAverage_GetStudentListWhoGradeAverageIsEqualTothree_GivenTwoStudent()
        {
            //arrange
            var repository = new StudentRepository();

            //act 
            var list = repository.GetStudentListByGradeAverage(3);

            //assert
            Assert.AreEqual(list.Count, 2);
        }

        [Test]
        public void GetStudentListByGradeAverage_GetStudentListWhoGradeAverageIsEqualToZero_ThrowException()
        {
            //arrange
            var repository = new StudentRepository();

            //act 
            //assert
            Assert.Throws<ThereIsNoStudentException>(() => repository.GetStudentListByGradeAverage(0));
        }
    }
}