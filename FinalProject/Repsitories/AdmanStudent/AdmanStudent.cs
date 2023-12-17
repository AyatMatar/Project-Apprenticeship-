using FinalProject.Data;
using FinalProject.Data.Entites;
using FinalProject.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

namespace FinalProject.Repsitories.AdmanStudent
{
    public class AdmanStudent : IAdmanStudent
    {
        public readonly ApplicationDbContext dbcontext;
        public AdmanStudent(ApplicationDbContext dbcontext)
        { 
            this.dbcontext = dbcontext;
        }

        public  RequestStatus AddReport(DtoReport DtoReport)
        {
            try
            {
                Report report = new Report();
                report.assignmentId = DtoReport.assignmentId;
                report.reportStatusId = DtoReport.reportStatusId;
                report.reportNotes = DtoReport.reportNotes;
                report.reportDescription = DtoReport.reportDescription;
                report.reportName = DtoReport.reportName;
                dbcontext.reports.Add(report);
                dbcontext.SaveChanges();
                List<Attachfile> attachfiles = new List<Attachfile>();
                if (DtoReport.formFiles != null)
                    foreach (var formFile in DtoReport.formFiles)
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
                        attachfile.Name = formFile.FileName;
                        attachfile.reportId = report.reportId;
                        attachfile.contentType = formFile.ContentType;
                        dbcontext.Attachfiles.Add(attachfile);
                        dbcontext.SaveChanges();
                        attachfiles.Add(attachfile);
                    }
                ReportLog reportLog = new ReportLog(report.reportId, report.reportName, 
                                                    report.reportDescription, report.reportNotes,
                                                    report.reportStatusId, DateTime.Now);
                dbcontext.reportLogs.Add(reportLog);
                dbcontext.SaveChanges();
                return new RequestStatus(1, $"Add New Report Successfully");
            }
            catch (Exception)
            {
                return new RequestStatus(0, "Add New Report Failed...!");
            }
        }

        public RequestStatus DeletReport(int id)
        {
            try
            {
                var Delete = dbcontext.reports.Include(x => x.attachfiles).Where(x => x.reportId == id).FirstOrDefault();
                if (Delete.reportStatusId == 2 || Delete.reportStatusId==3)
                {
                    if (Delete.attachfiles != null && Delete.attachfiles.Count > 0)
                    {
                        var deletedFiles = dbcontext.Attachfiles.Where(x => x.reportId == id).ToList();
                        foreach (var file in deletedFiles)
                        {
                            file.isdelete = true;
                        }
                        dbcontext.Attachfiles.UpdateRange(deletedFiles);
                        dbcontext.SaveChanges();
                    }
                    Delete.isdelete = true;
                    dbcontext.reports.Update(Delete);
                    dbcontext.SaveChanges();
                    return new RequestStatus(1, $"Delete Report ( {Delete.reportName} ) Successfully");
                }
                else { return new RequestStatus(0, "Delete Failed...!"); }
            }
            catch (Exception ex)
            {

                return new RequestStatus(0, "Delete Failed...!");
            }
            
        }

