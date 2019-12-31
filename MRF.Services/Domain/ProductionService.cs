using System;
using System.Collections.Generic;
using System.Linq;
using MRF.Data.Repository.Interfaces;
using MRF.Infrastructure.Enums;
using MRF.Models;
using MRF.Services.Domain.Base;
using MRF.Services.Domain.Interfaces;

namespace MRF.Services.Domain
{
    public class ProductionService : EntityServiceBase<Production, Guid>, IProductionService
    {
        public ProductionService(IRepository dataAccess) : base(dataAccess)
        {
        }

        public override IQueryable<Production> GetAll(bool includeDeleted = false)
        {
            return new List<Production>
            {
                new Production{ Name = "2020 Q1 Rice", StartDate = DateTime.Today.AddDays(60), EndDate = DateTime.Today.AddDays(150), ProductionStatus = ProductionStatus.NotStarted, Product = new Product{Name = "Rice"}},
                new Production{ Name = "2019 Q4 Rice", StartDate = DateTime.Today.AddDays(-90), EndDate = DateTime.Today, ProductionStatus = ProductionStatus.Start, Product = new Product{Name = "Rice"}},
                new Production{ Name = "2019 Q3 Rice", StartDate = DateTime.Today.AddDays(-180), EndDate = DateTime.Today.AddDays(-90), ProductionStatus = ProductionStatus.Finish, Product = new Product{Name = "Rice"}},
                new Production{ Name = "2019 Q2 Rice", StartDate = DateTime.Today.AddDays(-270), EndDate = DateTime.Today.AddDays(-180), ProductionStatus = ProductionStatus.Finish, Product = new Product{Name = "Rice"}},
                new Production{ Name = "2019 Q1 Rice", StartDate = DateTime.Today.AddDays(-360), EndDate = DateTime.Today.AddDays(-270), ProductionStatus = ProductionStatus.Finish, Product = new Product{Name = "Rice"}},
            }.AsQueryable();
        }
    }
}
