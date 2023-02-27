using Application.Interfaces;
using Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementations
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<T>().GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<T>().GetByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.GetRepository<T>().DeleteAsync(id);
            _unitOfWork.SaveChanges();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            T UpdatedEntity = await _unitOfWork.GetRepository<T>().UpdateAsync(entity);
            _unitOfWork.SaveChanges();
            return UpdatedEntity;

        }

        public async Task<T> CreateAsync(T entity)
        {
            T createdEntity = await _unitOfWork.GetRepository<T>().AddAsync(entity);
            _unitOfWork.SaveChanges();
            return createdEntity;
        }
    }
}
