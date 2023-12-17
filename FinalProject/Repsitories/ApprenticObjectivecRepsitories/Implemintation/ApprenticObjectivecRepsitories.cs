using FinalProject.Data;
using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.ApprenticeshipRepsitories.Abstract;
using FinalProject.Repsitories.ApprenticObjectivecRepsitories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repsitories.ApprenticeshipRepsitories.Implemintation
{
    public class ApprenticObjectivecRepsitories : IApprenticObjectivecRepsitories
    {
        public readonly ApplicationDbContext dbcontext;
        public ApprenticObjectivecRepsitories(ApplicationDbContext context)
        {

            this.dbcontext = context;
        }
        public async Task AddApprenticObjectivec(ApprenticeshipsObjectives apprenticObjectives)
        {
            ApprenticeshipsObjectives apprenticObjectivec = new ApprenticeshipsObjectives();
            apprenticObjectivec.apprenticeshipId = apprenticObjectives.apprenticeshipId;
            apprenticObjectivec.objectiveId = apprenticObjectives.objectiveId;

            dbcontext.Add(apprenticObjectivec);
            dbcontext.SaveChanges();
        }

        public void DeleteApprenticObjectivec(AddApprenticObjectives ApprenticObjectives)
        {
            var Delete = dbcontext.apprenticeshipsObjectives.Where(x => x.apprenticeshipId == ApprenticObjectives.apprenticeshipId && x.objectiveId == ApprenticObjectives.objectiveId).FirstOrDefault();

            dbcontext.Remove(Delete);
            dbcontext.SaveChanges();
        }

        public ApprenticeshipsObjectives EditApprenticObjectivec(int apprenticeshipId, int objectiveId)
        {
            var Edit = dbcontext.apprenticeshipsObjectives.Where(x => x.apprenticeshipId ==apprenticeshipId && x.objectiveId ==objectiveId).FirstOrDefault();

            return Edit;
        }

        public List<ApprenticeshipsObjectives> GetAllApprenticObjectivec()
        {
            var ApprenticObjectivesList = dbcontext.apprenticeshipsObjectives
          .Include(x => x.apprenticeship).ThenInclude(y => y.student).Include(x => x.apprenticeship).ThenInclude(y => y.teamleader)
          .Include(x => x.apprenticeship).ThenInclude(y => y.UniversitySupervisor).Include(s => s.objective).ToList();
            return ApprenticObjectivesList;
        }

        public void UpdateApprenticObjectivec(AddApprenticObjectives ApprenticObjectives)
        {
            var existingApprenticeship = dbcontext.apprenticeshipsObjectives.Where(x => x.apprenticeshipId == ApprenticObjectives.apprenticeshipId && x.objectiveId == ApprenticObjectives.objectiveId).FirstOrDefault();
            if (existingApprenticeship != null)
            {

                existingApprenticeship.objectiveId = ApprenticObjectives.objectiveId;
                existingApprenticeship.apprenticeshipId = ApprenticObjectives.apprenticeshipId;
               

                dbcontext.apprenticeshipsObjectives.Update(existingApprenticeship);
                dbcontext.SaveChanges();

            }
        }




    }
}
