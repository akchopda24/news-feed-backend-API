using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using NewsFeed.DataAccess.CommanModel;
using NewsFeed.DataAccess.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NewsFeed.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly NewsFeedDbContext _dbContext;

        public GenericRepository(NewsFeedDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task Create(T entity)
        {
            _ = _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public async Task<PagedResult<T>> GetSearchData(Expression<Func<T, bool>> expression, int pageNo = 1, int pageSize = 10)
        {
            var query = _dbContext.Set<T>().Where(expression).AsQueryable();

            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<T>
            {
                Items = items,
                TotalCount = totalItems,
                PageNumber = pageNo,
                PageSize = pageSize
            };
        }

    }
}
