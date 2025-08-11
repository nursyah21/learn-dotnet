using _3_api_with_auth.Shared;
using Microsoft.EntityFrameworkCore;

namespace _3_api_with_auth.Student;

public class StudenRepository : BaseRepository<Student>, IStudentRepository
{
    public StudenRepository(StudentDbContext context) : base(context){}
}