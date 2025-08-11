using _2_api_with_db.Shared;

namespace _2_api_with_db.Student;

public record Student(string Name, string Email) : BaseModel { }
