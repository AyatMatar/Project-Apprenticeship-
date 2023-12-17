namespace FinalProject.Data.Entites
{
    public class ReportLog
    {
        public ReportLog() { }
        public ReportLog(int reportId, string reportName, string? reportDescription, string? reportNotes, int reportStatusId, DateTime? reportDate)
        {

            this.reportId = reportId;
            this.reportName = reportName;
            this.reportDescription = reportDescription;
            this.reportNotes = reportNotes;
            this.reportStatusId = reportStatusId;
            this.reportDate = reportDate;
        }
        //report.
        public int reportLogId { get; set; }
        public Report report { get; set; }
        public int reportId { get; set; }
        public string reportName { get; set; }
        public string? reportDescription { get; set; }
        public string? reportNotes { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public int reportStatusId { get; set; }
        public DateTime? reportDate { get; set; }
        public bool isdelete { get; set; }
    }
}
