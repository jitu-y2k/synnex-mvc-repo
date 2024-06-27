using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using synnex_mvc_app_1.Data;
using synnex_mvc_app_1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace synnex_mvc_app_1.Controllers
{
    //[Authorize]
    public class StudentController : Controller
    {
        private readonly StudentRespository _studentRepo;

        public StudentController(StudentRespository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //var students = StudentRespository.Students;
            var students = _studentRepo.GetStudents();
            return View(students);            
        }

        public IActionResult StudentDetails(int id)
        {
            var student = _studentRepo.GetStudent(id);
            return View(student);
        }

        [Authorize(Policy ="ShouldBe18YearsOld")]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "ShouldBe18YearsOld")]
        public IActionResult CreateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                //ViewBag.Errors = ModelState.FirstOrDefault(s => s.Key == "Age").Value.Errors[0].ErrorMessage;
                return View(student);
            }

            if (student.Address == "Delhi")
            {
                if (student.Age < 20)
                {
                    ModelState.AddModelError("", "Student belonging to Delhi should have age greater than or equal to 20.");
                    return View(student);
                }
            }

            //StudentRespository.Students.Add(student);

            _studentRepo.CreateStudent(student);

            return RedirectToAction(nameof(Index));
        }


    }
}

