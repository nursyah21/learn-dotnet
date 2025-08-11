using _3_api_with_auth.Shared;

namespace _3_api_with_auth.Student;

public record Student(string Name, string Email) : BaseModel { }
