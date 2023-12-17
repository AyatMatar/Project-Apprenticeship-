using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.CompanyRepsitories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class CompanyController : Controller
    {

        public readonly ICompanyRepsitories _ICompanyRepsitories;
        private readonly IToastNotification _toastNotification;
        public CompanyController(ICompanyRepsitories ICompanyRepsitories, IToastNotification _toastNotification   )
        {

            this._ICompanyRepsitories = ICompanyRepsitories;
            this._toastNotification = _toastNotification;
        }
        public IActionResult Index()
        {
            var companyList = _ICompanyRepsitories.GetAllCompany();
            ViewBag.company = companyList;
            Company company = new Company();
            ViewBag.companyAdd= company;
            return View(companyList);
        }

        //public IActionResult Add()
        //{

        //    return View();
        //}

        public IActionResult Insert(Company company)
        {
          Company com = new Company();
            com.companyName = company.companyName;
            com.companyAddress = company.companyAddress;

           var result=  _ICompanyRepsitories.AddCompany(com);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");

          
        }
        public IActionResult Edit(int id)
        {


            var Edit = _ICompanyRepsitories.EditCompany(id);
          
            return View(Edit);
        }
        public IActionResult Update(AddCompany company)
        {
           var result= _ICompanyRepsitories.UpdateCompany(company);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int companyId)
        {
          var result=  _ICompanyRepsitories.DeletCompany(companyId);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
    }
}
