using _2_api_with_db.Models;
using Microsoft.EntityFrameworkCore;

namespace _2_api_with_db.Data.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Student> Students { get; set; }

}