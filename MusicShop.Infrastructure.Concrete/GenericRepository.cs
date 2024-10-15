using Microsoft.EntityFrameworkCore;
using MusicShop.Data.Context.Context;
using MusicShop.Data.Entities;
using MusicShop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected readonly MusicShopContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(MusicShopContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public async Task<T> GetbyId(Guid id) //GetbyId
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity!=null)
            {
                return entity;
            } 
            
            return null;
        }
        public async Task Add(T entity)      // Add
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)        //Update
        {
            _dbSet.Update(entity);
            entity.UpdatedDate = DateTime.Now;
        }

        public void Remove(Guid id)         //Remove
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                entity.Status = 0;
                entity.DeletedDate = DateTime.Now;
            }
        }

        public void HardRemove(Guid id)     //HardRemvoe
        {
            var entity = _dbSet.Find(id);
            if(entity!=null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
           return await _dbSet.FirstAsync(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.Where(x=> x.Status == 1);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
           return _dbSet.Where(expression);
        }
    }
}
