using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.CompanyRepsitories.Abstract;
using FinalProject.Repsitories.TeamLeaderRepsitories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class TeamLeaderController : Controller
    {
        public readonly ITeamLeaderRepsitories _ITeamLeaderRepsitories;
        public readonly ICompanyRepsitories _ICompanyRepsitories;
        private readonly IToastNotification _toastNotification;
        public TeamLeaderController(ITeamLeaderRepsitories _ITeamLeaderRepsitories, ICompanyRepsitories _ICompanyRepsitories, IToastNotification _toastNotification) { 
          this._ITeamLeaderRepsitories = _ITeamLeaderRepsitories;
            this._ICompanyRepsitories = _ICompanyRepsitories;
            this._toastNotification = _toastNotification;
        }
        public IActionResult Index()
        {
            var TeamLeadersList = _ITeamLeaderRepsitories.GetAllTeamleader();
            ViewBag.TeamLeaders = TeamLeadersList;
            return View(TeamLeadersList);
        }

        public IActionResult Add()
        {
            ViewBag.Company = _ICompanyRepsitories.GetAllCompany();
            return View();
        }

        public async Task<IActionResult> Insert(AddTeamleader Add)
        {
          var result=  await _ITeamLeaderRepsitories.AddTeamleader(Add, Add.Password);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string id)
        {

            var Edit = _ITeamLeaderRepsitories.EditTeamleader(id);
            ViewBag.Companeis = _ICompanyRepsitories.GetAllCompany();
            return View(Edit);
        }
        public IActionResult Update(AddTeamleader teamleader)
        {
           var result= _ITeamLeaderRepsitories.UpdateTeamleader(teamleader);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string id)
        {
          var result=  _ITeamLeaderRepsitories.DeletTeamleader(id);

            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
    }
}
