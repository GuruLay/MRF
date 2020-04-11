using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MRF.Data.Repository.Interfaces;
using MRF.Models.Base;

namespace MRF.Services.Domain.Base
{
    public abstract class EntityServiceBase<TEntity, TId> : ServiceBase, IEntityServiceBase<TEntity, TId>
         where TEntity : class, IEntityBase<TId>
         where TId : struct, IEquatable<TId>
    {
        protected EntityServiceBase(IRepository dataAccess)
            : base(dataAccess)
        {
        }

        public long? LoggedInUserId
        {
            get
            {
                return null; //Factory.GetInstance<ILoggedInUserProvider<long>>().LoggedInUserId;
            }
        }

        public virtual TEntity Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            //Validator.ValidateCreate(entity);

            entity.UserCreatedId = LoggedInUserId;
            entity.DateCreated = DateTime.UtcNow;
            entity.IsDeleted = false;

            var token = BeginTransaction();

            try
            {
                entity = DataAccess.Create(entity);

                EndTransaction(token);

                return entity;
            }
            //catch (DbEntityValidationException ex)
            //{
            //    DisposeTransaction(token);
            //    throw new ServiceValidationException(ex);
            //}
            catch
            {
                DisposeTransaction(token);
                throw;
            }
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            //Validator.ValidateUpdate(entity);

            var dbEntry =
                DataAccess.DataContext.ChangeTracker.Entries<TEntity>()
                    .FirstOrDefault(p => p.Entity.Id.Equals(entity.Id));

            if (dbEntry != null && dbEntry.State == EntityState.Modified)
            {
                entity.UserUpdatedId = LoggedInUserId;
                entity.DateUpdated = DateTime.UtcNow;
            }

            var token = BeginTransaction();

            try
            {
                entity = DataAccess.Update(entity);

                EndTransaction(token);

                return entity;
            }
            //catch (DbEntityValidationException ex)
            //{
            //    DisposeTransaction(token);
            //    throw new ServiceValidationException(ex);
            //}
            catch
            {
                DisposeTransaction(token);
                throw;
            }
        }

        public virtual bool Update(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
            {
                throw new ArgumentNullException("entity");
            }

            foreach (var entity in entities)
            {
                //Validator.ValidateUpdate(entity);

                var dbEntry =
                    DataAccess.DataContext.ChangeTracker.Entries<TEntity>()
                        .FirstOrDefault(p => p.Entity.Id.Equals(entity.Id));

                if (dbEntry != null && dbEntry.State == EntityState.Modified)
                {
                    entity.UserUpdatedId = LoggedInUserId;
                    entity.DateUpdated = DateTime.UtcNow;
                }
            }

            var token = BeginTransaction();

            try
            {
                DataAccess.Update(entities);

                EndTransaction(token);

                return true;
            }
            //catch (DbEntityValidationException ex)
            //{
            //    DisposeTransaction(token);
            //    throw new ServiceValidationException(ex);
            //}
            catch
            {
                DisposeTransaction(token);
                throw;
            }

            return false;
        }

        public virtual bool Delete(TEntity entity)
        {
            entity.UserDeletedId = LoggedInUserId;
            entity.DateDeleted = DateTime.UtcNow;
            entity.IsDeleted = true;

            var token = BeginTransaction();

            try
            {
                var deleted = (DataAccess.Update(entity) != null);

                EndTransaction(token);

                return deleted;
            }
            //catch (DbEntityValidationException ex)
            //{
            //    DisposeTransaction(token);
            //    throw new ServiceValidationException(ex);
            //}
            catch
            {
                DisposeTransaction(token);
                throw;
            }
        }

        public virtual async Task<List<TEntity>> GetAllAsync(bool includeDeleted = false) 
            => await GetAll(includeDeleted).ToListAsync();
        
        public virtual IQueryable<TEntity> GetAll(bool includeDeleted = false)
        {
            return includeDeleted
                ? DataAccess.GetAll<TEntity>()
                : DataAccess.Get<TEntity>(p => p.IsDeleted == false);
        }

        public IQueryable<TEntity> GetAll_EagerLoaded(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetAll();

            return includes.Aggregate(query, (queryInstance, include) => queryInstance.Include(include));
        }

        public virtual TEntity GetById(TId id, bool includeDeleted = false)
        {
            return GetAll(includeDeleted).FirstOrDefault(p => p.Id.Equals(id));
        }

        public TEntity GetById_EagerLoaded(TId id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetAll();

            return
                includes.Aggregate(query, (queryInstance, include) => queryInstance.Include(include))
                    .FirstOrDefault(p => p.Id.Equals(id));
        }

        //public virtual IQueryable<TEntity> Filter(FilterBase filter, int? skip = null, int? take = null)
        //{
        //    var query = GetAll();


        //    if (skip != null && take != null)
        //    {
        //        query = query.OrderBy(x => x.Id).Skip((int)skip).Take((int)take);
        //    }

        //    return query;
        //}
    }
}
