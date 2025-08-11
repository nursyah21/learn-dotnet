namespace _2_api_with_db.Shared;

public interface IRepository<T> where T : BaseModel
{
    List<T> GetAll();
    T? GetById(int id);
    T Add(T entity);
    T? UpdateById(int id, T entity);
    bool RemoveById(int id);
}