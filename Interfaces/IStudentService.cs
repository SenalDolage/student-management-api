using StudentManagementAPI.Models;

namespace StudentManagementAPI.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student GetStudent(string id);
        Student CreateStudent(Student student);
        bool UpdateStudent(string id, Student student);
        bool RemoveStudent(string id);
    }
}
