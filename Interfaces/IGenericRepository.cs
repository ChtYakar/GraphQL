using GraphQL_Nsn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Interfaces
{
    interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        T Insert(T entity);

        T Update(T entity);

        void Delete(int id);
    }
}
