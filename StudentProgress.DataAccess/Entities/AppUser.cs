namespace StudentProgress.DataAccess.Entities;

public class AppUser
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role? Role { get; set; }
    public int? RoleId { get; set; }
}
