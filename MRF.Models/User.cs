using System;
using Microsoft.AspNetCore.Identity;

namespace MRF.Models
{
    public class User:IdentityUser
    {
        public Guid ClientId { get; set; }
    }
}
