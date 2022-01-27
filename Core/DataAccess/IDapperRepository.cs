using Core.Entities.Abstract;

namespace Core.DataAccess
{
    public interface IDapperRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll();
        T Get(int id);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
