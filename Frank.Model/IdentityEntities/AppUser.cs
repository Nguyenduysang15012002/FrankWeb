using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Frank.Model.IdentityEntities
{
    public class AppUser : IdentityUser<long, AppLogin, AppUserRole, AppClaim>
    {

    }
    public class AppLogin : IdentityUserLogin<long>
    {

    }
    public class AppUserRole : IdentityUserRole<long>
    {

    }
    public class AppClaim : IdentityUserClaim<long>
    {

    }
}
