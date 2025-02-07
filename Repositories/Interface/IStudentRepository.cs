using CollegeApp.Models;

namespace CollegeApp.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<bool> AddStudent(Student student);
    }
}
