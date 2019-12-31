using System.Collections.Generic;
using MRF.Models;
using MRF.Web.ViewModels.ExpenseViewModels;

namespace MRF.Web.ViewModelBinder.Interfaces
{
    public interface IExpenseViewModelBinder
    {
        List<ExpenseViewModel> ToViewModel(List<Expense> models);
    }
}
