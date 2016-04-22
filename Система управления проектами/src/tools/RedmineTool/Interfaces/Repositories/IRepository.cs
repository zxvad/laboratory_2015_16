using System.Collections.Generic;

namespace RedmineTool.Interfaces.Repositories
{
    public interface IRepository<in T>
    {
        void Save(IEnumerable<T> entities);
    }
}