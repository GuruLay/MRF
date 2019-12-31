using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using MRF.Models.Base;

namespace MRF.Models
{
    public class Note:EntityBase
    {
        public string Message { get; set; }
    }
}
