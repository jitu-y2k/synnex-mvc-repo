using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using synnex_mvc_app_1.Data;
using synnex_mvc_app_1.Models;

namespace synnex_mvc_app_1.Pages.Teachers
{
	public class UpdateTeacherModel : PageModel
    {
        [BindProperty]
        public Teacher Teacher { get; set; }

        private readonly TeacherRespository _teacherRepo;

        public UpdateTeacherModel(TeacherRespository teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        public void OnGet(int id)
        {
            //Teacher = TeacherRespository.Teachers.Find(t => t.Id == id);
            Teacher = _teacherRepo.GetTeacher(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var dbTeacher = TeacherRespository.Teachers.Find(t => t.Id == Teacher.Id);
            //var dbTeacher = TeacherRespository.Teachers.FirstOrDefault(t => t.Id == Teacher.Id);

            //dbTeacher.Name = Teacher.Name;
            //dbTeacher.Subject = Teacher.Subject;

            _teacherRepo.UpdateTeacher(Teacher);

            return RedirectToPage("TeachersList");
        }
    }
}

