using StudentManagementAPI.Interfaces;
using StudentManagementAPI.Models;
using StudentManagementAPI.Repositories;

namespace StudentManagementAPI.Services
{
    public class StudentService : StudentRepository, IStudentService
    {
        public StudentService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<Student> CreateStudent(Student student)
        {
            await CreateAsync(student);
            return student;
        }

        public Task<List<Student>> GetAllStudents()
        {
            return GetAll();
        }

        public Task<Student> GetStudent(string id)
        {
            return GetByIdAsync(id);
        }

        public Task<bool> DeleteStudent(string id)
        {
            return DeleteAsync(id);
        }

        public Task<Student> UpdateStudent(string id, Student student)
        {
            return UpdateAsync(student);
        }
    }
}
