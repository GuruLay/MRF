using System;
using System.Collections.Generic;
using System.Text;
using MRF.Models.Base;

namespace MRF.Models
{
    public class Inventory:EntityBase
    {
        public Guid ProductId { get; set; } 
        public double Quantity { get; set; }
        public DateTime DateTime { get; set; }
        public Guid WarehouseId { get; set; }
        public Guid ClientId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