        public Report EditReport(int id)
        {
            try
            {
                var Edit = dbcontext.reports.Where(x => x.reportId == id).Include(x => x.attachfiles).FirstOrDefault();
                return Edit;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public List<Attachfile> GetAttachfiles(int id)
        {
            List<Attachfile> attachfiles = dbcontext.Attachfiles.Where(x => x.reportId == id &&!x.isdelete).ToList();
            return attachfiles;
        }

        public List<Assignment> GetAllassignment(string Id)
            {
                var GetAssignment = dbcontext.assignments.Where(x=>!x.isdelete)
                .Include(c=>c.attachfiles).Where(c => c.attachfiles.Any(y => !y.isdelete))
                .Include(d => d.apprenticeship)
                .ThenInclude(c => c.teamleader).Where(d => d.apprenticeship.studentId == Id && !d.isdelete).ToList();
                return GetAssignment;
            }
       
        public List<Report> GetAllReport(int Id)
        {
            var report = dbcontext.reports.Where(r => !r.isdelete)
                .Include(r=>r.reportStatus).Where(r => !r.reportStatus.isdelete)
                .Include(r=>r.assignment).Where(r => r.assignment.assignmentId == Id && !r.assignment.isdelete)
                .Include(r=>r.attachfiles).Where(r => r.attachfiles.Any(att => !att.isdelete) )
                .ToList();
            //foreach (var reports in report)
            //{
            //    if (reports.attachfiles != null)
            //    {
            //        var attach = dbcontext.Attachfiles.Where(x => x.reportId == reports.reportId || !x.isdelete).ToList();
            //    }

            //}


            return report;
        }
        
        public RequestStatus UpdateReport(DtoReport Report)
        {
            try
            {
                var existingReport = dbcontext.reports.Where(x => x.reportId == Report.reportId).FirstOrDefault();
                if (existingReport != null)
                {
                    existingReport.reportId = Report.reportId;
                    existingReport.reportStatusId = Report.reportStatusId;
                    existingReport.reportName = Report.reportName;
                    existingReport.reportDescription = Report.reportDescription;
                    existingReport.reportNotes = Report.reportNotes;
                    dbcontext.reports.Update(existingReport);
                    dbcontext.SaveChanges();
                }

                ReportLog reportLog = new ReportLog(Report.reportId, Report.reportName, Report.reportDescription, Report.reportNotes, Report.reportStatusId, DateTime.Now);
                dbcontext.reportLogs.Add(reportLog);
                dbcontext.SaveChanges();

                List<Attachfile> attachfiles = new List<Attachfile>();
                if (Report.formFiles != null)
                {
                    foreach (var formFile in Report.formFiles)
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
                        attachfile.reportId = existingReport.reportId;
                        attachfile.Name = formFile.FileName;
                        attachfile.contentType = formFile.ContentType;
                        dbcontext.Attachfiles.Add(attachfile);
                        dbcontext.SaveChanges();
                        attachfiles.Add(attachfile);
                    }
                }
                return new RequestStatus(1, $"Update Report ( {existingReport.reportName} ) Successfully");
            }
            catch (Exception)
            { return new RequestStatus(0, "Update Report Failed...!"); }
         
        }
        public FileStreamResult GetFile(long attachmentId)
        {
            var file = dbcontext.Attachfiles.Where(x => x.attachfileId == attachmentId ).SingleOrDefault();

            Stream stream = new MemoryStream(file.file);
            return new FileStreamResult(stream, file.contentType);

        }
        public RequestStatus DeletAttsh( int id ) { 
           
            try
            {
                var idattch = dbcontext.Attachfiles.Where(x => x.attachfileId == id).FirstOrDefault();
                if ( idattch != null ) {
                    idattch.isdelete = true;
                    dbcontext.Attachfiles.Update(idattch);
                    dbcontext.SaveChanges();
                }
                return new RequestStatus(1, $"Delete Attach Files ( ) Successfully");
            }
            catch (Exception)
            {

                return new RequestStatus(0, "Delete Failed...!");
            }
            
        }
        //public string GetStudentEmailByTreningId(int treningId)
        // {
        //     var traning =dbcontext.apprenticeships.Include(x=>x.student).Where(x=>x.apprenticeshipId == treningId).FirstOrDefault();

        //     return traning.student.Email;
        // }
        public void SendMail(Teamleader TeamLeader, Student student)
        {
            using (var message = new MailMessage())
            {

                message.To.Add(new MailAddress("Abeeryosef67@gmail.com")); //the reseve....> one or list of emails
                message.From = new MailAddress("ayathsn183@gmail.com");  //the sender email ....> Developer login  //ayat
                message.Subject = "Please check your email to receive the work";
                var TeamLeaderName = TeamLeader.FirstName + " " + TeamLeader.LastName;
                var studentName = student.FirstName + " " + student.LastName;
                message.Body = $"Dear {TeamLeaderName},<br/><br/>I hope you are well when you receive my email<br/>Send you the required work attached to this email.< br />I hope the work is good and accepted by you.< br />Sincerely <br/> {studentName} ";
                message.IsBodyHtml = true;
                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587)) /// for google...> smtp.gmail.com , for office365 .....>smtp.office365.com
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("ayathsn183@gmail.com", "Aa$0796040518");  //ayat

                    smtpClient.Send(message);
                }
            }
        }
    }
}
