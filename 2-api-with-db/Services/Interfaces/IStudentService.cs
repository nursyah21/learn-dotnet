using _2_api_with_db.Models;

namespace _2_api_with_db.Services.Interfaces;

public interface IStudentService
{
    IEnumerable<Student> GetAllStudents();
    Student? GetStudentById(int id);
    Student AddStudent(CreateStudent newStudent);
    Student? UpdateStudent(int id, CreateStudent updatedStudent);
    bool DeleteStudent(int id);

    int GetNextId();
}