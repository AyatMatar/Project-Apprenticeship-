using FinalProject.Data.Entites;
using FinalProject.DTO;
using System.ComponentModel.Design;

namespace FinalProject.Repsitories.Abstract
{
    public interface IUniversityRepsitories
    {
        public List< University> GetAllUniversity();
        public RequestStatus AddUniversity(University university);
        public University EditUniversity(int id);
        public RequestStatus UpdateUniversity(AddUniversity addUniversity);
        public RequestStatus DeletUniversity(int id);
      
    }
}
