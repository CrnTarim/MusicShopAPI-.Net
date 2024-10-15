using MusicShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Interface
{
    public interface IGenericRepository<T> where T : class
    {     
        Task<T> GetbyId(Guid id);

        Task Add(T entity);

        void Update(T entity);
       
        void Remove(Guid id);
        
        void HardRemove(Guid id);
    
        IQueryable<T> GetAll();
   
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

    }
}
