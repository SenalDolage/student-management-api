using StudentManagementAPI.Models;

namespace StudentManagementAPI.Interfaces
{
    public interface ICourseRepository
    {
        /// <summary>
        /// Get All Courses
        /// </summary>
        /// <returns>Task&lt;List&lt;Course&gt;&gt;</returns>
        Task<List<Course>> GetAllCourses();
    }
}
