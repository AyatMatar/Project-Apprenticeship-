namespace FinalProject.Data.Entites
{
    public class Attachfile
    {
        public int attachfileId {  get; set; }
        public string Name { get; set; }
        public string contentType { get; set; }
        public byte[] file { get; set; }
        public Report? Report { get; set; }
        public int? reportId { get; set; }
        public Assignment? Assignment { get; set; }
        public int? assignmentId { get; set; }
        public bool isdelete { get; set; }
    }
}
