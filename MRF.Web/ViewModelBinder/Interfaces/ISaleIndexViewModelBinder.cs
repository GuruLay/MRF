using System.Collections.Generic;
using MRF.Models;
using MRF.Web.ViewModels.SaleViewModels;

namespace MRF.Web.ViewModelBinder.Interfaces
{
    public interface ISaleIndexViewModelBinder
    {
        SaleIndexViewModel ToViewModel(List<Sale> models);
    }
}
