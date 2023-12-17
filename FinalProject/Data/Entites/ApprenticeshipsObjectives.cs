namespace FinalProject.Data.Entites
{
    public class ApprenticeshipsObjectives
    {
        public Apprenticeship apprenticeship { get; set; }
        public int apprenticeshipId { get; set; }

        public Objective objective { get; set; }
        public int objectiveId { get; set;}
        public bool isdelete { get; set; }
    }
}
