namespace StudentProgress.DataAccess.Entities;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Test>? Tests { get; set;}
}

