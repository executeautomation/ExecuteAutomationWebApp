using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExecuteAutoEmployee.Models
{
    public class Benefits
    {
        public int Id { get; set; }

        public virtual ICollection<BasicBenefits> BasicBenefits { get; set; }

        public virtual ICollection<AdditionalBenefits> AdditionalBenefits { get; set; }

    }
}