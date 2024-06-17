using System;
using synnex_mvc_app_1.Models;

namespace synnex_mvc_app_1.ViewModels
{
	public class StudentWithSubjects
	{
		public Student Student { get; set; }
		public ICollection<string> Subjects { get; set; }
	}
}

