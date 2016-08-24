using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExecuteAutoEmployee.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Salary { get; set; }

        public int DurationWorked { get; set; }

        public int Grade { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Benefits> Benefits { get; set; }

    }
}