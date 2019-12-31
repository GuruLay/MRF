using System;
using System.Collections.Generic;
using System.Text;
using MRF.Infrastructure.Enums;
using MRF.Models.Base;

namespace MRF.Models
{
    public class Contact:EntityBase
    {
        public string Address { get; set; }
        public ContactType Type { get; set; }
    }
}
