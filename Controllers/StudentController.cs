using CollegeApp.Models;
using CollegeApp.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    public class StudentController(IStudentRepository studentRepository) : Controller
    {
        public readonly IStudentRepository StudentRepository=studentRepository;
       
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([Bind("Studentid,FirstName,LastName,Gender,Birthdate,Email,Phone,Address")] Student student)
        {
            if (student == null)
                return BadRequest(ModelState);

            var createdstudent = await StudentRepository.AddStudent(student);
            if (!createdstudent) 
                return BadRequest("Error while adding student.");
            return View(student);
        }
    }
}
