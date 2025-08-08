using _2_api_with_db.Services.Implementations;
using _2_api_with_db.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

// https://localhost:5001/openapi/v1.json
app.MapOpenApi();
app.MapControllers();

app.UseHttpsRedirection();

app.Run("https://localhost:5001");
