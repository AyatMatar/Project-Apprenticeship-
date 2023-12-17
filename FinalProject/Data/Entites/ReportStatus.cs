namespace FinalProject.Data.Entites
{
    public class ReportStatus //lookup tables
    {
        public int reportStatusId { get;set;}
        public string statusName { get;set;}
        public bool isdelete { get; set; }
        public List<Report> reports { get;set;}
    }
}
