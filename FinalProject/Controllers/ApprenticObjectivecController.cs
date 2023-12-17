using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.Abstract;
using FinalProject.Repsitories.ApprenticeshipRepsitories.Abstract;
using FinalProject.Repsitories.ApprenticObjectivecRepsitories.Abstract;
using FinalProject.Repsitories.ObjectivecRepsitories.Abstract;
using FinalProject.Repsitories.StudentRepsitories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class ApprenticObjectivecController : Controller
    {
      
        public readonly IApprenticObjectivecRepsitories _IApprenticObjectivecRepsitories;
        public readonly IApprenticeshipRepsitories _IApprenticeshipRepsitories;
        public readonly IObjectivecRepsitories _IObjectivecRepsitories;
        public ApprenticObjectivecController(IApprenticObjectivecRepsitories IApprenticObjectivecRepsitories, IApprenticeshipRepsitories IApprenticeshipRepsitories, IObjectivecRepsitories IObjectivecRepsitories)
        {

            this._IApprenticObjectivecRepsitories = IApprenticObjectivecRepsitories;
            this._IApprenticeshipRepsitories = IApprenticeshipRepsitories;
            this._IObjectivecRepsitories= IObjectivecRepsitories;
        }
        public IActionResult Index()
        {
            var ApprenticObjectiveList = _IApprenticObjectivecRepsitories.GetAllApprenticObjectivec();
            ViewBag.ApprenticObjective = ApprenticObjectiveList;
            return View(ApprenticObjectiveList);
        }

        public IActionResult Add()
        {
          //  ViewBag.Apprenticeship = _IApprenticeshipRepsitories.GetAllApprenticeship();
           // ViewBag.Objective = _IObjectivecRepsitories.GetAllObjectivec();
            return View();
        }

        public async Task<IActionResult> Insert(AddApprenticObjectives apprenticObjectives)
        {
            ApprenticeshipsObjectives apprenticeshipsObjectives = new ApprenticeshipsObjectives();

            apprenticeshipsObjectives.apprenticeshipId = apprenticObjectives.apprenticeshipId;
            apprenticeshipsObjectives.objectiveId = apprenticObjectives.objectiveId;

            await _IApprenticObjectivecRepsitories.AddApprenticObjectivec(apprenticeshipsObjectives);

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int apprenticeshipId,int objectiveId)
        {

            var Edit = _IApprenticObjectivecRepsitories.EditApprenticObjectivec(apprenticeshipId, objectiveId);
           // ViewBag.Apprenticeship = _IApprenticeshipRepsitories.GetAllApprenticeship();
            ViewBag.Objective = _IObjectivecRepsitories.GetAllObjectivec();
            return View(Edit);
        }
        public IActionResult Update(AddApprenticObjectives apprenticObjectives)
        {
            _IApprenticObjectivecRepsitories.UpdateApprenticObjectivec(apprenticObjectives);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(AddApprenticObjectives addApprenticObjectives)
        {
            _IApprenticObjectivecRepsitories.DeleteApprenticObjectivec(addApprenticObjectives);

            return RedirectToAction("Index");
        }
    }
}
