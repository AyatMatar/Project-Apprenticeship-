using FinalProject.Data.Entites;
using FinalProject.DTO;

namespace FinalProject.Repsitories.CompanyRepsitories.Abstract
{
    public interface ICompanyRepsitories
    {
        public List< Company> GetAllCompany();
        public RequestStatus AddCompany(Company company);
        public Company EditCompany(int id);
        public RequestStatus UpdateCompany(AddCompany company);
        public RequestStatus DeletCompany(int id);
      
    }
}
