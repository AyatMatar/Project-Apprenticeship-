using FinalProject.Data.Entites;

namespace FinalProject.DTO
{
    public class DtoReport
    {
        public int reportId { get; set; }
        public string reportName { get; set; }
        public string? reportDescription { get; set; }
        public string? reportNotes { get; set; }
        public List<int> attachfileId { get; set; }
        public int assignmentId { get; set; }
        public int reportStatusId = 2;

       public IFormFile[] formFiles { get; set; }
    }
  
}
