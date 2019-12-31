using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRF.Web.ViewModels.SaleViewModels
{
    public class SaleIndexViewModel
    {
        public List<SaleViewModel> SaleRecords { get; set; }

        public SaleIndexViewModel(List<SaleViewModel> saleRecords)
        {
            SaleRecords = saleRecords;
        }
    }
}
