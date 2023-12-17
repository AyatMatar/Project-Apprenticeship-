using FinalProject.Data;
using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.CompanyRepsitories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repsitories.CompanyRepsitories.Implemintation
{
    public class CompanyRepsitories : ICompanyRepsitories
    {
        public readonly ApplicationDbContext dbcontext;
        public CompanyRepsitories(ApplicationDbContext context) {
        
          this.dbcontext = context;
        }

        public RequestStatus AddCompany( Company company)
        {
            try
            {
                Company COM = new Company();
                COM.companyName = company.companyName;
                COM.companyAddress = company.companyAddress;
                dbcontext.Add(COM);
                dbcontext.SaveChanges();
                return new RequestStatus(1, $"Add New Company Successfully");
            }
            catch (Exception)
            {

                return new RequestStatus(0, "Add New Company Failed...!");
            }

        }
        public RequestStatus DeletCompany(int id)
        {
            try
            {
                
                var Delete= dbcontext.apprenticeships.Include(x=>x.teamleader).ThenInclude(x=>x.company).Where(x => x.teamleader.company.companyId == id).FirstOrDefault();
                if (Delete == null) {
                    var Deletecompaniy = dbcontext.companies.Where(x => x.companyId == id).FirstOrDefault();
                    Deletecompaniy.isdelete = true;
                    dbcontext.Update(Deletecompaniy);
                    dbcontext.SaveChanges();
                    return new RequestStatus(1, $"Delet Company Successfully");
                }
                return new RequestStatus(0, "You cannot delete a company because it contains one or more trainings....!");
            }
            catch (Exception)
            {
                return new RequestStatus(0, "Delet Company Failed...!");
              
            }
        }

        public List<Company> GetAllCompany()
        {
            var CompanyList = dbcontext.companies.Where(x=>!x.isdelete).ToList();
           return CompanyList;
        }
        public Company EditCompany(int id)
        {
            var Edit = dbcontext.companies.Where(x => x.companyId == id).FirstOrDefault();

            return Edit;
        }
        public RequestStatus UpdateCompany(AddCompany company)
        {
            try
            {
                var existingCompany = dbcontext.companies.Where(x => x.companyId == company.companyId).FirstOrDefault();
                if (existingCompany != null)
                {

                    existingCompany.companyName = company.companyName;
                    existingCompany.companyAddress = company.companyAddress;

                    dbcontext.companies.Update(existingCompany);
                    dbcontext.SaveChanges();
                    return new RequestStatus(1, $"Update Report Successfully");
                }
                return new RequestStatus(0, "Update Report Failed...!");

            }
            catch (Exception)
            {

                return new RequestStatus(0, "Update Report Failed...!");
            }
          

            
        }
        
    }
}
