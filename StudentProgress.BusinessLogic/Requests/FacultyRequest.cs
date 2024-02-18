using System.ComponentModel.DataAnnotations;

namespace StudentProgress.BusinessLogic.Requests;

public class FacultyRequest
{
    public int Id { get; set; }
    [Required(ErrorMessage = "This value should not be null")]
    [StringLength(25, MinimumLength = 5, ErrorMessage = "The value must be between 5 and 25 characters")]
    public string FacultyName { get; set; } = string.Empty;
}
