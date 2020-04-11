using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MRF.Models.Base;

namespace MRF.Services.Domain.Base
{
    public interface IEntityServiceBase<TEntity, in TId> 
        where TEntity : class, IEntityBase<TId>
        where TId : struct, IEquatable<TId>
    {
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);

        bool Update(IEnumerable<TEntity> entities);

        bool Delete(TEntity entity);

        Task<List<TEntity>> GetAllAsync(bool includeDeleted = false);

        IQueryable<TEntity> GetAll(bool includeDeleted = false);

        IQueryable<TEntity> GetAll_EagerLoaded(params Expression<Func<TEntity, object>>[] includes);

        TEntity GetById(TId id, bool includeDeleted = false);

        TEntity GetById_EagerLoaded(TId id, params Expression<Func<TEntity, object>>[] includes);
        //IQueryable<TEntity> Filter(FilterBase filter, int? skip = null, int? take = null);
    }
}
