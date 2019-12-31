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
    public class ExpenseService:EntityServiceBase<Expense, Guid>,IExpenseService
    {
        public ExpenseService(IRepository dataAccess) : base(dataAccess)
        {
        }
        public override IQueryable<Expense> GetAll(bool includeDeleted = false)
        {
            return new List<Expense>
            {
                new Expense{ Amount = 5000, DateTime = DateTime.Today, ClientId = Guid.NewGuid(), ExpenseType = new ExpenseType{Name = "General" }},
                new Expense{ Amount = 150000, DateTime = DateTime.Today.AddDays(-1), ClientId = Guid.NewGuid(), ExpenseType = new ExpenseType{Name = "Labour" }},
                new Expense{ Amount = 60000, DateTime = DateTime.Today.AddDays(-2), ClientId = Guid.NewGuid(), ExpenseType = new ExpenseType{Name = "Investment" }},
                new Expense{ Amount = 250000, DateTime = DateTime.Today.AddDays(-3), ClientId = Guid.NewGuid(), ExpenseType = new ExpenseType{Name = "Maintenance" }},
                new Expense{ Amount = 1200, DateTime = DateTime.Today.AddDays(-4), ClientId = Guid.NewGuid(), ExpenseType = new ExpenseType{Name = "Marketing" }}
            }.AsQueryable();
        }
    }
}
