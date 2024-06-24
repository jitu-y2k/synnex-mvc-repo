using Microsoft.AspNetCore.Mvc.RazorPages;
using synnex_mvc_app_1.Data;
using synnex_mvc_app_1.Models;

namespace synnex_mvc_app_1.Pages.Teachers
{
	public class TeachersListModel : PageModel
    {
        public List<Teacher> Teachers { get; set; }

        private readonly TeacherRespository _teacherRepo;

        public TeachersListModel(TeacherRespository teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        //public TeachersListModel()
        //{
        //    Teachers = TeacherRespository.Teachers.ToList();
        //}

        public void OnGet()
        {
            Teachers = _teacherRepo.GetTeachers();
        }
    }
}
