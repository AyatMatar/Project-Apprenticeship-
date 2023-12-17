using FinalProject.Data;
using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.ApprenticeshipRepsitories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FinalProject.Repsitories.ApprenticeshipRepsitories.Implemintation
{
    public class ApprenticeshipRepsitories : IApprenticeshipRepsitories
    {
        public readonly ApplicationDbContext dbcontext;
        public ApprenticeshipRepsitories(ApplicationDbContext context)
        {
            this.dbcontext = context;
        }
        public RequestStatus AddApprenticeship(UpdateApprenticeship apprenticeship)
        {
            try
            {
                Apprenticeship App = new Apprenticeship();
                App.apprenticeshipId = apprenticeship.Id;
                App.nameApprenticeship = apprenticeship.nameApprenticeship;
                App.studentId = apprenticeship.stuId;
                App.teamleaderId = apprenticeship.teamId;
                App.universitySupervisorId = apprenticeship.SupervisorId;
                App.endDate = apprenticeship.endDate;
                App.endDate = apprenticeship.startDate;

                dbcontext.apprenticeships.Add(App);
                dbcontext.SaveChanges();
                if(apprenticeship.objectives!=null)
                foreach (var ObjId in apprenticeship.objectives)
                {
                    ApprenticeshipsObjectives apprentic = new ApprenticeshipsObjectives();
                    apprentic.apprenticeshipId = App.apprenticeshipId;
                    apprentic.objectiveId = ObjId;
                    dbcontext.apprenticeshipsObjectives.Add(apprentic);
                    dbcontext.SaveChanges();
                }
                return new RequestStatus(1, $"Add New training Successfully");
            }
            catch (Exception)
            {
                return new RequestStatus(0, "Add New training Failed...!");
              
            }
            
        }
        public RequestStatus DeleteApprenticeship(int id)
        {
            try
            {
                var oldObejectevs = dbcontext.apprenticeshipsObjectives.Where(x => x.apprenticeshipId == id).ToList();
                if(oldObejectevs!=null)
                foreach (var oldObejectev in oldObejectevs)
                {
                        oldObejectev.isdelete = true;
                    dbcontext.apprenticeshipsObjectives.Update(oldObejectev);

                    dbcontext.SaveChanges();
                }
                var Delete = dbcontext.apprenticeships.Where(x => x.apprenticeshipId == id).Include(x => x.assignments).FirstOrDefault();
                if(Delete.assignments.Count > 0)
                    return new RequestStatus(0, "Delete Failed Becase apprenticeship has Assignments ...!");

                Delete.isdelete = true;
                dbcontext.Update(Delete);
                dbcontext.SaveChanges();
                return new RequestStatus(1, $"Delete training Successfully");
            }
            catch (Exception)
            {

                return new RequestStatus(0, "Delete training Failed...!");
            }
           
        }

        public UpdateApprenticeship EditApprenticeship(int id)
        {
            try
            {
                var Edit = dbcontext.apprenticeships.Where(x => x.apprenticeshipId == id).Include(x => x.student).Include(s => s.teamleader).Include(r => r.apprenticeshipsObjectives)
              .ThenInclude(e => e.objective).Include(y => y.UniversitySupervisor).FirstOrDefault();
                UpdateApprenticeship update = new UpdateApprenticeship();
                update.Id = Edit.apprenticeshipId;
                update.nameApprenticeship = Edit.nameApprenticeship;
                update.stuId = Edit.studentId;
                update.teamId = Edit.teamleaderId;
                update.SupervisorId = Edit.universitySupervisorId;
                update.startDate = Edit.startDate;
                update.endDate = Edit.endDate;
                update.objectives = new List<int>();
                if(Edit.apprenticeshipsObjectives!=null)
                foreach (var item in Edit.apprenticeshipsObjectives)
                {
                    if(! item.isdelete)
                    update.objectives.Add(item.objectiveId);
                }
                return update;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public  List<training> GetAllApprenticeship()
        {
            try
            {
                List<training> Reselt = new List<training>();
                List<Apprenticeship> ApprenticeshipList = new List<Apprenticeship>();
                ApprenticeshipList = dbcontext.apprenticeships.Where(x=>!x.isdelete)
                    .Include(x => x.student).Include(s => s.teamleader).Where(x => !x.isdelete)
                    .Include(r => r.apprenticeshipsObjectives)
                    .ThenInclude(e => e.objective).Where(r => !r.isdelete)
                    .Include(y => y.UniversitySupervisor).Where(y => !y.isdelete)
                    .ToList();
                if(ApprenticeshipList!=null)
                foreach (var App in ApprenticeshipList)
                {
                    training training = new training();
                    training.Id = App.apprenticeshipId;
                    training.nameApprenticeship = App.nameApprenticeship;
                    training.Student = new Lookup();
                    training.Student.Name = App.student.FirstName + App.student.LastName;
                    training.Student.Id = App.student.Id;
                    training.TeamLeader = new Lookup();
                    training.TeamLeader.Name = App.teamleader.FirstName + App.teamleader.LastName;
                    training.TeamLeader.Id = App.teamleader.Id;
                    training.Supervisor = new Lookup();
                    training.Supervisor.Id = App.UniversitySupervisor.Id;
                    training.Supervisor.Name = App.UniversitySupervisor.FirstName + 
                                               App.UniversitySupervisor.LastName;
                    training.endDate = App.endDate;
                    training.startDate = App.startDate;
                    training.objectives = new List<LookupDTO>();
                        if(App.apprenticeshipsObjectives!=null)
                    foreach (var item in App.apprenticeshipsObjectives)
                    {
                                if (!item.isdelete)
                                {
                                    LookupDTO dTO = new LookupDTO();
                                    dTO.Id = item.objectiveId;
                                    dTO.Name = item.objective.objectivecName;
                                    training.objectives.Add(dTO);
                                }
                    }
                    Reselt.Add(training);
                }
                return Reselt;
            }
            catch (Exception) {throw; }
        }

        public RequestStatus UpdateApprenticeship(UpdateApprenticeship update)
        {
            try
            {
                var IdOld = dbcontext.apprenticeships.Where(x => x.apprenticeshipId == update.Id).Include(y => y.apprenticeshipsObjectives).ThenInclude(u => u.objective).FirstOrDefault();
                if (IdOld != null)
                {
                    IdOld.studentId = update.stuId;
                    IdOld.nameApprenticeship = update.nameApprenticeship;
                    IdOld.teamleaderId = update.teamId;
                    IdOld.universitySupervisorId = update.SupervisorId;
                    IdOld.startDate = update.startDate;
                    IdOld.endDate = update.endDate;

                    dbcontext.apprenticeships.Update(IdOld);
                    dbcontext.SaveChanges();


                    var oldObejectevs = dbcontext.apprenticeshipsObjectives.Where(x => x.apprenticeshipId == update.Id).ToList();
                   

                    if(oldObejectevs.Count >0 )
                    foreach (var oldObejectev in oldObejectevs)
                    {
                            if (!oldObejectev.isdelete)
                            {
                                oldObejectev.isdelete = true;
                                dbcontext.apprenticeshipsObjectives.Update(oldObejectev);
                                dbcontext.SaveChanges();
                            }
                    }
                    if(update.objectives!=null)
                    foreach (var newObjId in update.objectives)
                    { var obj = oldObejectevs.Where(x => x.apprenticeshipId == update.Id && x.objectiveId == newObjId).FirstOrDefault();
                            if (obj != null)
                            {
                                obj.isdelete = false;
                                dbcontext.apprenticeshipsObjectives.Update(obj);
                                dbcontext.SaveChanges();
                            }
                            else
                            {
                                ApprenticeshipsObjectives apprentic = new ApprenticeshipsObjectives();
                                apprentic.apprenticeshipId = update.Id;
                                apprentic.objectiveId = newObjId;
                                dbcontext.apprenticeshipsObjectives.Add(apprentic);

                                dbcontext.SaveChanges();
                            }

                    }

                }
                return new RequestStatus(1, $"Update training Successfully");
            }
            catch (Exception)
            {

                return new RequestStatus(0, "Update training Failed...!");
            }
            
        }
      



    }
}
