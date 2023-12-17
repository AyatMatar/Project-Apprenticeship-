namespace FinalProject.Data.Entites
{
    public class UniversitySupervisor:Person
    {
        public string? field_work { get; set; }

        public List<Apprenticeship> apprenticeships { get; set; }
        public bool isdelete { get; set; }
        public University University { get; set; }
        public int UniversityId { get; set; }

       
    }
}
