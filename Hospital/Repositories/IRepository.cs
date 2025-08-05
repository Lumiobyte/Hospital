using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {

        public TEntity? GetById(int id);

        public IEnumerable<TEntity> GetAll();

        public void Add(TEntity entity);

        public void Remove(TEntity entity);

        public void SaveChanges();

    }
}
