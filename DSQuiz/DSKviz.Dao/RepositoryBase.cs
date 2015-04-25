using System.Data.Entity.Migrations;
using DSKviz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSKviz.Dao
{
    public abstract class RepositoryBase<TEntity> where TEntity : EntityBase
    {
        private DBContextManager DBContext = new DBContextManager();

        public RepositoryBase(DBContextManager dbCon)
        {
            DBContext = dbCon;
        }

        public IQueryable<TEntity> All
        {
            get
            {
                return DBContext.Set<TEntity>().AsQueryable();
            }
        }

        public TEntity FindInDB(int id)
        {
            var Entity = DBContext.Set<TEntity>().Find(id);
            return Entity;
        }

        public void AddToDB(TEntity entity)
        {
            DBContext.Set<TEntity>().Add(entity);
        }

        public void AddOrUpdateDB(TEntity entity)
        {
            DBContext.Set<TEntity>().AddOrUpdate(entity);
        }

        public void DeleteFromDB(int id)
        {
            var entity = FindInDB(id);
            DBContext.Set<TEntity>().Remove(entity);
        }

        public void UpdateInDB(TEntity entity)
        {
            var baseEntity = DBContext.Set<TEntity>().Find(entity.ID);
            DBContext.Entry(baseEntity).CurrentValues.SetValues(entity);
        }

        public void Save()
        {
            DBContext.SaveChanges();
        }
    }
}
