using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentProgress.DataAccess.Entities;

public class Exam
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public Student Student { get; set; }
    [ForeignKey("Test")]
    public int TestId { get; set; }
    public Test Test { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public double Point { get; set; }

}
