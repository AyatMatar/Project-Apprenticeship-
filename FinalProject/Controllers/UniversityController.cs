using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class UniversityController : Controller
    {
        public readonly IUniversityRepsitories _IUniversityRepsitories;
        private readonly IToastNotification _toastNotification;
        public UniversityController(IUniversityRepsitories IUniversityRepsitories, IToastNotification _toastNotification)
        { 
            this._IUniversityRepsitories = IUniversityRepsitories;
            this._toastNotification = _toastNotification;
        }
        public IActionResult Index()
        {
            var UniversityList = _IUniversityRepsitories.GetAllUniversity();
            ViewBag.Universites = UniversityList;
            University university = new University();
            ViewBag.university = university;
            return View(UniversityList);
        }

        public IActionResult Add()
        {

            return View();
        }

        public IActionResult Insert(University university)
        {
            University Univ = new University();
            Univ.universityName = university.universityName;
            Univ.universityAddress = university.universityAddress;
            var result= _IUniversityRepsitories.AddUniversity(Univ);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {


            var Edit = _IUniversityRepsitories.EditUniversity(id);

            return View(Edit);
        }
        public IActionResult Update(AddUniversity addUniversity)
        {
         var result=   _IUniversityRepsitories.UpdateUniversity(addUniversity);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int UniversityId)
        {
          var  result= _IUniversityRepsitories.DeletUniversity(UniversityId);

            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
    }
}
