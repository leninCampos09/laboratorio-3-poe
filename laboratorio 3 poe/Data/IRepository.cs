namespace laboratorio_3_poe.Data;

public interface IRepository<T> where T : class
{
    IReadOnlyList<T> GetAll();
    T? Find(object criteria);
    object Insert(T entity);
    int Update(T entity);
}
