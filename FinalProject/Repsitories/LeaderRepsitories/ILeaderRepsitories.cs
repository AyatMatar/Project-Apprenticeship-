using FinalProject.Data.Entites;
using FinalProject.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Repsitories.LeaderRepsitories
{
    public interface ILeaderRepsitories
    {
        public List<Apprenticeship> GetAllLeaderApprenticeship(string Log);
        public List<DTOAssignment> GetAllassignment(int Id);
        public RequestStatus Addassignment(DTOAssignment assignment);
        public DTOAssignment Editassignment(int id);
        public RequestStatus Updateassignment(DTOAssignment assignment);
        public RequestStatus Deletassignment(int id);
        public List<ApprenticeshipsObjectives> GetAllObjective(int ApprenticeshipId);
        public Report GetAllReport(int id);
        public List<ReportLog> GetAllreportLog(int id);
        public RequestStatus UbdatereportStatus(int reportId, int reportStatusId);
        public List<Apprenticeship> GetAllSUPERVISERApprenticeship(string Log);
        public FileStreamResult GetFile(long attachmentId);
        public List<Attachfile> GetAttachfiles(int assignmentId);
    }
}
