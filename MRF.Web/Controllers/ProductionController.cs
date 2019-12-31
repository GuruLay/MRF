using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MRF.Services.Domain.Interfaces;
using MRF.Web.ViewModelBinder.Interfaces;

namespace MRF.Web.Controllers
{
    [Authorize]
    public class ProductionController : Controller
    {
        private IProductionService _service;
        private IProductionIndexViewModelBinder _modelBinder;

        public ProductionController(IProductionService service, IProductionIndexViewModelBinder modelBinder)
        {
            _service = service;
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