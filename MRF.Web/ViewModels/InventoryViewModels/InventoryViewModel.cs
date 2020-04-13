using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MRF.Web.ViewModels.InventoryViewModels
{
    public class InventoryViewModel
    {
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public DateTime DateTime { get; set; }
        public string Warehouse { get; set; }
    }
}
