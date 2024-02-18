using System.ComponentModel.DataAnnotations;

namespace StudentProgress.BusinessLogic.Requests;

public class UserLogin
{
    [EmailAddress]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
