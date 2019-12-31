using System;
using System.Collections.Generic;
using MRF.Models;
using MRF.Web.ViewModelBinder.Interfaces;
using MRF.Web.ViewModels.ProductionViewModels;

namespace MRF.Web.ViewModelBinder
{
    public class ProductionIndexViewModelBinder:IProductionIndexViewModelBinder
    {
        private IProductionViewModelBinder _modelBinder;

        public ProductionIndexViewModelBinder(IProductionViewModelBinder modelBinder)
        {
            _modelBinder = modelBinder;
        }
        public ProductionIndexViewModel ToViewModel(List<Production> models)
        {
            var productionViewModels = _modelBinder.ToViewModel(models);
            var viewModel = new ProductionIndexViewModel(productionViewModels);
            return viewModel;
        }
    }
}
