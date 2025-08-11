using _3_api_with_auth.Student;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();

builder.Services.AddDbContext<StudentDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IStudentRepository, StudenRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();


var app = builder.Build();

app.MapOpenApi("/openapi/v1.json");
app.MapHealthChecks("/health");
app.MapControllers();

app.Run();
