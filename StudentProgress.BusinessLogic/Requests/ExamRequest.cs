using System.ComponentModel.DataAnnotations;

namespace StudentProgress.BusinessLogic.Requests;

public class ExamRequest
{
    public int Id { get; set; }
    public int StudentId {  get; set; }
    public int TestId {  get; set; }
    [Required]
    [Range(0,10, ErrorMessage = "The point must be between 0 and 10")]
    public double Point { get; set; }
}
