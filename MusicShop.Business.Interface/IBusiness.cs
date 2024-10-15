using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Business.Interface
{
    public interface IBusiness<T> where T : class
    {
        
        Task<T> GetbyIdAsync(Guid id);

        Task<T> AddAsync(T entity);
       
        Task UpdateAsync(T entity);
     
        Task RemoveAsync(Guid id);
      
        Task HardRemoveAsync(Guid id);

        IQueryable<T> GetAllAsync();

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
    }
}
