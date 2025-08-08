using _2_api_with_db.Services.Implementations;
using _2_api_with_db.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

app.MapControllers();


app.Run("http://localhost:5001");
