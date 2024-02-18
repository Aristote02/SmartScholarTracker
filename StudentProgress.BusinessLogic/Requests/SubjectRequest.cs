using System.ComponentModel.DataAnnotations;

namespace StudentProgress.BusinessLogic.Requests;

public class SubjectRequest
{
    public int Id { get; set; }
    [Required(ErrorMessage ="This field is required")]
    public string SubjectName { get; set; }
}
