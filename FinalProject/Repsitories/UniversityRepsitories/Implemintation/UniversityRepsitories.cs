using FinalProject.Data;
using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repsitories.Implemintation
{
    public class UniversityRepsitories : IUniversityRepsitories
    {
        public readonly ApplicationDbContext dbcontext;
        private readonly UserManager<Person> _userManager;
        public UniversityRepsitories(ApplicationDbContext context, UserManager<Person> _userManager) {
        
          this.dbcontext = context;
            this._userManager = _userManager;
        }

        public RequestStatus AddUniversity( University university)
        {
            try
            {
                University Adduniversity = new University();
                Adduniversity.universityName = university.universityName;
                Adduniversity.universityAddress = university.universityAddress;
                dbcontext.Add(Adduniversity);
                dbcontext.SaveChanges();
                return new RequestStatus(1, $"Add New University Successfully");
            }
            catch (Exception)
            {

                return new RequestStatus(0, "Add New University Failed...!");
            }
        }
        public RequestStatus DeletUniversity(int id)
        {
            try
            {

                var Delete = dbcontext.apprenticeships.Include(x => x.UniversitySupervisor).ThenInclude(x => x.University).Where(x => x.UniversitySupervisor.University.universityId == id).FirstOrDefault();
                if (Delete == null)
                {
                    var University = dbcontext.Universities.Where(x => x.universityId == id).FirstOrDefault();
                    University.isdelete=true;
                    dbcontext.Update(University);
                    dbcontext.SaveChanges();
                    return new RequestStatus(1, $"Delete University Successfully");
                }
                return new RequestStatus(0, "You cannot delete a University because it contains one or more trainings.");

            }
            catch (Exception)
            {

                return new RequestStatus(0, "Delete University Failed...!");
            }

        }

        public List<University> GetAllUniversity()
        {
            var UniversitiesList = dbcontext.Universities.Where(x=>!x.isdelete).ToList();
           return UniversitiesList;
        }
        public University EditUniversity(int id)
        {
            var Edit = dbcontext.Universities.Where(x => x.universityId == id).FirstOrDefault();

            return Edit;
        }
        public RequestStatus UpdateUniversity(AddUniversity university)
        {
            try
            {
                var existingUniversities = dbcontext.Universities.Where(x => x.universityId == university.universityId).FirstOrDefault();
                if (existingUniversities != null)
                {
                    existingUniversities.universityName = university.universityName;
                    existingUniversities.universityAddress = university.universityAddress;

                    dbcontext.Universities.Update(existingUniversities);
                    dbcontext.SaveChanges();
                    return new RequestStatus(1, $"Update University Successfully");
                }
                return new RequestStatus(0, "Update University Failed...!");
            }
            catch (Exception)
            {

                return new RequestStatus(0, "Update University Failed...!");
            }
        }
    }
}
