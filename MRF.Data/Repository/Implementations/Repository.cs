using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MRF.Data.Repository.Interfaces;

namespace MRF.Data.Repository.Implementations
{
    public class Repository : IRepository
    {
        #region Constructors

        public Repository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        #endregion

        #region Properties

        private readonly ApplicationDbContext _dataContext;

        public ApplicationDbContext DataContext
        {
            get { return _dataContext; }
        }


        #endregion

        #region Implementation of IDataAccess

        public TEntity Create<TEntity>(TEntity entity, bool commit = true) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var token = DataContext.BeginTransaction();

            try
            {
                EntityEntry entry = DataContext.Entry(entity);
                entry.State = EntityState.Added;

                DataContext.EndTransaction(token);

                return entity;
            }
            catch
            {
                DataContext.DisposeTransaction(token, rollBack: true);
                throw;
            }
        }

        public void Create<TEntity>(IEnumerable<TEntity> entities, bool commit = true) where TEntity : class
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            var token = DataContext.BeginTransaction();

            try
            {
                var enumerableEntities = entities as IList<TEntity> ?? entities.ToList();

                foreach (var entity in enumerableEntities)
                {
                    Create(entity, false);
                }

                DataContext.EndTransaction(token);
            }
            catch
            {
                DataContext.DisposeTransaction(token, rollBack: true);
                throw;
            }
        }

        public TEntity Update<TEntity>(TEntity entity, bool commit = true) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var token = DataContext.BeginTransaction();

            try
            {
                EntityEntry entry = DataContext.Entry(entity);
                entry.State = EntityState.Modified;

                DataContext.EndTransaction(token);

                return entity;
            }
            catch
            {
                DataContext.DisposeTransaction(token, rollBack: true);
                throw;
            }
        }

        public void Update<TEntity>(IEnumerable<TEntity> entities, bool commit = true) where TEntity : class
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            var token = DataContext.BeginTransaction();

            try
            {
                foreach (var entity in entities.ToList())
                {
                    Update(entity, false);
                }
            }
            catch
            {
                DataContext.DisposeTransaction(token, rollBack: true);
                throw;
            }
        }

        public bool Delete<TEntity>(TEntity entity, bool commit = true) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var token = DataContext.BeginTransaction();

            try
            {
                EntityEntry entry = DataContext.Entry(entity);
                entry.State = EntityState.Deleted;

                return true;
            }
            catch
            {
                DataContext.DisposeTransaction(token, rollBack: true);
                throw;
            }
        }

        public bool Delete<TEntity>(IEnumerable<TEntity> entities, bool commit = true) where TEntity : class
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            var token = DataContext.BeginTransaction();

            try
            {
                foreach (var entity in entities)
                {
                    Delete(entity, false);
                }

                return true;
            }
            catch
            {
                DataContext.DisposeTransaction(token, rollBack: true);
                throw;
            }
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return DataContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return GetAll<TEntity>().Where(predicate);
        }

        public TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return GetAll<TEntity>().Where(predicate).FirstOrDefault();
        }

        #endregion
    }
}
