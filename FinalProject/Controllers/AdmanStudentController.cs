using FinalProject.Data.Entites;
using FinalProject.Data.Migrations;
using FinalProject.DTO;
using FinalProject.Repsitories.AdmanStudent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NToastNotify;
using System.Composition;
using System.Security.Claims;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "STUDENT")]
    public class AdmanStudentController : Controller
    {
        public readonly IAdmanStudent _admanStudent;
        private readonly IToastNotification _toastNotification;
        public AdmanStudentController(IAdmanStudent admanStudent, IToastNotification toastNotification)
        {
            this._admanStudent = admanStudent;
            _toastNotification = toastNotification;
        }

        public IActionResult Assignment()
        {
           
            string LogId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            var assim = _admanStudent.GetAllassignment(LogId);
            ViewBag.assignment = assim;
           
            return View(assim);
        }

        public IActionResult Report(int id)
        {
            var report = _admanStudent.GetAllReport(id);
            
            ViewBag.Report=report;
            Data.Entites.Report report1 = new Data.Entites.Report();
             report1.assignmentId= id;
            
            ViewBag.Reportadd= report1;
            return View();
        }
        public FileStreamResult GetFile(long attachmetId)
        {
            var file =_admanStudent.GetFile(attachmetId);
            return file;

        }
        public IActionResult AddReport(int id)
        {
            Data.Entites.Report report = new Data.Entites.Report();
            report.assignmentId = id;
            return PartialView("_AddModelReport", report);
        }
        [HttpPost]
        public  IActionResult AddReport(DtoReport dtoReport)
        {
            //if(!ModelState.IsValid)
            //    return RedirectToAction("AddReport", dtoReport);

            var result = _admanStudent.AddReport(dtoReport);

            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Report", new { id = dtoReport.assignmentId });
        }
        [HttpGet]
        public IActionResult EditReport(int id)
        {
            var edit = _admanStudent.EditReport(id);
            var AttshFile = _admanStudent.GetAttachfiles(id);
            ViewBag.attshFile = AttshFile;
            ViewBag.edit = edit;
            
            //return View(edit) ;
            return PartialView("_EditModel", edit);
        }
        [HttpPost]
        public IActionResult EditReport(DtoReport report)
        {

            var result = _admanStudent.UpdateReport(report);

            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Report", new { id = report.assignmentId });
        }
        public IActionResult DeleteReport(int reportId,int assignmentId)
        {

            var result = _admanStudent.DeletReport(reportId);

            if(result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);


            return RedirectToAction("Report", new { id =assignmentId });
        }
        public IActionResult DeletAttsh(int attachmetId, int assignmentId)
        {
            var result = _admanStudent.DeletAttsh(attachmetId);

            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);

            return RedirectToAction("Report", new { id = assignmentId });
            //var report = _admanStudent.GetAllReport(assignmentId);

            //ViewBag.Report = report;
            //return View("_EditModel", report);
        }
    }
}
