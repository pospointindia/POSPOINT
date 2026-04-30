namespace POSPOINT.Data.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly DatabaseConnection _dbConnection;

    protected BaseRepository(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<int> AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<bool> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
