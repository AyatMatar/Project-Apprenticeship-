

using FinalProject.Data.Entites;
using FinalProject.DTO;

namespace FinalProject.Repsitories.ApprenticObjectivecRepsitories.Abstract
{
    public interface IApprenticObjectivecRepsitories
    {
        public List<ApprenticeshipsObjectives> GetAllApprenticObjectivec();
        public Task AddApprenticObjectivec(ApprenticeshipsObjectives apprenticeshipsObjectives);
        public ApprenticeshipsObjectives EditApprenticObjectivec(int apprenticeshipId, int objectiveId);
        public void UpdateApprenticObjectivec(AddApprenticObjectives apprenticObjectives);
        public void DeleteApprenticObjectivec(AddApprenticObjectives addApprenticObjectives);
    }
}
