using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MRF.Data.Repository.Interfaces
{
    public interface IRepository
    {
        ApplicationDbContext DataContext { get; }

        TEntity Create<TEntity>(TEntity entity, bool commit = true) where TEntity : class;
        void Create<TEntity>(IEnumerable<TEntity> entities, bool commit = true) where TEntity : class;

        TEntity Update<TEntity>(TEntity entity, bool commit = true) where TEntity : class;
        void Update<TEntity>(IEnumerable<TEntity> entities, bool commit = true) where TEntity : class;

        bool Delete<TEntity>(TEntity entity, bool commit = true) where TEntity : class;
        bool Delete<TEntity>(IEnumerable<TEntity> entities, bool commit = true) where TEntity : class;

        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;

        IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
    }
}
