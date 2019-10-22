using Microsoft.AspNetCore.Identity;
using System;

namespace Teach.Infra.CrossCutting.Identity.Models
{
    public class ApplicationUserToken : IdentityUserToken<Guid>
    {
    }
}
