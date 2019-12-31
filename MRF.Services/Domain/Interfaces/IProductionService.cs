using System;
using System.Collections.Generic;
using System.Text;
using MRF.Models;
using MRF.Services.Domain.Base;

namespace MRF.Services.Domain.Interfaces
{
    public interface IProductionService : IEntityServiceBase<Production, Guid>
    {
    }
}
