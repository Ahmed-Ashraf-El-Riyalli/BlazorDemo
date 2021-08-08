using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthDemo2.Services
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetOneByID(object id);


        Task<T> GetOneWithOptions(Expression<Func<T, bool>> filter);


        Task<TOut> GetOneWithOptions<TOut>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, TOut>> selector = null)
            where TOut : class;


        Task<IEnumerable<T>> GetAll();


        Task<IEnumerable<T>> GetAllWithOptions(
            Expression<Func<T, bool>> filter);


        Task<IEnumerable<TOut>> GetAllWithOptions<TOut>(
            Expression<Func<T, TOut>> selector,
            Expression<Func<T, bool>> filter = null)
            where TOut : class;
    }
}
