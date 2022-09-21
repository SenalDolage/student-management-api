using MongoDB.Driver;
using StudentManagementAPI.Interfaces;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Repositories
{
    //ToDo: Inherit from BaseRepository<Course>
    public class CourseRepository : ICourseRepository
    {
        private readonly IMongoCollection<Course> _courseCollection;

        public CourseRepository(IMongoDatabase mongoDatabase)
        {
            _courseCollection = mongoDatabase.GetCollection<Course>("Courses");
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _courseCollection.Find(_ => true).ToListAsync();
        }
    }
}
