using System.Collections.Generic;
using MRF.Models;
using MRF.Web.ViewModels.InventoryViewModels;

namespace MRF.Web.ViewModelBinder.Interfaces
{
    public interface IInventoryViewModelBinder
    {
        List<InventoryViewModel> ToViewModel(List<Inventory> models);
    }
}
