using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly HospitalDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(HospitalDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
