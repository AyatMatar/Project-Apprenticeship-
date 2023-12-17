namespace FinalProject.Data.Entites
{
    public class Objective
    {
        public int objectiveId { get; set; }
        public string objectivecName { get; set;}

       public List<ObjectivesSkills> objectivesSkills { get; set; }

       public List<ApprenticeshipsObjectives> apprenticeshipsObjectives { get; set; }

       public List<AssignmentObjectives> assignmentObjectives { get; set; }
        public bool isdelete { get; set; }
    }
}
