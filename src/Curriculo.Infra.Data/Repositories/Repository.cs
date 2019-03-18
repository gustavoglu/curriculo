using Curriculo.Domain.Core.Models;
using Curriculo.Domain.Interfaces.Repositories;
using Curriculo.Domain.Pagination;
using Curriculo.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Curriculo.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected ContextSQLS Context { get { return _context; } }
        protected DbSet<T> DbSet { get { return _dbSet; } }

        private readonly ContextSQLS _context;
        private readonly DbSet<T> _dbSet;
        public Repository(ContextSQLS context)
        {
            this._context = context;
            _dbSet = _context.Set<T>();
        }
        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Delete(string id)
        {
            DbSet.Remove(GetById(id));
        }

    

        public virtual PaginationData GetAll(int? page, int? limit)
        {
            var total = DbSet.Count();
            var result = page.HasValue && limit.HasValue ? DbSet.Skip((page.Value - 1) * limit.Value).Take(limit.Value).ToList() :
                                                            DbSet.ToList();

            return new PaginationData(result, total, page ?? 1);
        }

        public virtual PaginationData GetAllActive(int? page, int? limit)
        {
            var total = DbSet.Where(e => !e.IsDeleted).Count();
            var result = page.HasValue && limit.HasValue ? DbSet.Where(e => !e.IsDeleted)
                                                                .Skip((page.Value - 1) * limit.Value).Take(limit.Value).ToList() :
                                                           DbSet.Where(e => !e.IsDeleted).ToList();

            return new PaginationData(result, total, page ?? 1);
        }

        public virtual T GetById(string id)
        {
            return DbSet.Find(id);
        }

        public virtual PaginationData Search(Expression<Func<T, bool>> predicate, int? page, int? limit)
        {
            var total = DbSet.Where(predicate).Count();
            var result = page.HasValue && limit.HasValue ? DbSet.Where(predicate)
                                                                .Skip((page.Value - 1) * limit.Value).Take(limit.Value).ToList() :
                                                           DbSet.Where(predicate).ToList();

            return new PaginationData(result, total, page ?? 1);
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
