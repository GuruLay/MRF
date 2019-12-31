using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MRF.Services.Domain.Interfaces;
using MRF.Web.ViewModelBinder.Interfaces;

namespace MRF.Web.Controllers
{
    public class ExpenseController : Controller
    {
        private IExpenseIndexViewModelBinder _modelBinderBinder;
        private IExpenseService _service;

        public ExpenseController(IExpenseService service, IExpenseIndexViewModelBinder modelBinderBinder)
        {
            _service = service;
            _modelBinderBinder = modelBinderBinder;
        }
        public IActionResult Index()
        {
            var models = _service.GetAll().ToList();
            var viewModel = _modelBinderBinder.ToViewModel(models);
            return View(viewModel);
        }
    }
}