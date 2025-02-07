using CollegeApp.Data;
using CollegeApp.Models;
using CollegeApp.Repositories.Interface;

namespace CollegeApp.Repositories.Services
{
    public class StudentRepository(AppDbContext context) : IStudentRepository
    {
        private readonly AppDbContext _context= context;

        public async Task<bool> AddStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                int result = await _context.SaveChangesAsync();
                Console.WriteLine($"Student {student.Studentid}: {student.FirstName} {student.LastName } added to the database.");
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding student.{ex.ToString()}");
                return false;
            }

        }        
    }
}
