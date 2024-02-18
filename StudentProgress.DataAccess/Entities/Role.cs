namespace StudentProgress.DataAccess.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<AppUser>? AppUsers { get; set; }
}
