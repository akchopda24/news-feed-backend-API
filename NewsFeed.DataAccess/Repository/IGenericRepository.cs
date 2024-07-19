using NewsFeed.DataAccess.CommanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.DataAccess.Repository
{
    public interface IGenericRepository<T>
    {
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(int id);
        Task Delete(T entity);
        Task<PagedResult<T>> GetSearchData(Expression<Func<T, bool>> expression, int pageNo = 1, int pageSize = 10);
    }
}
