using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PFServiceClient
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Salary { get; set; }

        public int DurationWorked { get; set; }

        public int Grade { get; set; }

        public string Email { get; set; }
    }
}
