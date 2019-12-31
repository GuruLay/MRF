using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MRF.Data.Repository.Interfaces;
using MRF.Models;
using MRF.Services.Domain.Base;
using MRF.Services.Domain.Interfaces;

namespace MRF.Services.Domain
{
    public class SaleService:EntityServiceBase<Sale, Guid>, ISaleService
    {
        public SaleService(IRepository dataAccess) : base(dataAccess)
        {
        }

        public override IQueryable<Sale> GetAll(bool includeDeleted = false)
        {
            return new List<Sale>
            {
                new Sale{ Quantity = 5, Price = 12.00d, DateTime = DateTime.Today, Product = new Product{Name = "Rice"}, Customer = new Customer{Name = "Customer One"}},
                new Sale{ Quantity = 24, Price = 11.70d, DateTime = DateTime.Today.AddDays(-1), Product = new Product{Name = "Rice"}, Customer = new Customer{Name = "Customer Two"}},
                new Sale{ Quantity = 152, Price = 10.20d, DateTime = DateTime.Today.AddDays(-2), Product = new Product{Name = "Rice"}, Customer = new Customer{Name = "Customer Three"}},
                new Sale{ Quantity = 86, Price = 11.40d, DateTime = DateTime.Today.AddDays(-3), Product = new Product{Name = "Rice"}, Customer = new Customer{Name = "Customer Four"}},
                new Sale{ Quantity = 241, Price = 10.00d, DateTime = DateTime.Today.AddDays(-4), Product = new Product{Name = "Rice"}, Customer = new Customer{Name = "Customer Five"}},
            }.AsQueryable();
        }
    }
}
