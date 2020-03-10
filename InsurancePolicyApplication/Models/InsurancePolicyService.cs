using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InsurancePolicyApplication.Models
{
    public class InsurancePolicyService : IInsurancePolicyService
    {
        private readonly InsurancePolicyDBContext _context;

        public InsurancePolicyService(InsurancePolicyDBContext context)
        {
            _context = context;
        }
        public void AddContent(ContentInsurance newContent)
        {
            _context.Add(newContent);
            _context.SaveChanges();
        }

        public void DeleteContent(int id)
        {
            var contentInsurance = _context.ContentInsurances.Find(id);
            _context.ContentInsurances.Remove(contentInsurance);
            _context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            var categories = _context.Categories;
            return categories.ToList();
        }

        public List<ContentInsurance> GetContentInsurances()
        {
            var contentList = _context.ContentInsurances.Include(c => c.category);
            return contentList.ToList();
        }
    }
}
