using FinalProject.Data.Entites;
using FinalProject.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Repsitories.AdmanStudent
{
    public interface IAdmanStudent
    {
        public List<Assignment> GetAllassignment(string Id);
        public List<Report> GetAllReport(int Id);
        public RequestStatus AddReport(DtoReport Report);
        public Report EditReport(int id);
        public RequestStatus UpdateReport(DtoReport Report);
        public RequestStatus DeletReport(int id);
        public FileStreamResult GetFile(long attachmentId);
        public List<Attachfile> GetAttachfiles(int id);
        public RequestStatus DeletAttsh(int id);
        //public string GetStudentEmailByTreningId(int treningId);
        public void SendMail(Teamleader TeamLeader, Student student);
    }
}
