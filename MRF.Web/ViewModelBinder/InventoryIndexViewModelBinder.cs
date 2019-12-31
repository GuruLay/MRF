using System.Collections.Generic;
using MRF.Models;
using MRF.Web.ViewModelBinder.Interfaces;
using MRF.Web.ViewModels;

namespace MRF.Web.ViewModelBinder
{
    public class InventoryIndexViewModelBinder:IInventoryIndexViewModelBinder
    {
        private readonly IInventoryViewModelBinder _inventoryViewModelBinder;
        public InventoryIndexViewModelBinder(IInventoryViewModelBinder inventoryViewModelBinder)
        {
            _inventoryViewModelBinder = inventoryViewModelBinder;
        }


        public InventoryIndexViewModel ToViewModel(List<Inventory> models)
        {
            var lsInventoryViewModels = _inventoryViewModelBinder.ToViewModel(models);
            var viewModel = new InventoryIndexViewModel(lsInventoryViewModels);
            return viewModel;
        }
    }
}
