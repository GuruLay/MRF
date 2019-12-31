using System;
using System.Collections.Generic;
using System.Linq;
using MRF.Data.Repository.Interfaces;
using MRF.Models;
using MRF.Services.Domain.Base;
using MRF.Services.Domain.Interfaces;

namespace MRF.Services.Domain
{
    public class InventoryService:EntityServiceBase<Inventory, Guid>, IInventoryService
    {
        public InventoryService(IRepository dataAccess) : base(dataAccess)
        {
            
        }

        public override IQueryable<Inventory> GetAll(bool includeDeleted = false)
        {
            return new List<Inventory>
            {
                new Inventory{ ProductId = Guid.NewGuid(), Quantity = 5, DateTime = DateTime.Today, WarehouseId = Guid.NewGuid()},
                new Inventory{ ProductId = Guid.NewGuid(), Quantity = 5, DateTime = DateTime.Today.AddDays(-1), WarehouseId = Guid.NewGuid()},
                new Inventory{ ProductId = Guid.NewGuid(), Quantity = 5, DateTime = DateTime.Today.AddDays(-2), WarehouseId = Guid.NewGuid()},
                new Inventory{ ProductId = Guid.NewGuid(), Quantity = 5, DateTime = DateTime.Today.AddDays(-3), WarehouseId = Guid.NewGuid()},
                new Inventory{ ProductId = Guid.NewGuid(), Quantity = 5, DateTime = DateTime.Today.AddDays(-4), WarehouseId = Guid.NewGuid()},
            }.AsQueryable();
        }
    }
}
