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

namespace TDDExample2.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Average { get; set; }
    }
}
