using System;
using System.Collections.Generic;
using System.Text;

namespace MRF.Infrastructure.Enums
{
    public enum ContactType
    {
        Email,
        Mobile,
        LandLine,
        Fax
    }

    public enum ProductStatus
    {
        Raw,
        ReadyForSale,
        Damage,
        Reserve
    }

    public enum ProductionType
    {
        Rice
    }
    public enum ProductionStatus
    {
        NotStarted,
        Start,
        Finish
    }

    public enum CashFlowType
    {
        Debit,
        Credit
    }

    public enum ExpenseType
    {
        ExpenseOne,
        ExpenseTwo,
        ExpenseThree
    }

    public enum IncomeType
    {
        IncomeOne,
        IncomeTwo,
        IncomeThree
    }

}
