using _1_api_without_db.Models;

namespace _1_api_without_db.Services.Interfaces;

public interface IStudentService
{
    IEnumerable<Student> GetAllStudents();
    Student? GetStudentById(int id);
    Student AddStudent(CreateStudent newStudent);
    Student? UpdateStudent(int id, CreateStudent updatedStudent);
    bool DeleteStudent(int id);

    int GetNextId();
}