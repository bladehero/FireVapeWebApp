using AutoMapper;
using System.Collections.Generic;

namespace BLL.Extensions
{
    static class MapperExtensions
    {
        public static IEnumerable<D> MapCollection<T,D>(this IMapper mapper, IEnumerable<T> collection)
        {
            List<D> mapCollection = new List<D>();
            foreach (var item in collection)
            {
                mapCollection.Add(mapper.Map<D>(item));
            }
            return mapCollection;
        }
    }
}
