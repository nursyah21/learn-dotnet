using _2_api_with_db.DTOs;
using _2_api_with_db.Models;

namespace _2_api_with_db.Services.Interfaces;

public interface IStudentService
{
    IEnumerable<Student> GetAllStudents();
    Student? GetStudentById(int id);
    Student AddStudent(CreateStudentDto newStudent);
    Student? UpdateStudent(int id, CreateStudentDto updatedStudent);
    bool DeleteStudent(int id);

    int GetNextId();
}