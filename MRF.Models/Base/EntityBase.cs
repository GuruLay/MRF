using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MRF.Models.Base
{
    [Serializable]
    public abstract class EntityBase:IEntityBase<Guid>
    {
        [Key]
        public virtual Guid Id { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual long? UserCreatedId { get; set; }

        public virtual DateTime? DateUpdated { get; set; }
        public virtual long? UserUpdatedId { get; set; }

        public virtual DateTime? DateDeleted { get; set; }
        public virtual long? UserDeletedId { get; set; }

        public virtual bool IsDeleted { get; set; }

        [NotMapped] private string _entityTypeName;

        [NotMapped]
        public virtual string EntityTypeName
        {
            get
            {
                if (_entityTypeName != null)
                {
                    return _entityTypeName;
                }

                var type = GetType();

                if (type.Name.Contains("_") && type.BaseType != null)
                {
                    return type.BaseType.Name;
                }

                return (_entityTypeName = type.Name);
            }
        }
    }
}
