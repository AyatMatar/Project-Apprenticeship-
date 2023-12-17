namespace FinalProject.Data.Entites
{
    public class Student:Person
    {
     
        public string major { get; set; }
        public string? number_universtity { get; set; }

       public List<Apprenticeship> apprenticeships { get; set; }
        public bool isdelete { get; set; }
        public University University { get; set; }
        public int UniversityId { get; set; }
    }
}
