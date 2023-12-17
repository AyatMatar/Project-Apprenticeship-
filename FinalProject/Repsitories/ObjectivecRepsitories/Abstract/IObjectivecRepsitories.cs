

using FinalProject.Data.Entites;
using FinalProject.DTO;

namespace FinalProject.Repsitories.ObjectivecRepsitories.Abstract
{
    public interface IObjectivecRepsitories
    {
        public List<Objective> GetAllObjectivec();
        public RequestStatus AddObjectivec(Objective Objectivec);
        public Objective EditObjectivec(int id);
        public RequestStatus UpdateObjectivec(AddObjectivec objectivec);
        public RequestStatus DeleteObjectivec(int id);
    }
}
