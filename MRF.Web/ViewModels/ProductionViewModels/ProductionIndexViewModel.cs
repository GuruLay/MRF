using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRF.Web.ViewModels.ProductionViewModels
{
    public class ProductionIndexViewModel
    {
        public List<ProductionViewModel> Productions { get; set; }

        public ProductionIndexViewModel(List<ProductionViewModel> productions)
        {
            Productions = productions;
        }
    }
}
