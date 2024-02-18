namespace StudentProgress.DataAccess.Entities;

public class Faculty
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Student>? Students { get; set; }
}
