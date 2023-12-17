

using FinalProject.Data.Entites;
using FinalProject.DTO;

namespace FinalProject.Repsitories.ApprenticeshipRepsitories.Abstract
{
    public interface IApprenticeshipRepsitories
    {
        public List<training> GetAllApprenticeship();
        public RequestStatus AddApprenticeship(UpdateApprenticeship apprenticeship);
        public UpdateApprenticeship EditApprenticeship(int id);
        public RequestStatus UpdateApprenticeship(UpdateApprenticeship update);
        public RequestStatus DeleteApprenticeship(int id);
    }
}
