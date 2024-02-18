namespace StudentProgress.BusinessLogic.Profiles.Dtos;

public class ExamDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int TestId { get; set; }
    public string TestName { get; set; } = string.Empty;
    public double Point { get; set; }
}