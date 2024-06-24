using System;
using System.ComponentModel.DataAnnotations;

namespace synnex_mvc_app_1.Models
{
	public class Teacher
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }

		[Required]
		public string Subject { get; set; }
	}
}

