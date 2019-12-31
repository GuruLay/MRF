using System.Collections.Generic;
using MRF.Models;
using MRF.Web.ViewModelBinder.Interfaces;
using MRF.Web.ViewModels.SaleViewModels;

namespace MRF.Web.ViewModelBinder
{
    public class SaleIndexViewModelBinder:ISaleIndexViewModelBinder
    {
        private ISaleViewModelBinder _modelBinder;

        public SaleIndexViewModelBinder(ISaleViewModelBinder modelBinder)
        {
            _modelBinder = modelBinder;
        }
        public SaleIndexViewModel ToViewModel(List<Sale> models)
        {
            var lsSaleViewModels = _modelBinder.ToViewModel(models);
            var viewModel = new SaleIndexViewModel(lsSaleViewModels);
            return viewModel;
        }
    }
}
