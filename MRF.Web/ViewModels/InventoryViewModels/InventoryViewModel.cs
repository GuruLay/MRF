using System;

namespace MRF.Web.ViewModels.InventoryViewModels
{
    /// <summary>
    /// Inventory View Model
    /// </summary>
    public class InventoryViewModel
    {
        /// <summary>
        /// Inventory Product Name
        /// </summary>
        public string ProductName { get; set; }
        
        /// <summary>
        /// Quantity of Inventory Product
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Inventory recording Date and Time
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Inventory warehouse name
        /// </summary>
        public string Warehouse { get; set; }
    }
}
