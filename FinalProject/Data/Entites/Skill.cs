namespace FinalProject.Data.Entites
{
    public class Skill
    {
        public int skillId { get; set; }
        public string skillName { get; set; }
        public bool isdelete { get; set; }
        List<ObjectivesSkills> objectivesSkills { get; set; }
    }
}
