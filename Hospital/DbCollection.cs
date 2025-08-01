using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class DbCollection<T> where T : class
    {

        private readonly string _collectionName;
        private readonly LiteDatabase _db;

        public DbCollection(string dbPath = "DotNetHospital.db")
        {
            _db = new LiteDatabase(dbPath);
            _collectionName = typeof(T).Name.ToLower() + "s";
        }

        public IEnumerable<T> GetAll()
        {
            return _db.GetCollection<T>(_collectionName).FindAll();
        }

        public T GetById(BsonValue id)
        {
            return _db.GetCollection<T>(_collectionName).FindById(id);
        }

        public bool Insert(T item)
        {
            return _db.GetCollection<T>(_collectionName).Insert(item) != null;
        }

        public bool Update(T item)
        {
            return _db.GetCollection<T>(_collectionName).Update(item);
        }

        public bool Delete(BsonValue id)
        {
            return _db.GetCollection<T>(_collectionName).Delete(id);
        }
    }
}
