using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExecuteAutoEmployee.Models
{
    public class EmployeeDb : IdentityDbContext<ApplicationUser>
    {
        public EmployeeDb() : base("name=EmployeeDb")
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Benefits> Benefits { get; set; }

    }
}