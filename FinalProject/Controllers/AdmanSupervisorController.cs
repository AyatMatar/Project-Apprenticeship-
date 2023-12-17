using FinalProject.Data;
using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.AdmanStudent;
using FinalProject.Repsitories.LeaderRepsitories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "SCHOOLSUPERVISOR")]
    public class AdmanSupervisorController : Controller
    {
        public readonly ILeaderRepsitories _ILeaderRepsitories;
        public readonly IAdmanStudent _admanStudent;
        public AdmanSupervisorController(ILeaderRepsitories ILeaderRepsitories, IAdmanStudent admanStudent)
        {
            this._ILeaderRepsitories = ILeaderRepsitories;
            this._admanStudent = admanStudent;
        }
        public IActionResult Index()
        {
            string LogId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var ApprenticeshipList = _ILeaderRepsitories.GetAllSUPERVISERApprenticeship(LogId);
            ViewBag.training = ApprenticeshipList;
            return View();
        }
        public IActionResult Assignment(int Id)
        {
            var GetAllassignment = _ILeaderRepsitories.GetAllassignment(Id);
            ViewBag.assignment = GetAllassignment;
            DTOAssignment assignment = new DTOAssignment();
            List<int> objectiveIds = new List<int>();
            assignment.apprentiId = Id;
            var objectiv = _ILeaderRepsitories.GetAllObjective(Id);
            assignment.objectives = new List<DtoRools>();
            foreach (var objective in objectiv)
            {
                DtoRools dtoRools = new DtoRools();
                dtoRools.Id = objective.objective.objectiveId;
                dtoRools.Name = objective.objective.objectivecName;
                assignment.objectives.Add(dtoRools);

            }
            ViewBag.apprenticeshipId = assignment;
            ViewBag.objectives = objectiv;
            return View();

        }
        public IActionResult Report(int assignmentId, int apprenticeshipId)
        {

            var report = _admanStudent.GetAllReport(assignmentId);
            ViewBag.Report = report;
            ViewBag.apprenticeshipId = apprenticeshipId;
            return View();
        }
        public IActionResult View(int reportId, int assignmentId, int apprenticeshipId)
        {

            var report = _ILeaderRepsitories.GetAllreportLog(reportId);
            ViewBag.report = report;
            ViewBag.assignmentId = assignmentId;
            ViewBag.apprenticeshipId = apprenticeshipId;
            return View(report);
        }
        public IActionResult Dashboard()
        {

          
            return View();
        }
        public FileStreamResult GetFile(long attachmetId)
        {
            var file = _ILeaderRepsitories.GetFile(attachmetId);
            return file;

        }
    }
}
