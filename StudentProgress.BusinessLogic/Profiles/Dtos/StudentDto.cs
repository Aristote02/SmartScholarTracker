namespace StudentProgress.BusinessLogic.Profiles.Dtos
{
    public class StudentDto
    {
        public int Id {  get; set; }
        public int FacultyId { get; set; }
        public string Faculty { get; set; } = string.Empty;
		public int SpecialtyId { get; set; }
		public string Specialty { get; set; }
		public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { 
            get
            {
                return FirstName + " " + LastName;
            } 
        }
        
        public int Age {  get; set; }
        public string GroupName { get ; set; }
    }
}
