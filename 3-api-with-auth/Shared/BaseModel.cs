namespace _3_api_with_auth.Shared;

public abstract record BaseModel
{
    public int Id { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset UpdatedAt { get; init; }

    // this property enables "soft delete"
    // for auditing or recovery
    public bool IsDeleted { get; init; } = false;
}