using System.Collections.Generic;
using System.Linq;
using MRF.Models;
using MRF.Web.ViewModelBinder.Interfaces;
using MRF.Web.ViewModels.InventoryViewModels;

namespace MRF.Web.ViewModelBinder
{
    public class InventoryViewModelBinder: IInventoryViewModelBinder
    {

        public InventoryViewModel ToViewModel(Inventory model) =>
            new InventoryViewModel
            {
                ProductName = model.ProductId.ToString(),
                Quantity = model.Quantity,
                DateTime = model.DateTime,
                Warehouse = model.WarehouseId.ToString()
            };

        public List<InventoryViewModel> ToViewModel(List<Inventory> models) => models.Select(ToViewModel).ToList();
    }
}
