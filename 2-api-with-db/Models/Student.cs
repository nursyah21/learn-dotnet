namespace _2_api_with_db.Models;

public record Student(int Id, string Name, string Email) { }
public record CreateStudent(string Name, string Email) { }

