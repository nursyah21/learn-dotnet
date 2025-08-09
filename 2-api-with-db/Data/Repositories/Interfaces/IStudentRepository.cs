using _2_api_with_db.Models;

namespace _2_api_with_db.Data.Repositories.Interfaces;

public interface IStudentRepository
{
    Student Add(Student student);
}