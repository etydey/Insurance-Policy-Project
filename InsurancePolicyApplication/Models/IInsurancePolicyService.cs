using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsurancePolicyApplication.Models
{
    public interface IInsurancePolicyService
    {
        List<ContentInsurance> GetContentInsurances();
        List<Category> GetCategories();
        void AddContent(ContentInsurance newContent);
        void DeleteContent( int id);
    }
}
