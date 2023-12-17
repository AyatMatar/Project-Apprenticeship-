using FinalProject.Data.Entites;

namespace FinalProject.DTO
{
    public class UpdateApprenticeship
    {
        public int Id { get; set; }
        public string nameApprenticeship { get; set; }
        public string stuId { get; set; }
        public string teamId { get; set; }
        public string SupervisorId { get; set; }
        public List<int> objectives { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
