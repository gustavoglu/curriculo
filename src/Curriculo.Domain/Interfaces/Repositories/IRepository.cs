using Curriculo.Domain.Core.Models;
using Curriculo.Domain.Pagination;
using System;
using System.Linq.Expressions;

namespace Curriculo.Domain.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(string id);
        T GetById(string id);
        PaginationData GetAll(int? page,int? limit);
        PaginationData GetAllActive(int? page, int? limit);
        PaginationData Search(Expression<Func<T, bool>> predicate, int? page, int? limit);
    }
}
