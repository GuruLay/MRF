using System;
using System.Collections.Generic;
using System.Text;
using MRF.Models.Base;

namespace MRF.Models
{
    public class Address:EntityBase
    {
        public string Number { get; set; }
        public string Street { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Township { get; set; }
    }
}
