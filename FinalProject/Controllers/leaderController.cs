using FinalProject.Data.Entites;
using FinalProject.Data.Migrations;
using FinalProject.DTO;
using FinalProject.Helper;
using FinalProject.Repsitories.AdmanStudent;
using FinalProject.Repsitories.LeaderRepsitories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.AccessControl;
using System.Security.Claims;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "TEAMLEADER")]
    public class leaderController : Controller
    { 
        public readonly ILeaderRepsitories _ILeaderRepsitories;
        public readonly IAdmanStudent _admanStudent;
        private readonly IToastNotification _toastNotification;
        public leaderController(ILeaderRepsitories ILeaderRepsitories, IAdmanStudent admanStudent, IToastNotification _toastNotification)
        {
            this._ILeaderRepsitories = ILeaderRepsitories;
            this._admanStudent = admanStudent;
           this._toastNotification = _toastNotification;
        }
        public IActionResult Index()
        {
            string LogId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var ApprenticeshipList = _ILeaderRepsitories.GetAllLeaderApprenticeship(LogId);
            ViewBag.training = ApprenticeshipList;

            return View();
           
        }
        public IActionResult Dashboard()
        {
            //var NumStudent

            return View();

        }
        public IActionResult Assignment(int Id)
        {
            var GetAllassignment = _ILeaderRepsitories.GetAllassignment(Id);
            ViewBag.assignment = GetAllassignment;
            DTOAssignment Addassignment = new DTOAssignment();
            List<int> objectiveIds = new List<int>();
            Addassignment.apprentiId = Id;
            var objectiv = _ILeaderRepsitories.GetAllObjective(Id);
            Addassignment.objectives = new List<DtoRools>();
            foreach (var objective in objectiv)
            {
                DtoRools dtoRools = new DtoRools();
                dtoRools.Id = objective.objective.objectiveId;
                dtoRools.Name = objective.objective.objectivecName;
                Addassignment.objectives.Add(dtoRools);
             
            }
            ViewBag.apprenticeship = Addassignment;
            ViewBag.objectives = objectiv;

            return View();
        }

        public FileStreamResult GetFile(long attachmetId)
          {
              var file =_ILeaderRepsitories.GetFile(attachmetId);
              return file;
          
          }
        public IActionResult AddAssignment(int id)
        {
            DTOAssignment assignment = new DTOAssignment();
            var objectives = _ILeaderRepsitories.GetAllObjective(id);
            ViewBag.objectives = objectives;
            assignment.apprentiId=id;
            assignment.objectives = new List<DtoRools>();
            foreach (var objective in objectives)
            {
                DtoRools dtoRools = new DtoRools();
                dtoRools.Id = objective.objective.objectiveId;
                dtoRools.Name = objective.objective.objectivecName;
                objectives.Add(objective);

            }
            return PartialView("_AddAssignment", assignment);
            
        }
        [HttpPost]
        public IActionResult AddAssignment(DTOAssignment assignment)
        {
            var result = _ILeaderRepsitories.Addassignment(assignment);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            //var studentEmail = _admanStudent.GetStudentEmailByTreningId(assignment.apprentiId);
            //SendEmail.NewEmail(studentEmail,"This Email is to you know that there is a new assinment assigned to you , " +
            //    "please go to the apprenticeship portal to check ut",assignment.assignmentTitle);
            return RedirectToAction("Assignment" , new { Id = assignment.apprentiId });

        }
        //[HttpGet]
        // public IActionResult EditAssignment(int assignmentId)
        //{
        //    //var objectives = _ILeaderRepsitories.GetAllObjective(apprenticeshipId);
        //    //ViewBag.objectives = objectives;
        //    //var AttshFile = _ILeaderRepsitories.GetAttachfiles(assignmentId ?? 0);
        //    //ViewBag.attshFile = AttshFile;
        //    var edit = _ILeaderRepsitories.Editassignment(assignmentId );

        //    return PartialView("_EditAssignment", edit);

        //}
        [HttpPost]
        public IActionResult EditAssignment(DTOAssignment dTOAssignment)
        {
         var result= _ILeaderRepsitories.Updateassignment(dTOAssignment);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);

            return  RedirectToAction("Assignment", new { id = dTOAssignment.apprentiId });
        }
        public IActionResult DeleteAssignment(int id,int apprentiId)
        {
          var result=_ILeaderRepsitories.Deletassignment(id);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);

            return RedirectToAction("Assignment", new { Id = apprentiId });
        }
        public IActionResult DeletAttsh(int attachmetId, int assignmentId)
        {
            var result = _admanStudent.DeletAttsh(attachmetId);

            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);

            return RedirectToAction("Assignment", new { id = assignmentId });
        }
        public IActionResult Report(int assignmentId, int apprentiId)
        {
            var report = _admanStudent.GetAllReport(assignmentId);
            ViewBag.Report = report;

            ViewBag.apprentiId = apprentiId;
            return View();
        }
        public IActionResult View(int id)
        {
            var report = _ILeaderRepsitories.GetAllReport(id);
            return PartialView("_ViewReport", report);
        }
        public IActionResult reportStatus(int reportId, int reportStatusId,int assignmentId)
        {
            
         _ILeaderRepsitories.UbdatereportStatus(reportId, reportStatusId);
            return RedirectToAction("Index");
        }
    }
}
