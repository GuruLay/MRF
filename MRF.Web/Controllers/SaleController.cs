using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MRF.Services.Domain.Interfaces;
using MRF.Web.ViewModelBinder.Interfaces;

namespace MRF.Web.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        private ISaleService _service;
        private ISaleIndexViewModelBinder _modelBinder;

        public SaleController(ISaleService service, ISaleIndexViewModelBinder modelBinder)
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