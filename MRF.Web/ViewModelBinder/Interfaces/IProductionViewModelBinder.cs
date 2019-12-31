using System.Collections.Generic;
using MRF.Models;
using MRF.Web.ViewModels.ProductionViewModels;

namespace MRF.Web.ViewModelBinder.Interfaces
{
    public interface IProductionViewModelBinder
    {
        List<ProductionViewModel> ToViewModel(List<Production> models);
    }
}
