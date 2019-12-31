using System;
using System.Collections.Generic;
using System.Linq;
using MRF.Models;
using MRF.Web.ViewModelBinder.Interfaces;
using MRF.Web.ViewModels.ProductionViewModels;

namespace MRF.Web.ViewModelBinder
{
    public class ProductionViewModelBinder:IProductionViewModelBinder
    {
        public ProductionViewModel ToViewModel(Production model)=>new ProductionViewModel
        {
            Name = model.Name,
            ProductName = model.Product.Name,
            ProductStatus = model.ProductionStatus,
            StartDate = model.StartDate,
            EndDate = model.EndDate
        };

        public List<ProductionViewModel> ToViewModel(List<Production> models) => models.Select(ToViewModel).ToList();
    }
}
