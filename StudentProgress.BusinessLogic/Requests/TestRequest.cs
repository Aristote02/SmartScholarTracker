using StudentProgress.DataAccess.Data.Enum;

namespace StudentProgress.BusinessLogic.Requests
{
    public class TestRequest
    {
        public int Id { get; set; }
        public int SubjectId {  get; set; }
        public TypeOfTest TypeOfTest { get; set; }
    }
}
