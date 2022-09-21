using StudentManagementAPI.Interfaces;
using StudentManagementAPI.Models;
using StudentManagementAPI.Repositories;

namespace StudentManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> CreateStudent(Student newStudent)
        {
            newStudent.ChangedDate = DateTime.Now;
            newStudent.CreatedDate = DateTime.Now;
            await _studentRepository.CreateStudent(newStudent);
            return await GetStudent(newStudent.Id);
        }

        public async Task<bool> DeleteStudent(string id)
        {
            var student = await _studentRepository.GetStudent(id);
            if (student == null)
            {
                throw new InvalidDataException();
            }

            return await _studentRepository.DeleteStudent(id);
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _studentRepository.GetAllStudents();
        }

        public async Task<Student> GetStudent(string id)
        {
            var student = await _studentRepository.GetStudent(id);
            if (student == null)
            {
                throw new InvalidDataException();
            }

            return student;
        }

        public async Task<Student> UpdateStudent(Student updatedStudent)
        {
            updatedStudent.ChangedDate = DateTime.Now;
            var student = await _studentRepository.GetStudent(updatedStudent.Id);
            if (student == null)
            {
                throw new InvalidDataException();
            }

            await _studentRepository.UpdateStudent(updatedStudent);
            return await GetStudent(updatedStudent.Id);
        }
    }
}
