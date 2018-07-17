using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetPlanner.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public override string UserName { get; set; }
    }
}
