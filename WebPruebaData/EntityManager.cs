using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebPruebaData
{
    public interface IDataManager<T>
    {
        T CrearEntity(T entity);
    }
    public abstract class EntityManager<T> : IDataManager<T>
         where T : class
    {
        private static string _connectionString = WebPruebaBDEntities.ConnectionStringName;

        protected virtual string ConnectionStringName
        {
            get
            {
                return _connectionString;
            }
            set { _connectionString = value; }
        }

        public List<T> ObtenerTodos()
        {
            using (var db = new DbContext(ConnectionStringName))
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                return db.Set<T>().ToList();

            }
        }


        public T SeleccionarById(object id)
        {
            using (var db = new DbContext(ConnectionStringName))
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                return db.Set<T>().Find(id);
            }
        }

        public virtual T CrearEntity(T entity)
        {
            using (var db = new DbContext(ConnectionStringName))
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Set<T>().Add(entity);
                db.SaveChanges();
                return entity;
            }
        }

        public bool ActualizarEntity(T entity)
        {
            using (var db = new DbContext(ConnectionStringName))
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges() == 1;
            }
        }
        public bool EliminarById(object id)
        {
            using (var db = new DbContext(ConnectionStringName))
            {
                db.Configuration.ProxyCreationEnabled = false;

                var entity = db.Set<T>().Find(id);
                db.Entry(entity).State = EntityState.Deleted;
                return db.SaveChanges() == 1;
            }
        }

    }
}