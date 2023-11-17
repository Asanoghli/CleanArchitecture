using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class,new()
    {
        Task<T> GetById(int id);
        Task<T> GetAll();
        void Delete(int id);
        void Update(T entity);
        Task<int> Create(T entity);
    }
}
