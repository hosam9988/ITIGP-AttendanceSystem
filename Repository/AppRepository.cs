using Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public class AppRepository<T> : IAppRepository<T> where T : class
    {
        protected readonly ITIAttendanceContext _context;
        private readonly DbSet<T> _dbSet;
        public AppRepository(ITIAttendanceContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? _dbSet.AsNoTracking() : _dbSet;

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? _dbSet.Where(expression).AsNoTracking() : _dbSet.Where(expression);

    }
}
