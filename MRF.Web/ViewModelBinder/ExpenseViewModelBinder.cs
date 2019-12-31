using System.Collections.Generic;
using System.Linq;
using MRF.Models;
using MRF.Web.ViewModelBinder.Interfaces;
using MRF.Web.ViewModels.ExpenseViewModels;

namespace MRF.Web.ViewModelBinder
{
    public class ExpenseViewModelBinder:IExpenseViewModelBinder
    {
        public ExpenseViewModel ToViewModel(Expense model) 
            => new ExpenseViewModel{
                ExpendType = model.ExpenseType.Name,
                Amount = model.Amount,
                DateTime = model.DateTime
            };

        public List<ExpenseViewModel> ToViewModel(List<Expense> models) 
            => models.Select(ToViewModel).ToList();
    }
}
