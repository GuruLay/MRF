using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRF.Models;
using MRF.Web.ViewModelBinder.Interfaces;
using MRF.Web.ViewModels.SaleViewModels;

namespace MRF.Web.ViewModelBinder
{
    public class SaleViewModelBinder:ISaleViewModelBinder
    {
        public SaleViewModel ToViewModel(Sale model) => new SaleViewModel
        {
            DateTime = model.DateTime,
            Quantity = model.Quantity,
            Price = model.Price,
            ProductName = model.Product.Name,
            CustomerName = model.Customer.Name
        };

        public List<SaleViewModel> ToViewModel(List<Sale> models) => models.Select(ToViewModel).ToList();
    }
}
