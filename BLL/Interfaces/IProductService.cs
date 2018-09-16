using System.Collections.Generic;

namespace BLL.Interfaces
{
    interface IProductService<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindById();
        IEnumerable<T> FindByTypeId();
        IEnumerable<T> Random(int count);
    }
}
