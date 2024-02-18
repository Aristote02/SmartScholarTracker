using StudentProgress.DataAccess.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentProgress.DataAccess.Entities;

public class Student
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(25)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [StringLength(25)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [Range(13, 35, ErrorMessage = "Age must be between 13 and 35")]
    public int Age { get; set; }
    [ForeignKey("Faculty")]
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }

    [ForeignKey("Specialty")]
    public int SpecialtyId { get; set; }
    public Specialty Specialty { get; set; }
    public StudentGroup Group { get; set; }

    public List<Exam>? Exams {  get; set; }
}
