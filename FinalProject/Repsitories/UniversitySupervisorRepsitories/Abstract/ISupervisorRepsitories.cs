

using FinalProject.Data.Entites;
using FinalProject.DTO;

namespace FinalProject.Repsitories.UniversitySupervisorRepsitories.Abstract
{
    public interface ISupervisorRepsitories
    {
        public List<UniversitySupervisor> GetAllSupervisor();
        public Task<RequestStatus> AddSupervisor(AddSupervisor Supervisor, string Password);
        public UniversitySupervisor EditSupervisor(string id);
        public RequestStatus UpdateSupervisor(AddSupervisor Supervisor);
        public RequestStatus DeleteSupervisor(string id);
    }
}
