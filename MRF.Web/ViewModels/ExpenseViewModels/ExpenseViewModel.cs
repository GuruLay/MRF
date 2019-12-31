using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MRF.Web.ViewModels.ExpenseViewModels
{
    public class ExpenseViewModel
    {
        [DisplayName("Expense Type")]
        public string ExpendType { get; set; }
        public double Amount { get; set; }
        public DateTime DateTime { get; set; }

    }
}
