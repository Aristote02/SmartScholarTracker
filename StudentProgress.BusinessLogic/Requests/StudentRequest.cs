using StudentProgress.DataAccess.Data.Enum;

namespace StudentProgress.BusinessLogic.Requests;

public class StudentRequest
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public int FacultyId { get; set; }
    public int SpecialtyId { get; set; }
    public StudentGroup Group { get; set; }
}
