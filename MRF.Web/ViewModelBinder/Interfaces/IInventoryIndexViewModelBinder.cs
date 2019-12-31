using System.Collections.Generic;
using MRF.Models;
using MRF.Web.ViewModels;

namespace MRF.Web.ViewModelBinder.Interfaces
{
    public interface IInventoryIndexViewModelBinder
    {
        InventoryIndexViewModel ToViewModel(List<Inventory> models);
    }
}
