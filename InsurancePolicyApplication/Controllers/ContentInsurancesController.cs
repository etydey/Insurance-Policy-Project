using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InsurancePolicyApplication.Models;
using System.Diagnostics;

namespace InsurancePolicyApplication.Controllers
{
    public class ContentInsurancesController : Controller
    {
        private readonly IInsurancePolicyService _policyService;

        public ContentInsurancesController(IInsurancePolicyService policyService)
        {
            _policyService = policyService;
        }

        // GET: ContentInsurances
        public IActionResult Index()
        {
            CommonViewModel model = new CommonViewModel();
            model.addContent = new ContentInsurance();
            model.contentInsurances = _policyService.GetContentInsurances();
            ViewData["CategoryId"] = new SelectList(_policyService.GetCategories(), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CommonViewModel model)
        {
            if (ModelState.IsValid)
            {
                ContentInsurance newContent = new ContentInsurance { Name = model.addContent.Name, Value = model.addContent.Value, CategoryId = model.addContent.CategoryId };
                _policyService.AddContent(newContent);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_policyService.GetCategories(), "Id", "Name", model.addContent.CategoryId);
            return View(model);
        }

        // GET: ContentInsurances/Delete/5
        public IActionResult Delete(int id)
        {
            _policyService.DeleteContent(id);
            return RedirectToAction(nameof(Index));
        }

        private ContentInsurance ContentInsuranceExists(int id)
        {
            ContentInsurance content = _policyService.GetContentInsurances().Find(c => c.Id == id);
            return content;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
