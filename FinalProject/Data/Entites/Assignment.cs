namespace FinalProject.Data.Entites
{
    public class Assignment
    {
        public int assignmentId { get; set; }
        public string assignmentTitle { get; set; }
        public string? assignmentDescription { get; set;}
        public string? assignmentNotes { get; set;}
         
        public Apprenticeship apprenticeship { get; set; }
         public int apprenticeshipId { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public List<Report> reports { get; set; }
       public List<Attachfile>? attachfiles { get; set; }
        public bool isdelete { get; set; }


        public List<AssignmentObjectives> assignmentObjectives { get; set; }
    }
}
