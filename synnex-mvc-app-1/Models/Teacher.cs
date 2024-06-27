using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace synnex_mvc_app_1.Models
{
	public class Teacher
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }

		[ForeignKey("Subject")]
		public int SubjectId { get; set; }

		//[ForeignKey("SubjId")]
		public virtual Subject Subject { get; set; }
	}
}

