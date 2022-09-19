using StudentManagementAPI.Models;

namespace StudentManagementAPI.Interfaces
{
    public interface IStudentService
    {
        /// <summary>
        /// Get All Students
        /// </summary>
        /// <returns>Task&lt;List&lt;Student&gt;&gt;</returns>
        Task<List<Student>> GetAllStudents();

        /// <summary>
        /// Get Student
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <returns>Task&lt;Student&gt;.</returns>
        Task<Student> GetStudent(string id);

        /// <summary>
        /// Create a Student
        /// </summary>
        /// <param name="student">Student</param>
        /// <returns>Task&lt;Student&gt;.</returns>
        Task<Student> CreateStudent(Student student);

        /// <summary>
        /// Update Student
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <param name="student">Student</param>
        /// <returns>Task&lt;Student&gt;.</returns>
        Task<Student> UpdateStudent(string id, Student student);

        /// <summary>
        /// Remove Student
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <returns>Task&lt;bool&gt;.</returns>
        Task<bool> DeleteStudent(string id);
    }
}
