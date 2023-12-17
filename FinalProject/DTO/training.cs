using FinalProject.Data.Entites;

namespace FinalProject.DTO
{
    public class training
    {
        public int Id { get; set; }
        public Lookup Student { get; set; }
        public string nameApprenticeship { get; set; }
        public Lookup Supervisor { get; set; }
        public Lookup TeamLeader { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<LookupDTO> objectives { get; set; }
    }
}
