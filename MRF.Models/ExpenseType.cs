using System;
using System.Collections.Generic;
using System.Text;
using MRF.Models.Base;

namespace MRF.Models
{
    public class ExpenseType:EntityBase
    {
        public string Name { get; set; }
        public Guid ClientId { get; set; }
    }
}
