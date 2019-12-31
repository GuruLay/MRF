using System;
using System.Collections.Generic;
using System.Text;
using MRF.Infrastructure.Enums;
using MRF.Models.Base;

namespace MRF.Models
{
    public class Production:EntityBase
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ProductId { get; set; }
        public ProductionStatus ProductionStatus { get; set; }
        public Guid ClientId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
