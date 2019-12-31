using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRF.Web.ViewModels.ExpenseViewModels
{
    public class ExpenseIndexViewModel
    {
        public List<ExpenseViewModel> Expenses { get; set; }

        public ExpenseIndexViewModel(List<ExpenseViewModel> expenses)
        {
            Expenses = expenses;
        }
    }
}
