namespace FinalProject.DTO
{
    public class DTOAssignment
    {
        public int assignmentId { get; set; }
        public string assignmentTitle { get; set; }
        public string assignmentDescription { get; set; }
        public string assignmentNotes { get; set; }
        public int apprentiId { get; set; }
        public List<int> objectivesid { get; set; }
        public List<int> attachfileId { get; set; }
        public IFormFile[] formFiles { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public List<DtoRools> objectives { get; set; }
        public List<DtoRools> attachfiles { get; set; }
    }
    public class DtoRools
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DtoRoolsFiles
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
