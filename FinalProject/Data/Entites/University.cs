namespace FinalProject.Data.Entites
{
    public class University
    {
        public int universityId { get; set; }
        public string universityName { get; set; }
        public string? universityAddress { get; set; }
        public bool isdelete { get; set; }
        public List<UniversitySupervisor> UniversitySupervisor { get; set;}
        public List<Student> student { get; set; }

    }
}
