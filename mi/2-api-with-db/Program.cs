using _2_api_with_db.Student;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

app.MapOpenApi("/openapi/v1.json");
app.MapHealthChecks("/health");
app.MapControllers();

app.Run();
