using MongoDB.Driver;
using StudentManagementAPI.Interfaces;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Repositories
{
    //ToDo: Inherit from BaseRepository<Student>
    public class StudentRepository : IStudentRepository
    {
        private readonly IMongoCollection<Student> _studentCollection;

        public StudentRepository(IMongoDatabase mongoDatabase)
        {
            _studentCollection = mongoDatabase.GetCollection<Student>("Students");
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _studentCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Student> GetStudent(string id)
        {
            return await _studentCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Student> CreateStudent(Student student)
        {
            await _studentCollection.InsertOneAsync(student);
            return student;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            await _studentCollection.ReplaceOneAsync(x => x.Id == student.Id, student);
            return student;
        }

        public async Task<bool> DeleteStudent(string id)
        {
            await _studentCollection.DeleteOneAsync(x => x.Id == id);
            return true;
        }
    }
}
