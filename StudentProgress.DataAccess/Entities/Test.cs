using StudentProgress.DataAccess.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentProgress.DataAccess.Entities;

public class Test
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Subject")]
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public DateTime DateTime { get; set; }
    public TypeOfTest TypeOfTest { get; set; }

    public List<Exam>? Exams { get; set; }
}
