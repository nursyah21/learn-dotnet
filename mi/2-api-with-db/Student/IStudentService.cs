
namespace _2_api_with_db.Student;

public interface IStudentService
{
    IEnumerable<Student> GetAllStudents();
    Student? GetStudentById(int id);
    Student AddStudent(StudentDto newStudent);
    Student? UpdateStudent(int id, StudentDto updatedStudent);
    bool DeleteStudent(int id);
    int GetNextId();
}