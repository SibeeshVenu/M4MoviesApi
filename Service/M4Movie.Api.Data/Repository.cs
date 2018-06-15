using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using M4Movie.Api.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace M4Movie.Api.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(T entity) => Context.Set<T>().Add(entity);

        public void AddRange(IEnumerable<T> entities) => Context.Set<T>().AddRange(entities);

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => Context.Set<T>().Where(predicate);

        public T Get(long id) => Context.Set<T>().Find(id);

        public IEnumerable<T> GetAll() => Context.Set<T>().ToList();

        public void Remove(T entity) => Context.Set<T>().Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => Context.Set<T>().RemoveRange(entities);

        public T SingleOrDefault(Expression<Func<T, bool>> predicate) => Context.Set<T>().SingleOrDefault(predicate);
    }
}
