using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.ApprenticeshipRepsitories.Abstract;
using FinalProject.Repsitories.ObjectivecRepsitories.Abstract;
using FinalProject.Repsitories.StudentRepsitories.Abstract;
using FinalProject.Repsitories.TeamLeaderRepsitories.Abstract;
using FinalProject.Repsitories.UniversitySupervisorRepsitories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "ADMIN")]

    public class ApprenticeshipController : Controller
    {
        public readonly IApprenticeshipRepsitories _IApprenticeshipRepsitories;
        public readonly IStudentRepsitories _studentRepsitories;
        public readonly ISupervisorRepsitories _SupervisorRepsitories;
        public readonly ITeamLeaderRepsitories _TeamLeaderRepsitories;
        public readonly IObjectivecRepsitories _IObjectivecRepsitories;
        private readonly IToastNotification _toastNotification;
        public ApprenticeshipController(IApprenticeshipRepsitories IApprenticeshipRepsitories, IStudentRepsitories studentRepsitories,
            ISupervisorRepsitories ISupervisorRepsitories, ITeamLeaderRepsitories ITeamLeaderRepsitories, IObjectivecRepsitories _IObjectivecRepsitories, IToastNotification _toastNotification
            )
        {

            this._IApprenticeshipRepsitories = IApprenticeshipRepsitories;
            this._studentRepsitories = studentRepsitories;
            this._SupervisorRepsitories = ISupervisorRepsitories;
            this._TeamLeaderRepsitories = ITeamLeaderRepsitories;
            this._IObjectivecRepsitories = _IObjectivecRepsitories;
            this._toastNotification = _toastNotification;
        }
        public IActionResult Index()
        {

          
             var ApprenticeshipList = _IApprenticeshipRepsitories.GetAllApprenticeship();

            ViewBag.training = ApprenticeshipList;

            return View(ApprenticeshipList);
        }

        public IActionResult Add()
        {
            ViewBag.Students = _studentRepsitories.GetAllStudent();
            ViewBag.Teamleaders = _TeamLeaderRepsitories.GetAllTeamleader();
            ViewBag.Supervisors = _SupervisorRepsitories.GetAllSupervisor();
            ViewBag.Objective = _IObjectivecRepsitories.GetAllObjectivec();
            return View();
        }

        public IActionResult Insert(UpdateApprenticeship apprenticeship)
        {
            

           var result=  _IApprenticeshipRepsitories.AddApprenticeship(apprenticeship);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var Edit = _IApprenticeshipRepsitories.EditApprenticeship(id);
            ViewBag.Students = _studentRepsitories.GetAllStudent();
            ViewBag.Teamleaders = _TeamLeaderRepsitories.GetAllTeamleader();
            ViewBag.Supervisors = _SupervisorRepsitories.GetAllSupervisor();
            ViewBag.Objective = _IObjectivecRepsitories.GetAllObjectivec();


            return View(Edit);
        }
        public IActionResult Update(UpdateApprenticeship apprenticeship)
        {
           var result= _IApprenticeshipRepsitories.UpdateApprenticeship(apprenticeship);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
           var result= _IApprenticeshipRepsitories.DeleteApprenticeship(id);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }


    }
}
