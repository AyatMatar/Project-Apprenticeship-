namespace FinalProject.Data.Entites
{
    public class Apprenticeship
    {
        public int apprenticeshipId { get; set; }
        public string? nameApprenticeship { get; set; }
        public Student student { get; set; }
        public string studentId { get; set; }

        public Teamleader teamleader { get; set; }
        public string teamleaderId { get; set; }

        public UniversitySupervisor UniversitySupervisor { get; set; }
        public string universitySupervisorId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public List<Assignment>assignments { get; set; }
        public List<ApprenticeshipsObjectives>apprenticeshipsObjectives { get; set; }
        public bool isdelete { get; set; }
    }
}
