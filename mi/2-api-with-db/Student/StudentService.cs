using Microsoft.EntityFrameworkCore;

namespace _2_api_with_db.Student;

public class StudentService : IStudentService
{

    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public Student AddStudent(StudentDto newStudent)
    {
        var student = new Student(newStudent.Name, newStudent.Email);
        try
        {
            return _studentRepository.Add(student);
        }
        catch (DbUpdateException ex)
        {
            throw new ArgumentException($"Email '{newStudent.Email}' already registered.", ex);
        }
    }

    public bool DeleteStudent(int id)
    {
        return _studentRepository.RemoveById(id);
    }

    public IEnumerable<Student> GetAllStudents()
    {
        return _studentRepository.GetAll();
    }

    public Student? GetStudentById(int id)
    {
       return _studentRepository.GetById(id);
    }

    public Student? UpdateStudent(int id, StudentDto updatedStudent)
    {
        var newData = new Student(updatedStudent.Name, updatedStudent.Email);

        try
        {
            return _studentRepository.UpdateById(id, newData);
        }
        catch (DbUpdateException ex)
        {
            throw new ArgumentException($"Email '{updatedStudent.Email}' already registed by another student.", ex);
        }
    }
}