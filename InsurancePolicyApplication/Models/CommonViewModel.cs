using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsurancePolicyApplication.Models
{
    public class CommonViewModel
    {
        public ContentInsurance addContent { get; set; }
        public List<ContentInsurance> contentInsurances { get; set; }
    }
}
