using System.Collections.Generic;
using MRF.Web.ViewModels.InventoryViewModels;

namespace MRF.Web.ViewModels
{
    public class InventoryIndexViewModel
    {
        public List<InventoryViewModel> Inventories { get; set; }

        public InventoryIndexViewModel(List<InventoryViewModel> inventories)
        {
            Inventories = inventories;
        }
    }
}
