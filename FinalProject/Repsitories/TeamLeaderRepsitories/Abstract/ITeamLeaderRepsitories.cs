using FinalProject.Data.Entites;
using FinalProject.DTO;

namespace FinalProject.Repsitories.TeamLeaderRepsitories.Abstract
{
    public interface ITeamLeaderRepsitories
    {
        public List< Teamleader> GetAllTeamleader();
        public Task<RequestStatus> AddTeamleader(AddTeamleader teamleader, string Password);
        public Teamleader EditTeamleader(string id);
        public RequestStatus UpdateTeamleader(AddTeamleader teamleader);
        public RequestStatus DeletTeamleader(string id);
      
    }
}
