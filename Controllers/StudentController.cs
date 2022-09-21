using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Interfaces;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("/students")]
        public async Task<List<Student>> GetAllStudents()
        {
            return await _studentService.GetAllStudents();
        }

        [HttpGet("/student/{id}")]
        public async Task<Student> GetStudent(string id)
        {
            return await _studentService.GetStudent(id);
        }

        [HttpPost("/student")]
        public async Task<Student> PostStudent(Student newStudent)
        {
            return await _studentService.CreateStudent(newStudent);
        }

        [HttpPut("/student")]
        public async Task<Student> Put(Student updatedStudent)
        {
            return await _studentService.UpdateStudent(updatedStudent);
        }

        [HttpDelete("/student/{id}")]
        public async Task<bool> Delete(string id)
        {
            return await _studentService.DeleteStudent(id);
        }
    }
}
