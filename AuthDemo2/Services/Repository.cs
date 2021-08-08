using AuthDemo2.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthDemo2.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _table;
        private readonly ApplicationDbContext _db;


        public Repository(ApplicationDbContext db)
        {
            _table = db.Set<T>();
            _db = db;
        }


        public async Task<T> GetOneByID(object id)
        {
            T entity = await _table.FindAsync(id);

            _db.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<T> GetOneWithOptions(Expression<Func<T, bool>> filter)
        {
            return await _table.AsNoTracking()
                               .Where(filter)
                               .FirstOrDefaultAsync();
        }

        public async Task<TOut> GetOneWithOptions<TOut>( 
            Expression<Func<T, bool>> filter,
            Expression<Func<T, TOut>> selector)
            where TOut : class
        {
            return await _table.AsNoTracking()
                            .Where(filter)
                            .Select(selector)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.AsNoTracking()
                               .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithOptions(
            Expression<Func<T, bool>> filter)
        {
            return await _table.AsNoTracking()
                               .Where(filter)
                               .ToListAsync();
        }

        public async Task<IEnumerable<TOut>> GetAllWithOptions<TOut>(
            Expression<Func<T, TOut>> selector,
            Expression<Func<T, bool>> filter = null)
            where TOut : class
        {
            if(filter == null)
            {
                return await _table.AsNoTracking()
                                   .Select(selector)
                                   .ToListAsync();
            }

            return await _table.AsNoTracking()
                               .Where(filter)
                               .Select(selector)
                               .ToListAsync();
        }
    }
}
