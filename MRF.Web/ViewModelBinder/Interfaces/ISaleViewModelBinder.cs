using System.Collections.Generic;
using MRF.Models;
using MRF.Web.ViewModels.SaleViewModels;

namespace MRF.Web.ViewModelBinder.Interfaces
{
    public interface ISaleViewModelBinder
    {
        List<SaleViewModel> ToViewModel(List<Sale> models);
    }
}
