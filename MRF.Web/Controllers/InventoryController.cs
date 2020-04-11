using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MRF.Services;
using MRF.Services.Domain.Interfaces;
using MRF.Web.ViewModelBinder.Interfaces;
using MRF.Web.ViewModels;
using MRF.Web.ViewModels.InventoryViewModels;

namespace MRF.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _service;
        private readonly IInventoryViewModelBinder _modelBinder;

        public InventoryController(IInventoryService service, IInventoryViewModelBinder modelBinder)
        {
            _service= service;
            _modelBinder = modelBinder;
        }


        /// <summary>
        /// Get All Available Inventory List
        /// </summary>
        /// <returns>All Available Inventories list</returns>
        [HttpGet]
        [Route("api/Inventory/GetAll")]
        public List<InventoryViewModel> GetAll()
        {
            var models = _service.GetAll().ToList();

            var viewModel = _modelBinder.ToViewModel(models);

            return viewModel;
        }
    }
}