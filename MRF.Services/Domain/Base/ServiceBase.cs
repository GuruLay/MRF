using System;
using System.Linq;
using System.Linq.Expressions;
using MRF.Data.Repository.Interfaces;

namespace MRF.Services.Domain.Base
{
    public abstract class ServiceBase : IServiceBase
    {
        protected ServiceBase(IRepository dataAccess)
        {
            DataAccess = dataAccess;
        }
        protected IRepository DataAccess { get; set; }
        public IQueryable<TObject> Sort<TObject, TMember>(IQueryable<TObject> items, bool orderAscending, Expression<Func<TObject, TMember>> sort) where TObject : class
        {
            return orderAscending ? items.OrderBy(sort) : items.OrderByDescending(sort);
        }
        public IQueryable<TObject> Paginate<TObject>(IQueryable<TObject> collection, int startRow, int pageSize, out int totalRows) where TObject : class
        {
            // This creates a duplicate query to run as the count so the data set is not loaded into memory
            var countQuery = collection.AsQueryable();
            totalRows = countQuery.Count();

            return collection.Skip(startRow).Take(pageSize);
        }

        protected Guid? BeginTransaction()
        {
            return DataAccess.DataContext.BeginTransaction();
        }

        protected void EndTransaction(Guid? token)
        {
            DataAccess.DataContext.EndTransaction(token);
        }

        protected void DisposeTransaction(Guid? token)
        {
            DataAccess.DataContext.DisposeTransaction(token, true);
        }

        protected bool HasTransactionStarted()
        {
            return DataAccess.DataContext.HasTransactionStarted();
        }
    }
}
