using System;
using MRF.Models;
using MRF.Services.Domain.Base;

namespace MRF.Services.Domain.Interfaces
{
    public interface IInventoryService:IEntityServiceBase<Inventory, Guid>
    {
    }
}
