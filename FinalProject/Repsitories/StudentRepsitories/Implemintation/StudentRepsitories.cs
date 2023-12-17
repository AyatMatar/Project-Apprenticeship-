using FinalProject.Data;
using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.StudentRepsitories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repsitories.StudentRepsitories.Implemintation
{
    public class StudentRepsitories : IStudentRepsitories
    {
        public readonly ApplicationDbContext dbcontext;
        private readonly UserManager<Person> _userManager;
        public StudentRepsitories(ApplicationDbContext context, UserManager<Person> _userManager)
        {

            dbcontext = context;
            this._userManager = _userManager;
        }

        public async Task<RequestStatus> AddStudent(AddStudent student, string Password)
        {

            try
            {
                var user = CreateUser();
                user.UserName = student.Email;
                user.FirstName = student.FirstName;
                user.LastName = student.LastName;
                user.SecondName = student.SecondName;
                user.thirdName = student.thirdName;
                user.Email = student.Email;
                user.NormalizedEmail = student.Email.ToUpper();
                user.NormalizedUserName = student.Email;
                user.National_number = student.National_number;
                user.PhoneNumber = student.PhoneNumber;
                user.number_universtity = student.number_universtity;
                user.Age = student.Age;
                user.major = student.major;
                user.EmailConfirmed = true;
                user.UniversityId = student.UniversityId;

                await  _userManager.CreateAsync(user, Password);
              return new RequestStatus(1, $"Add New Student Successfully");
            }
            catch (Exception)
            {
              return new RequestStatus(0, "Add New Student Failed...!");

            }


        }
        public RequestStatus DeletStudent(string id)
        {
            try
            {
                var Delete = dbcontext.apprenticeships.Where(x=>x.studentId == id).FirstOrDefault();
                if (Delete == null) { 
                var DeleteStudent = dbcontext.Students.Where(x => x.Id == id).FirstOrDefault();
                
                    DeleteStudent.isdelete = true;
                    dbcontext.Update(DeleteStudent);
                    dbcontext.SaveChanges();
                    return new RequestStatus(1, $"Delete Student Successfully");
                }
                return new RequestStatus(0, "You cannot delete a Student because it contains one or more trainings....!");
            }
            catch (Exception)
            {

                return new RequestStatus(0, "You cannot delete a Student because it contains one or more trainings....!");
            }
            
        }

        public List<Student> GetAllStudent()
        {
            var studentsList = dbcontext.Students.Where(x => !x.isdelete).Include(e=>e.University).Where(e => !e.isdelete).ToList();
            return studentsList;
        }
        public Student EditStudent(string id)
        {
            var Edit = dbcontext.Students.Where(x => x.Id == id).FirstOrDefault();

            return Edit;
        }
        public RequestStatus UpdateStudent(AddStudent student)
        {
            try
            {
                var existingStudent = dbcontext.Students.Where(x => x.Id == student.Id ).Include(x=>x.University).FirstOrDefault();
                if (existingStudent != null)
                {
                    existingStudent.FirstName = student.FirstName;
                    existingStudent.LastName = student.LastName;
                    existingStudent.Age = student.Age;
                    existingStudent.major = student.major;
                    existingStudent.number_universtity = student.number_universtity;
                    existingStudent.EmailConfirmed = true;
                    existingStudent.NormalizedEmail = student.Email.ToUpper();
                    existingStudent.UserName = student.Email;
                    existingStudent.PhoneNumber = student.PhoneNumber;
                    existingStudent.Email = student.Email;
                    existingStudent.UniversityId = student.UniversityId;
                    //existingStudent.University.universityName = student.universityName;
                    dbcontext.Students.Update(existingStudent);
                    dbcontext.SaveChanges();

                }
                return new RequestStatus(1, $"Update Student Successfully");
            }
            catch (Exception)
            {
                return new RequestStatus(0, "Update Student Failed...!");

            }
        }
        private Student CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Student>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Person)}'. " +
                    $"Ensure that '{nameof(Person)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}
