using _2_api_with_db.Data.Context;
using _2_api_with_db.Services.Implementations;
using _2_api_with_db.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Service Registration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresqlConnection")));
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();

// https://localhost:5001/openapi/v1.json
app.MapOpenApi();
app.MapHealthChecks("/api/health");

app.MapControllers();


app.Run("https://localhost:5001");
