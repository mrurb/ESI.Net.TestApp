using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Microsoft.AspNetCore.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public int CharID { get; set; }

    }
}
