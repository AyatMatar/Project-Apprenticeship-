using FinalProject.Data.Entites;
using FinalProject.DTO;

namespace FinalProject.Repsitories.StudentRepsitories.Abstract
{
    public interface IStudentRepsitories
    {
        public List<Student> GetAllStudent();
        public Task <RequestStatus> AddStudent(AddStudent student, string Password);
        public Student EditStudent(string id);
        public RequestStatus UpdateStudent(AddStudent stu);
        public RequestStatus DeletStudent(string id);

    }
}
