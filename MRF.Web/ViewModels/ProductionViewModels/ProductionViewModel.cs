using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRF.Infrastructure.Enums;

namespace MRF.Web.ViewModels.ProductionViewModels
{
    public class ProductionViewModel
    {
        public string Name { get; set; }
        public string ProductName { get; set; }
        public ProductionStatus ProductStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
