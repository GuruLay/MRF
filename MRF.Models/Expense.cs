using System;
using System.Collections.Generic;
using System.Text;
using MRF.Infrastructure.Enums;
using MRF.Models.Base;

namespace MRF.Models
{
    public class Expense:EntityBase
    {
        public double Amount { get; set; }
        public Guid ExpenseTypeId { get; set; }
        public DateTime DateTime { get; set; }
        public Guid ClientId { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }
    }
}
