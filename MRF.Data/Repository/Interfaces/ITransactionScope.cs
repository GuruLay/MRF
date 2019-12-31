using System;
using System.Collections.Generic;
using System.Text;

namespace MRF.Data.Repository.Interfaces
{
    public interface ITransactionScope
    {
        Guid? BeginTransaction();
        void EndTransaction(Guid? token);
        void DisposeTransaction(Guid? token, bool rollBack);
        bool HasTransactionStarted();
    }
}
