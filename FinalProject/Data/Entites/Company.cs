namespace FinalProject.Data.Entites
{
    public class Company
    {
        public int companyId { get; set; }
        public string companyName { get; set; }
        public string? companyAddress { get; set; }
        public bool isdelete { get; set; }
        public List<Teamleader> teamleaders { get; set; }
     

    }
}
