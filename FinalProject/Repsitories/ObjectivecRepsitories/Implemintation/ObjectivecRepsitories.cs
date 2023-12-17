using FinalProject.Data;
using FinalProject.Data.Entites;
using FinalProject.DTO;
using FinalProject.Repsitories.ObjectivecRepsitories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repsitories.ObjectivecRepsitories.Implemintation
{
    public class ObjectivecRepsitories : IObjectivecRepsitories
    {
        public readonly ApplicationDbContext dbcontext;
        public ObjectivecRepsitories(ApplicationDbContext context)
        {

            this.dbcontext = context;
        }
        public RequestStatus AddObjectivec(Objective objectivec)
        {
            try
            {
                Objective obj = new Objective();
                obj.objectivecName = objectivec.objectivecName;
                dbcontext.Add(obj);
                dbcontext.SaveChanges();
                return new RequestStatus(1, $"Add New Objective Successfully");
            }
            catch (Exception)
            {
                return new RequestStatus(0, "Add New Objective Failed...!");
            }
        }

        public RequestStatus DeleteObjectivec(int id)
        {
            try
            {
                var Deleteobjectives = dbcontext.objectives.Where(x => x.objectiveId == id).FirstOrDefault();
                if (Deleteobjectives != null)
                dbcontext.Update(Deleteobjectives);
                dbcontext.SaveChanges();
                return new RequestStatus(1, $"Delete Objective Successfully");
            }
            catch (Exception)
            {
                return new RequestStatus(0, "Delete Objective Failed...!");
            }
        }

        public Objective EditObjectivec(int id)
        {
            var Edit = dbcontext.objectives.Where(x => x.objectiveId == id).FirstOrDefault();

            return Edit;
        }

        public List<Objective> GetAllObjectivec()
        {
            var ObjectivecList = dbcontext.objectives.Where(x=>!x.isdelete).ToList();
           
            return ObjectivecList;
        }

        public RequestStatus UpdateObjectivec(AddObjectivec Objectivec)
        {
            try
            {
                var existingObjectivec = dbcontext.objectives.Where(x => x.objectiveId == Objectivec.objectiveId).FirstOrDefault();
                if (existingObjectivec != null)
                {

                    existingObjectivec.objectivecName = Objectivec.objectivecName;

                    dbcontext.objectives.Update(existingObjectivec);
                    dbcontext.SaveChanges();
                    return new RequestStatus(1, $"Update Objective Successfully");
                }
                return new RequestStatus(0, "Update Objective Failed...!");
            }
            catch (Exception)
            {
                return new RequestStatus(0, "Update Objective Failed...!");
            }
        }



    }
}
