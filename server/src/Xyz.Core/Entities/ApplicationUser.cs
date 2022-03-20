﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Xyz.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Tenant> Tenants { get; set; }
    }
}