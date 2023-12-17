namespace FinalProject.Data.Entites
{
    public class Teamleader:Person
    {
       
        public string? department { get; set; }
        public List<Apprenticeship> apprenticeships { get; set; }
        public bool isdelete { get; set; }
        public Company company { get; set; }
        public int companyId { get; set; }

    }
}
