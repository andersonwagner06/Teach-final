using Microsoft.AspNetCore.Identity;
using System;

namespace Teach.Infra.CrossCutting.Identity.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
    }
}
