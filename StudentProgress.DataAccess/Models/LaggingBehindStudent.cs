namespace StudentProgress.DataAccess.Models;

public class LaggingBehindStudent
{
    public string? StudentName { get; set; }
    public string Specialty { get; set; } = string.Empty;
    public double Point { get; set; }
}
