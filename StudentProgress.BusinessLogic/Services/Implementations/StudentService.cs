#region
using AutoMapper;
using StudentProgress.BusinessLogic.Exceptions;
using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.BusinessLogic.Services.Interfaces;
using StudentProgress.DataAccess.Entities;
using StudentProgress.DataAccess.Repositories.Interfaces;
#endregion
namespace StudentProgress.BusinessLogic.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<StudentDto> AddStudentAsync(StudentRequest studentRequest)
        {
            var student = await _studentRepository.AddStudentAsync(_mapper.Map<Student>(studentRequest));

            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);

            if (student is null) { throw new NotFoundException("There is not a student with that id"); }

            var studentDeleted = await _studentRepository.DeleteStudentAsync(student);

            return _mapper.Map<StudentDto>(studentDeleted);
        }

        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();

            return _mapper.Map<List<StudentDto>>(students);
        }

        public async Task<StudentDto?> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);

            if (student is null) { throw new NotFoundException("There is not a student with such an id"); }

            return _mapper.Map<StudentDto>(student);
        }

        //Testing to add a Get a student then add it to the exam 
        public async Task<int> GetStudentIdByNameAsync(string studentName)
        {
            var student = await _studentRepository.GetStudentByName(studentName);

            if(student is not null) 
            { 
                return student.Id; 
            }

            else
            {
                return 0;
            }
            //return student?.Id ?? 0;
        }

        public async Task<StudentDto> UpdateStudentAsync(StudentRequest studentRequest)
        {
            var student = await _studentRepository.GetStudentByIdAsync(studentRequest.Id);

            if (student is null) { throw new NotFoundException("There is no student with such an id"); }

            _mapper.Map(studentRequest, student);
            var studentUpdated = await _studentRepository.UpdateStudentAsync(student);

            return _mapper.Map<StudentDto>(studentUpdated);
        }
    }
}
