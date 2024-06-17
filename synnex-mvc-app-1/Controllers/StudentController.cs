using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using synnex_mvc_app_1.Data;
using synnex_mvc_app_1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace synnex_mvc_app_1.Controllers
{
    public class StudentController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var students = StudentRespository.Students;
            return View(students);
        }

        public IActionResult StudentDetails(int id)
        {
            var student = StudentRespository.Students.Find(s=> s.Id == id);
            return View(student);
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        
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
                    ModelState.AddModelError("", "student belonging to Delhi should have age gerate than or equal to 20");
                    return View(student);
                }
            }

            StudentRespository.Students.Add(student);

            return RedirectToAction(nameof(Index));
        }


    }
}

