using MusicShop.Business.Interface;
using MusicShop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Business.Concrete
{
    public class Business<T> : IBusiness<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;

        public Business(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<T> GetbyIdAsync(Guid id)
        {
            return await _repository.GetbyId(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            _repository.Remove(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task HardRemoveAsync(Guid id)
        {
            _repository.HardRemove(id);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> GetAllAsync()
        {
            return _repository.GetAll();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FirstOrDefault(predicate);
        }
    }
}
