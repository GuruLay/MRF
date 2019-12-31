using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRF.Models;
using MRF.Web.ViewModels.ExpenseViewModels;

namespace MRF.Web.ViewModelBinder.Interfaces
{
    public interface IExpenseIndexViewModelBinder
    {
        ExpenseIndexViewModel ToViewModel(List<Expense> models);
    }
}
