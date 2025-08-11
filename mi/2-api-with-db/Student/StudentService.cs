using System.Collections.Concurrent;

namespace _2_api_with_db.Student;

public class StudentService : IStudentService
{

    private static ConcurrentBag<Student> _students =
    [
        new Student("nursyah", "nursyah@gmail.com"),
        new Student("rahman", "rahman@gmail.com"),
        new Student("arif", "arif@gmail.com"),
        new Student("nestafa", "nestafa@gmail.com"),
        new Student("ibrahim", "ibrahim@gmail.com"),
    ];

    private static int _studentId = 5;

    public Student AddStudent(StudentDto newStudent)
    {
        if (_students.Any(s => s.Email.Equals(newStudent.Email, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ArgumentException($"Email {newStudent.Email} already registered");
        }

        int newId = GetNextId();
        var student = new Student(newStudent.Name, newStudent.Email);
        _students.Add(student);

        return student;
    }

    public bool DeleteStudent(int id)
    {
        var studentToRemove = _students.FirstOrDefault(s => s.Id == id);
        return studentToRemove != null && _students.TryTake(out studentToRemove);
    }

    public IEnumerable<Student> GetAllStudents()
    {
        return _students.OrderBy(s=>s.Id);
    }

    public int GetNextId()
    {
       return Interlocked.Increment(ref _studentId);
    }

    public Student? GetStudentById(int id)
    {
       return _students.FirstOrDefault(s => s.Id == id);
    }

    public Student? UpdateStudent(int id, StudentDto updatedStudent)
    {
        var existingStudent = _students.FirstOrDefault(s => s.Id == id);
        if (existingStudent == null)
        {
            return null;
        }

        if (_students.Any(s => s.Id != id && s.Email.Equals(updatedStudent.Email, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ArgumentException($"Email {updatedStudent.Email} already registered by another student");
        }
        
        _students.TryTake(out _);

        var updatedStudentRecord = new Student(updatedStudent.Name, updatedStudent.Email);
        _students.Add(updatedStudentRecord);

        return updatedStudentRecord;
    }

}