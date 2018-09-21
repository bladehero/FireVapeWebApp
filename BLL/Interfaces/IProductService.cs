using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IProductService<T>
    {
        long Add(T item);
        IEnumerable<T> FindAll();
        T FindById(int? id);
        IEnumerable<T> FindByTypeId(int? id);
        bool Remove(T item);
        bool RemoveById(int? id);
        bool Update(T item);
    }
}
