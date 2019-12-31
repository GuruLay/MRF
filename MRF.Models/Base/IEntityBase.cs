using System;
using System.Collections.Generic;
using System.Text;

namespace MRF.Models.Base
{
    public interface IEntityBase<TId>
        where TId: struct, IEquatable<TId>
    {
        TId Id { get; set; }
        DateTime DateCreated { get; set; }
        long? UserCreatedId { get; set; }

        DateTime? DateUpdated { get; set; }
        long? UserUpdatedId { get; set; }

        DateTime? DateDeleted { get; set; }
        long? UserDeletedId { get; set; }

        bool IsDeleted { get; set; }

        string EntityTypeName { get; }

    }
}
