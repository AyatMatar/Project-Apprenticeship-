using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.Abstract;
using FinalProject.Repsitories.ObjectivecRepsitories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class ObjectivecController : Controller
    {
        public readonly IObjectivecRepsitories _IObjectivecRepsitories;
        private readonly IToastNotification _toastNotification;
        public ObjectivecController(IObjectivecRepsitories IObjectivecRepsitories, IToastNotification _toastNotification)
        { 
            this._IObjectivecRepsitories = IObjectivecRepsitories;
            this._toastNotification = _toastNotification;
        }
        public IActionResult Index()
        {
            var ObjectivecList = _IObjectivecRepsitories.GetAllObjectivec();
            ViewBag.Objectives = ObjectivecList;
            Objective objective = new Objective();
            ViewBag.objective = objective;
            return View(ObjectivecList);
        }

        public IActionResult Add()
        {

            return View();
        }

        public  IActionResult Insert(Objective objectivec)
        {
            Objective obj = new Objective();
            obj.objectivecName = objectivec.objectivecName;
          
           var result=  _IObjectivecRepsitories.AddObjectivec(obj);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {


            var Edit = _IObjectivecRepsitories.EditObjectivec(id);

            return View(Edit);
        }
        public IActionResult Update(AddObjectivec add)
        {
           var result= _IObjectivecRepsitories.UpdateObjectivec(add);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int objectiveId)
        {
          var result=  _IObjectivecRepsitories.DeleteObjectivec(objectiveId);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
    }
}
