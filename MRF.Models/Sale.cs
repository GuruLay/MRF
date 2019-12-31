using System;
using System.Collections.Generic;
using System.Text;
using MRF.Models.Base;

namespace MRF.Models
{
    public class Sale : EntityBase
    {
        public DateTime DateTime { get; set; }
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ClientId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
