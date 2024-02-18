using System.ComponentModel.DataAnnotations;

namespace StudentProgress.BusinessLogic.Requests;

public class SpecialtyRequest
{
    public int Id { get; set; }
    [Required(ErrorMessage ="This field is required")]
    public string SpecialtyName { get; set; }
}
