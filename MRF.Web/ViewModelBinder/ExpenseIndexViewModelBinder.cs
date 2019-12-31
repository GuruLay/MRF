using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRF.Models;
using MRF.Web.ViewModelBinder.Interfaces;
using MRF.Web.ViewModels.ExpenseViewModels;

namespace MRF.Web.ViewModelBinder
{
    public class ExpenseIndexViewModelBinder:IExpenseIndexViewModelBinder
    {
        private IExpenseViewModelBinder _modelBinder;

        public ExpenseIndexViewModelBinder(IExpenseViewModelBinder modelBinder)
        {
            _modelBinder = modelBinder;
        }
        public ExpenseIndexViewModel ToViewModel(List<Expense> models)
        {
            var lsExpenseViewModels = _modelBinder.ToViewModel(models);
            var viewModel = new ExpenseIndexViewModel(lsExpenseViewModels);
            return viewModel;
        }
    }
}
