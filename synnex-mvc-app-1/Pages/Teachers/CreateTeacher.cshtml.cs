using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;
using synnex_mvc_app_1.Data;
using synnex_mvc_app_1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace synnex_mvc_app_1.Pages.Teachers
{
	public class CreateTeacherModel : PageModel
    {
        //[BindProperty]
        public Teacher Teacher { get; set; }
        public SelectList SubjectList { get; set; }

        private readonly TeacherRespository _teacherRepo;
        private readonly SubjectRespository _subjectRepo;


        public CreateTeacherModel(TeacherRespository teacherRepo, SubjectRespository subjectRepo)
        {
            _teacherRepo = teacherRepo;
            _subjectRepo = subjectRepo;
        }

        public void OnGet()
        {
            SubjectList = new SelectList(_subjectRepo.GetSubjects(), "Id", "Name");
            
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
