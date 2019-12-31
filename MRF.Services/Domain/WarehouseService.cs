using System;
using System.Linq;
using MRF.Data.Repository.Interfaces;
using MRF.Models;
using MRF.Services.Domain.Base;
using MRF.Services.Domain.Interfaces;

namespace MRF.Services.Domain
{
    public class WarehouseService: EntityServiceBase<Warehouse, Guid>, IWarehouseService
    {
        public WarehouseService(IRepository dataAccess) : base(dataAccess)
        {
        }

        public override IQueryable<Warehouse> GetAll(bool includeDeleted = false)
        {
            return base.GetAll(includeDeleted);
        }
    }
}
