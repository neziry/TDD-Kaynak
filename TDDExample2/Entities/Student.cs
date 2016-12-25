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

namespace TDDExample2.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Average { get; set; }
    }
}
