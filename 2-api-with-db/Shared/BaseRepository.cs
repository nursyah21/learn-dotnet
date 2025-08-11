
using Microsoft.EntityFrameworkCore;

namespace _2_api_with_db.Shared;

public class BaseRepository<T> : IRepository<T> where T : BaseModel
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    public T Add(T entity)
    {
        entity = entity with { CreatedAt = DateTimeOffset.UtcNow };
        _dbSet.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public List<T> GetAll()
    {
        return _dbSet.Where(e => !e.IsDeleted).ToList();
    }

    public T? GetById(int id)
    {
        return _dbSet.Where(e => !e.IsDeleted).FirstOrDefault(e => e.Id == id);
    }

    bool IRepository<T>.RemoveById(int id)
    {
        var existing = GetById(id);
        if (existing == null)
        {
            return false;
        }

        var entityType = typeof(T);

        var isDeletedProp = entityType.GetProperty(nameof(BaseModel.IsDeleted));
        isDeletedProp?.SetValue(existing, true);

        var updatedAtProp = entityType.GetProperty(nameof(BaseModel.UpdatedAt));
        updatedAtProp?.SetValue(existing, DateTimeOffset.UtcNow);

        _context.SaveChanges();
        return true;
    }

    T? IRepository<T>.UpdateById(int id, T entity)
    {
        var existing = GetById(id);
        if (existing == null)
        {
            return null;
        }

        var entityType = typeof(T);
        foreach (var prop in entityType.GetProperties())
        {
            if (prop.Name == nameof(BaseModel.Id) || prop.Name == nameof(BaseModel.CreatedAt))
                continue;

            var newValue = prop.GetValue(entity);
            prop.SetValue(existing, newValue);
        }

        var updatedAtProp = entityType.GetProperty(nameof(BaseModel.UpdatedAt));
        updatedAtProp?.SetValue(existing, DateTimeOffset.UtcNow);

        _context.SaveChanges();
        return existing;
    }
}