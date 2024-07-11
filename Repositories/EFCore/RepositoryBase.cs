
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> 
        where T : class
    {
        protected readonly RepositoryContext _Context;

        public RepositoryBase(RepositoryContext context)
        {
            _Context = context;
        }

        public void Create(T entity) => _Context.Set<T>().Add(entity);


        public void Delete(T entity) => _Context.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? _Context.Set<T>().AsNoTracking() : _Context.Set<T>();


        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
            bool trackChanges)=>
            !trackChanges ? _Context.Set<T>().Where(expression).AsNoTracking() : _Context.Set<T>().Where(expression);


        public void Update(T entity) => _Context.Set<T>().Update(entity);

    }
}
