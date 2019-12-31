using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MRF.Services.Domain.Base
{
    public interface IServiceBase
    {
        IQueryable<TObject> Sort<TObject, TMember>(IQueryable<TObject> items, bool orderAscending, Expression<Func<TObject, TMember>> sort) where TObject : class;

        IQueryable<TObject> Paginate<TObject>(IQueryable<TObject> collection, int startRow, int pageSize, out int totalRows) where TObject : class;
    }
}
