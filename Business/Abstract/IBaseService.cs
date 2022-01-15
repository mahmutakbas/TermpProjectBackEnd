using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IBaseService<T>
    {
        IDataResult<T> GetById(int id);
        IDataResult<List<T>> GetAll();
        IDataResult<int> Add(T item);
        IResult Update(T item);
        IResult Delete(T item);
    }
}
