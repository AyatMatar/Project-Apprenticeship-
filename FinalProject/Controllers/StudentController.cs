using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.Abstract;
using FinalProject.Repsitories.CompanyRepsitories.Abstract;
using FinalProject.Repsitories.StudentRepsitories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class StudentController : Controller
    {
        public readonly IStudentRepsitories _IstudentRepsitories;
        public readonly IUniversityRepsitories _IUniversityRepsitories;
        private readonly IToastNotification _toastNotification;
        public StudentController(IStudentRepsitories IstudentRepsitories, IUniversityRepsitories _IUniversityRepsitories, IToastNotification _toastNotification) {
        
            this._IstudentRepsitories = IstudentRepsitories;
            this._IUniversityRepsitories = _IUniversityRepsitories;
            this._toastNotification = _toastNotification;
        }
        public IActionResult Index()
        {
            var studentsList = _IstudentRepsitories.GetAllStudent();
            ViewBag.Students = studentsList;
            return View(studentsList);
        }

        public IActionResult Add(AddStudent AddStudent)
        {
            ViewBag.Company=_IUniversityRepsitories.GetAllUniversity();
            return View(AddStudent);
        }

        public  async Task  <IActionResult> Insert(AddStudent stu)
        {
            //if(ModelState.IsValid) { }
           var result =   await _IstudentRepsitories.AddStudent(stu, stu.Password);

            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string id)
        {

            var Edit = _IstudentRepsitories.EditStudent(id);
            ViewBag.Universities = _IUniversityRepsitories.GetAllUniversity();
            
            return View(Edit);
        }
        public IActionResult Updet(AddStudent stus)
        {
           var result= _IstudentRepsitories.UpdateStudent(stus);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
            
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string id )
        {
           var result= _IstudentRepsitories.DeletStudent(id);
            if (result.statusCode == 1)
                _toastNotification.AddSuccessToastMessage(result.message);
            else
                _toastNotification.AddErrorToastMessage(result.message);
           
            return RedirectToAction("Index");
        }
    }
}
