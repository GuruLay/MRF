using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MRF.Services;
using MRF.Services.Domain.Interfaces;
using MRF.Web.ViewModelBinder.Interfaces;

namespace MRF.Web.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _service;
        private readonly IInventoryIndexViewModelBinder _modelBinder;

        public InventoryController(IInventoryService service, IInventoryIndexViewModelBinder modelBinder)
        {
            _service= service;
            _modelBinder = modelBinder;
        }
        
        public IActionResult Index()
        {
            var models = _service.GetAll().ToList();

            var viewModel = _modelBinder.ToViewModel(models);

            return View(viewModel);
        }
    }
}