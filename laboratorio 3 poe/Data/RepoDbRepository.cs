using RepoDb;

namespace laboratorio_3_poe.Data;

public sealed class RepoDbRepository<T> : IRepository<T> where T : class
{
    public IReadOnlyList<T> GetAll()
    {
        using var connection = Database.OpenConnection();
        return connection.QueryAll<T>().ToList();
    }

    public T? Find(object criteria)
    {
        using var connection = Database.OpenConnection();
        return connection.Query<T>(criteria).FirstOrDefault();
    }

    public object Insert(T entity)
    {
        using var connection = Database.OpenConnection();
        return connection.Insert(entity);
    }

    public int Update(T entity)
    {
        using var connection = Database.OpenConnection();
        return connection.Update(entity);
    }
}
