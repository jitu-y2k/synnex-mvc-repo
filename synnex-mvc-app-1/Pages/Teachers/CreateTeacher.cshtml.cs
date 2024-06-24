using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using synnex_mvc_app_1.Data;
using synnex_mvc_app_1.Models;

namespace synnex_mvc_app_1.Pages.Teachers
{
	public class CreateTeacherModel : PageModel
    {
        //[BindProperty]
        public Teacher Teacher { get; set; }

        private readonly TeacherRespository _teacherRepo;

        public CreateTeacherModel(TeacherRespository teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //teacher.Id = TeacherRespository.Teachers.Count() == 0 ? 1 : TeacherRespository.Teachers.Max(t => t.Id) + 1;

            //TeacherRespository.Teachers.Add(teacher);
            _teacherRepo.CreateTeacher(teacher);
            return RedirectToPage("TeachersList");
        }
    }
}
