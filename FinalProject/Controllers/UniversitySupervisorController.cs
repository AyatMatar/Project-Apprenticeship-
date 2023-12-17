using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.Abstract;
using FinalProject.Repsitories.StudentRepsitories.Abstract;
using FinalProject.Repsitories.StudentRepsitories.Implemintation;
using FinalProject.Repsitories.UniversitySupervisorRepsitories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class UniversitySupervisorController : Controller
    {
        public readonly ISupervisorRepsitories _ISupervisorRepsitories;
        public readonly IUniversityRepsitories _IUniversityRepsitories;
        private readonly IToastNotification _toastNotification;
        public UniversitySupervisorController(ISupervisorRepsitories ISupervisorRepsitories, IUniversityRepsitories _IUniversityRepsitories, IToastNotification _toastNotification)
        {

            this._ISupervisorRepsitories = ISupervisorRepsitories;
            this._IUniversityRepsitories = _IUniversityRepsitories;
            this._toastNotification = _toastNotification;

        }
        public IActionResult Index()
        {
            ViewBag.Supervisor = _ISupervisorRepsitories.GetAllSupervisor();
            return View();
        }
        public IActionResult Add()
        {
            ViewBag.Company = _IUniversityRepsitories.GetAllUniversity();
            return View();
        }

        public async Task<IActionResult> Insert(AddSupervisor Add)
        {

          var result=  await _ISupervisorRepsitories.AddSupervisor(Add, Add.Password);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string id)
        {

            var Edit = _ISupervisorRepsitories.EditSupervisor(id);
            ViewBag.Universities = _IUniversityRepsitories.GetAllUniversity();
            return View(Edit);
        }
        public IActionResult Updet(AddSupervisor Update)
        {
          var result=  _ISupervisorRepsitories.UpdateSupervisor(Update);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string id)
        {
         var result=_ISupervisorRepsitories.DeleteSupervisor(id);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
    }
}
