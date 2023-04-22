using Microsoft.EntityFrameworkCore;
using Product.Contracts;
using Product.Entities;
using System.Linq.Expressions;

namespace Product.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ProductContext _productContext;

        public BaseRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ?
          _productContext.Set<T>()
           .AsNoTracking() :
          _productContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,bool trackChanges) =>
        !trackChanges ?
        _productContext.Set<T>()
        .Where(expression)
        .AsNoTracking() :
        _productContext.Set<T>()
        .Where(expression);

        public void Create(T entity) => _productContext.Set<T>().Add(entity);
        public void Update(T entity) => _productContext.Set<T>().Update(entity);
        public void Delete(T entity) => _productContext.Set<T>().Remove(entity);
    }
}