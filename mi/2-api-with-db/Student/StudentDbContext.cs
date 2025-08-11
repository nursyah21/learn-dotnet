using Microsoft.EntityFrameworkCore;

namespace _2_api_with_db.Student;

public class StudentDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) {}
}