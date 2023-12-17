using FinalProject.Data;
using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.UniversitySupervisorRepsitories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repsitories.UniversitySupervisorRepsitories.Implemintation
{
    public class SupervisorRepsitories : ISupervisorRepsitories
    {
        public readonly ApplicationDbContext dbcontext;
        private readonly UserManager<Person> _userManager;
        public SupervisorRepsitories(ApplicationDbContext context, UserManager<Person> _userManager)
        {

            this.dbcontext = context;
            this._userManager = _userManager;
        }
        public async Task<RequestStatus> AddSupervisor(AddSupervisor supervisor,string Password)
        {
            try
            {
                var user = CreateUser();
                user.UserName = supervisor.Email;
                user.FirstName = supervisor.FirstName;
                user.LastName = supervisor.LastName;
                user.SecondName = supervisor.SecondName;
                user.thirdName = supervisor.thirdName;
                user.Email = supervisor.Email;
                user.NormalizedEmail = supervisor.Email.ToUpper();
                user.NormalizedUserName = supervisor.Email;
                user.National_number = supervisor.National_number;
                user.PhoneNumber = supervisor.PhoneNumber;
                user.Age = supervisor.Age;
                user.field_work = supervisor.field_work;
                user.EmailConfirmed = true;
                user.UniversityId = supervisor.UniversityId;
                var result = await _userManager.CreateAsync(user, Password);
                return new RequestStatus(1, $"Add New Supervisor Successfully");
            }
            catch (Exception)
            {
                return new RequestStatus(0, "Add New Supervisor Failed...!");

            }
        }

        public RequestStatus DeleteSupervisor(string id)
        {
            try
            {
                var Delete = dbcontext.apprenticeships.Where(x => x.universitySupervisorId == id).FirstOrDefault();
                if(Delete == null)
                {
                    var Deletesupervisors = dbcontext.supervisors.Where(x => x.Id == id).FirstOrDefault();
                    Deletesupervisors.isdelete = true;
                    dbcontext.Update(Deletesupervisors);
                    dbcontext.SaveChanges();
                    return new RequestStatus(1, $"Delete Supervisor Successfully");
                }
                return new RequestStatus(0, "You cannot delete a Supervisor because it contains one or more trainings....!");
            }
            catch (Exception)
            {

                return new RequestStatus(0, "You cannot delete a Supervisor because it contains one or more trainings....!");
            }

        }

        public UniversitySupervisor EditSupervisor(string id)
        {
            var Edit = dbcontext.supervisors.Where(x => x.Id == id).FirstOrDefault();

            return Edit;
        }

        public List<UniversitySupervisor> GetAllSupervisor()
        {
            var supervisorsList2 = dbcontext.supervisors.Include(x=>x.University).ToList();
            var test = supervisorsList2.Where(x => !x.isdelete).ToList();
            var supervisors = dbcontext.supervisors.Where(x => !x.isdelete).ToList();
            return test;
        }

        public RequestStatus UpdateSupervisor(AddSupervisor AddSupervisor)
        {
            try
            {
                var existingSupervisor = dbcontext.supervisors.Where(x => x.Id == AddSupervisor.Id).FirstOrDefault();
                if (existingSupervisor != null)
                {

                    existingSupervisor.FirstName = AddSupervisor.FirstName;
                    existingSupervisor.LastName = AddSupervisor.LastName;
                    existingSupervisor.Age = AddSupervisor.Age;
                    existingSupervisor.field_work = AddSupervisor.field_work;
                    existingSupervisor.EmailConfirmed = true;
                    existingSupervisor.NormalizedEmail = AddSupervisor.Email.ToUpper();
                    existingSupervisor.UserName = AddSupervisor.Email;
                    existingSupervisor.Email = AddSupervisor.Email;
                    existingSupervisor.UniversityId = AddSupervisor.UniversityId;
                    dbcontext.supervisors.Update(existingSupervisor);
                    dbcontext.SaveChanges();
                }
                return new RequestStatus(1, $"Update Supervisor Successfully");
            }
            catch (Exception)
            {
                return new RequestStatus(0, "Update Supervisor Failed...!");

            }
            
        }
        private UniversitySupervisor CreateUser()
        {
            try
            {
                return Activator.CreateInstance<UniversitySupervisor>();
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
