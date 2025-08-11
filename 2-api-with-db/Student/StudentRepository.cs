using _2_api_with_db.Shared;
using Microsoft.EntityFrameworkCore;

namespace _2_api_with_db.Student;

public class StudenRepository : BaseRepository<Student>, IStudentRepository
{
    public StudenRepository(StudentDbContext context) : base(context){}
}