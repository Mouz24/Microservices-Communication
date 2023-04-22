using Order.Contracts;
using Order.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Order.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected OrderContext _orderContext;

        public BaseRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ?
          _orderContext.Set<T>()
           .AsNoTracking() :
          _orderContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges ?
        _orderContext.Set<T>()
        .Where(expression)
        .AsNoTracking() :
        _orderContext.Set<T>()
        .Where(expression);

        public void Create(T entity) => _orderContext.Set<T>().Add(entity);
        public void Update(T entity) => _orderContext.Set<T>().Update(entity);
        public void Delete(T entity) => _orderContext.Set<T>().Remove(entity);
    }
}