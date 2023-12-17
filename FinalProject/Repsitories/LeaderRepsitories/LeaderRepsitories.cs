using FinalProject.Data;
using FinalProject.Data.Entites;
using FinalProject.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FinalProject.Repsitories.LeaderRepsitories
{
    [Authorize(Roles = "TEAMLEADER")]
    public class LeaderRepsitories : ILeaderRepsitories
    {
        public readonly ApplicationDbContext dbcontext;
        public LeaderRepsitories(ApplicationDbContext context)
        {

            this.dbcontext = context;
        }

        public RequestStatus Addassignment(DTOAssignment assignment)
        {
            try
            {
                Assignment assignm = new Assignment();
                assignm.apprenticeshipId = assignment.apprentiId;
                assignm.assignmentNotes = assignment.assignmentNotes;
                assignm.assignmentTitle = assignment.assignmentTitle;
                assignm.startDate = assignment.startDate;
                assignm.endDate = assignment.endDate;
                assignm.assignmentDescription = assignment.assignmentDescription;
                dbcontext.assignments.Add(assignm);
                dbcontext.SaveChanges();
                foreach (var ObjId in assignment.objectivesid)
                {
                    AssignmentObjectives apprentic = new AssignmentObjectives();
                    apprentic.assignmentId = assignm.assignmentId;
                    apprentic.objectivesId = ObjId;
                    dbcontext.assignmentObjectives.Add(apprentic);
                    dbcontext.SaveChanges();
                }

                List<Attachfile> attachfiles = new List<Attachfile>();
                if (assignment.formFiles != null) 
                foreach (var formFile in assignment.formFiles)
                {
                    Attachfile attachfile = new Attachfile();
                    if (formFile.Length > 0)
                    {
                        Stream st = formFile.OpenReadStream();
                        using (BinaryReader br = new BinaryReader(st))
                        {
                            var byteFile = br.ReadBytes((int)st.Length);
                            attachfile.file = byteFile;
                        }
                    }
                    attachfile.assignmentId = assignm.assignmentId;
                    attachfile.Name = formFile.FileName;
                    attachfile.contentType = formFile.ContentType;
                    dbcontext.Attachfiles.Add(attachfile);
                    dbcontext.SaveChanges();
                    attachfiles.Add(attachfile);
                }
                return new RequestStatus(1, $"Add New Assignment Successfully");
            }
            catch (Exception)
            {
                return new RequestStatus(0, "Add New Assignment Failed...!");
                throw;
            }
          
           
        }
        public RequestStatus Deletassignment(int id)
        {
            try
            {
                var Delete = dbcontext.assignments.Where(x => x.assignmentId == id).Include(x => x.reports).FirstOrDefault();
                if (Delete.reports.Count ==0)
                {
                    Delete.isdelete = true;
                    dbcontext.assignments.Update(Delete);
                    dbcontext.SaveChanges();
                    return new RequestStatus(1, $"Delete Assignment ( {Delete.assignmentTitle} ) Successfully");
                }else
                    return new RequestStatus(0, "Delete Failed...!");

            }
            catch (Exception)
            {
                return new RequestStatus(0, "Delete Failed...!");
                throw;
            }
            
        }
        public DTOAssignment Editassignment(int id)
        {
            try
            {
                var assignment = dbcontext.assignments.Where(x => x.assignmentId == id).Include(c => c.attachfiles).Include(C => C.assignmentObjectives)
               .ThenInclude(C => C.objectives).FirstOrDefault();
                
                DTOAssignment dTOAssignment = new DTOAssignment();
                dTOAssignment.assignmentId = assignment.assignmentId;
                dTOAssignment.assignmentTitle = assignment.assignmentTitle;
                dTOAssignment.assignmentNotes = assignment.assignmentNotes;
                dTOAssignment.assignmentDescription = assignment.assignmentDescription;
                dTOAssignment.apprentiId = assignment.apprenticeshipId;
                dTOAssignment.objectivesid = new List<int>();
                foreach (var item in assignment.assignmentObjectives)
                {
                    dTOAssignment.objectivesid.Add(item.objectivesId);
                }
                dTOAssignment.attachfileId = new List<int>();
                foreach (var item in assignment.attachfiles)
                {
                    dTOAssignment.attachfileId.Add(item.attachfileId);
                }
                return dTOAssignment;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public List<DTOAssignment> GetAllassignment(int Id)
        {
            List<DTOAssignment > list = new List<DTOAssignment>();
            List<Assignment> assignments = new List<Assignment>();
            assignments = dbcontext.assignments.Where(x=>x.apprenticeshipId==Id && !x.isdelete).Include(r=>r.attachfiles).Where(r=>!r.isdelete)
                .Include(d=>d.assignmentObjectives).ThenInclude(d=>d.objectives).Where(d => !d.isdelete).Include(e=>e.reports).Where(e => !e.isdelete).ToList();
            foreach(var assignment in assignments)
            {
                DTOAssignment dTOAssignment = new DTOAssignment();
                dTOAssignment.assignmentId = assignment.assignmentId;
                dTOAssignment.apprentiId = assignment.apprenticeshipId;
                dTOAssignment.assignmentTitle=assignment.assignmentTitle;
                dTOAssignment.startDate=assignment.startDate;
                dTOAssignment.endDate=assignment.endDate;
                dTOAssignment.assignmentDescription = assignment.assignmentDescription;
                dTOAssignment.assignmentNotes = assignment.assignmentNotes;
                dTOAssignment.objectives = new List<DtoRools>();
                foreach (var obj in assignment.assignmentObjectives)
                {
                    if (!obj.isdelete) {
                        DtoRools dtoRools = new DtoRools();
                        dtoRools.Id = obj.objectivesId;
                        dtoRools.Name = obj.objectives.objectivecName;
                        dTOAssignment.objectives.Add(dtoRools);
                    }
                    
                }
                dTOAssignment.attachfiles = new List<DtoRools>();
                foreach (var attachfile in assignment.attachfiles)
                {
                    if (!attachfile.isdelete) {
                        DtoRools dtoRools = new DtoRools();
                        dtoRools.Id = attachfile.attachfileId;
                        dtoRools.Name = attachfile.Name;
                        dTOAssignment.attachfiles.Add(dtoRools);
                    }
                    
                }
                dTOAssignment.objectivesid = new List<int>();
                foreach (var obj in assignment.assignmentObjectives)
                {
                    if (!obj.isdelete)
                    {
                        AssignmentObjectives assignmentObjectives = new AssignmentObjectives();
                        assignmentObjectives.objectivesId = obj.objectivesId;
                        assignmentObjectives.assignmentId = assignment.assignmentId;
                        dTOAssignment.objectivesid.Add(assignmentObjectives.objectivesId);
                    }
                }

                list.Add(dTOAssignment);
            }
            return list;
        }
        public List<Apprenticeship> GetAllLeaderApprenticeship(string Log)
        {
             var ApprenticeshipList = dbcontext.apprenticeships.Where(x => x.teamleaderId == Log && !x.isdelete).Include(x => x.student)
                .ThenInclude(d=>d.University).Include(s => s.teamleader).Include(r => r.apprenticeshipsObjectives)
                .ThenInclude(e => e.objective).Include(y => y.UniversitySupervisor).ToList();
            return ApprenticeshipList;
        }
        public List<Apprenticeship> GetAllSUPERVISERApprenticeship(string Log)
        {
            var ApprenticeshipList = dbcontext.apprenticeships.Where(x => x.universitySupervisorId == Log && !x.isdelete)
               .Include(x => x.student).ThenInclude(d => d.University).Include(s => s.teamleader).Include(r => r.apprenticeshipsObjectives)
               .ThenInclude(e => e.objective).Include(y => y.UniversitySupervisor).ToList();
            return ApprenticeshipList;
        }
        public RequestStatus  Updateassignment(DTOAssignment assignment)
        {
            try
            {
                var existingAssignment = dbcontext.assignments.Where(x => x.assignmentId == assignment.assignmentId).Include(x=>x.assignmentObjectives).Include(x => x.attachfiles).FirstOrDefault();
                if (existingAssignment != null)
                {
                    existingAssignment.assignmentId = assignment.assignmentId;
                    existingAssignment.assignmentTitle = assignment.assignmentTitle;
                    existingAssignment.assignmentDescription = assignment.assignmentDescription;
                    existingAssignment.assignmentNotes = assignment.assignmentNotes;
                    dbcontext.assignments.Update(existingAssignment);
                    dbcontext.SaveChanges();
                    var oldassignment = dbcontext.assignmentObjectives.Where(x => x.assignmentId == assignment.assignmentId).ToList();

                    if(oldassignment != null) 
                    foreach (var oldassignm in oldassignment)
                    {
                        dbcontext.assignmentObjectives.Remove(oldassignm);

                        dbcontext.SaveChanges();
                    }
                    if(assignment.objectivesid!=null)
                    foreach (var ObjId in assignment.objectivesid)
                    {
                        AssignmentObjectives objectives = new AssignmentObjectives();
                        objectives.assignmentId = existingAssignment.assignmentId;
                        objectives.objectivesId = ObjId;
                        dbcontext.assignmentObjectives.Add(objectives);

                        dbcontext.SaveChanges();
                    }
                    
                    List<Attachfile> attachfiles = new List<Attachfile>();
                    if(assignment.formFiles != null)
                    foreach (var formFile in assignment.formFiles)
                    {
                        Attachfile attachfile = new Attachfile();
                        if (formFile.Length > 0)
                        {
                            Stream st = formFile.OpenReadStream();
                            using (BinaryReader br = new BinaryReader(st))
                            {
                                var byteFile = br.ReadBytes((int)st.Length);
                                attachfile.file = byteFile;
                            }
                        }
                        attachfile.assignmentId = existingAssignment.assignmentId;
                        attachfile.Name = formFile.FileName;
                        attachfile.contentType = formFile.ContentType;
                        dbcontext.Attachfiles.Add(attachfile);
                        dbcontext.SaveChanges();
                        attachfiles.Add(attachfile);
                    }
                }
                return new RequestStatus(1, $"Update Assignment ( {existingAssignment.assignmentTitle} ) Successfully");
            }
            catch (Exception)
            {

                return new RequestStatus(0, "Update Assignment Failed...!");
            }
            
        }
    
        public List<ApprenticeshipsObjectives> GetAllObjective(int ApprenticeshipId)
        {
            List<ApprenticeshipsObjectives> objectives = dbcontext.apprenticeshipsObjectives
                .Where(x => x.apprenticeshipId ==  ApprenticeshipId && !x.isdelete)
                .Include(x => x.objective).ThenInclude(x=>x.assignmentObjectives).ToList();

            return objectives;
        }
       
        public Report GetAllReport(int id)
        {
            var assignments = dbcontext.reports.Include(f => f.reportStatus)
                .Where(x => x.reportId == id && !x.isdelete)
                .Include(x=>x.attachfiles).FirstOrDefault();
            return assignments;
        }
        public List< ReportLog> GetAllreportLog(int id)
        {
            var assignments = dbcontext.reportLogs.Include(f => f.report).
                Include(f=>f.ReportStatus).Where(x => x.reportId == id && !x.isdelete).ToList();
            return assignments;
        }
        public RequestStatus UbdatereportStatus(int reportId, int reportStatusId)
        {
            try
            {
                var assignments = dbcontext.reports
                  .Where(x => x.reportId == reportId && !x.isdelete).FirstOrDefault();
                if(assignments != null)
                {
                    assignments.reportStatusId = reportStatusId;
                    dbcontext.reports.Update(assignments);
                    dbcontext.SaveChanges();
                    ReportLog reportLog = new ReportLog(reportId,
                        assignments.reportName, assignments.reportDescription,
                        assignments.reportNotes, assignments.reportStatusId, DateTime.Now);
                    dbcontext.reportLogs.Add(reportLog);
                    dbcontext.SaveChanges();
                    return new RequestStatus(1, $"Update Report  Successfully");
                }
                return new RequestStatus(0, "Update Report Failed...!");
            }
            catch (Exception)
            {
                return new RequestStatus(0, "Update Report Failed...!");
            }
        }
        public List<Attachfile> GetAttachfiles(int assignmentId)
        {
            List<Attachfile> attachfiles = dbcontext.Attachfiles
              .Where(x => x.assignmentId == assignmentId && !x.isdelete).ToList();
            return attachfiles;
        }
        public FileStreamResult GetFile(long attachmentId)
        {
            var file = dbcontext.Attachfiles.Where(x => x.attachfileId == attachmentId).SingleOrDefault();
            Stream stream = new MemoryStream(file.file);
            return new FileStreamResult(stream, file.contentType);
        }
    }
}
