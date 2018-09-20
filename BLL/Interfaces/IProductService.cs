using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IProductService<T>
    {
        IEnumerable<T> FindAll();
        T FindById(int? id);
        IEnumerable<T> FindByTypeId(int? id);
    }
}
