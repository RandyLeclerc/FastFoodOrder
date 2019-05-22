using System.Collections.Generic;

namespace Shared.DataContracts
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create(T obj);
        T Update(T obj);
        void Delete(int id);



    }
}