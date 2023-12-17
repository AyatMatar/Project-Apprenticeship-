namespace FinalProject.Data.Entites
{
    public class AssignmentObjectives
    {
        public Assignment assignment { get; set; }
        public int assignmentId { get; set; }

        public Objective objectives { get; set; }
        public int objectivesId { get; set; }
        public bool isdelete { get; set; }
    }
}
