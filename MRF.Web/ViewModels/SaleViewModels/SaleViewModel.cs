using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using MRF.Models;

namespace MRF.Web.ViewModels.SaleViewModels
{
    public class SaleViewModel
    {
        public DateTime DateTime { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
    }
}
