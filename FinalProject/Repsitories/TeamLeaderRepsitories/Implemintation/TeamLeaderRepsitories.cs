using FinalProject.Data;
using FinalProject.Data.Entites;
using FinalProject.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repsitories.TeamLeaderRepsitories.Abstract
{
    public class TeamLeaderRepsitories : ITeamLeaderRepsitories
    {
        public readonly ApplicationDbContext dbcontext;
        private readonly UserManager<Person> _userManager;
        public TeamLeaderRepsitories(ApplicationDbContext context, UserManager<Person> _userManager) {
        
          this.dbcontext = context;
            this._userManager = _userManager;
        }

        public async Task<RequestStatus> AddTeamleader(AddTeamleader teamleader,string Password)
        {
            try
            {
                var user = CreateUser();
                user.UserName = teamleader.Email;
                user.FirstName = teamleader.FirstName;
                user.LastName = teamleader.LastName;
                user.SecondName = teamleader.SecondName;
                user.thirdName = teamleader.thirdName;
                user.Email = teamleader.Email;
                user.NormalizedEmail = teamleader.Email.ToUpper();
                user.NormalizedUserName = teamleader.Email;
                user.National_number = teamleader.National_number;
                user.PhoneNumber = teamleader.PhoneNumber;
                user.Age = teamleader.Age;
                user.department = teamleader.department;
                user.companyId = teamleader.companyId;
                user.EmailConfirmed = true;

                var result = await _userManager.CreateAsync(user, Password);
                return new RequestStatus(1, $"Add New Teamleader Successfully");
            }
            catch (Exception)
            {
                return new RequestStatus(0, "Add New Teamleader Failed...!");

            }

        }
        public RequestStatus DeletTeamleader(string id)
        {
            try
            {
                var Delete = dbcontext.apprenticeships.Where(x => x.teamleaderId == id).FirstOrDefault();
                if(Delete == null) {
                    var DeleteTeamleader = dbcontext.teamleaders.Where(x => x.Id == id).FirstOrDefault();
                    DeleteTeamleader.isdelete=true;
                    dbcontext.Update(DeleteTeamleader);
                    dbcontext.SaveChanges();
                    return new RequestStatus(1, $"Delete Teamleader Successfully");
                }
                return new RequestStatus(0, "You cannot delete a Teamleader because it contains one or more trainings....!");
            }
            catch (Exception)
            {

                return new RequestStatus(0, "You cannot delete a Teamleader because it contains one or more trainings....!");
            }
        }

        public List<Teamleader> GetAllTeamleader()
        {
            var teamleadersList = dbcontext.teamleaders.Include(x=>x.company).ToList();
            var teamleaders = teamleadersList.Where(x => !x.isdelete).ToList();
           return teamleaders;
        }
        public Teamleader EditTeamleader(string id)
        {
            var Edit = dbcontext.teamleaders.Where(x => x.Id == id).FirstOrDefault();

            return Edit;
        }
        public RequestStatus UpdateTeamleader(AddTeamleader teamleader)
        {
            try
            {
                var existingTeamleader = dbcontext.teamleaders.Where(x => x.Id == teamleader.Id).FirstOrDefault();
                if (existingTeamleader != null)
                {

                    existingTeamleader.FirstName = teamleader.FirstName;
                    existingTeamleader.LastName = teamleader.LastName;
                    existingTeamleader.Age = teamleader.Age;
                    existingTeamleader.department = teamleader.department;
                    existingTeamleader.EmailConfirmed = true;
                    existingTeamleader.NormalizedEmail = teamleader.Email.ToUpper();
                    existingTeamleader.UserName = teamleader.Email;
                    existingTeamleader.Email = teamleader.Email;
                    existingTeamleader.companyId = teamleader.companyId;
                    dbcontext.teamleaders.Update(existingTeamleader);
                    dbcontext.SaveChanges();
                }
                return new RequestStatus(1, $"Update Teamleader Successfully");
            }
            catch (Exception)
            {
                return new RequestStatus(0, "Update Teamleader Failed...!");

            }

        
        }
        private Teamleader CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Teamleader>();
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
