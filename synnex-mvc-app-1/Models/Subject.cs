using System;
using System.ComponentModel.DataAnnotations;

namespace synnex_mvc_app_1.Models
{
	public class Subject
	{
		public int Id { get; set; }
		[Required]
		[StringLength(80)]
		public string Name { get; set; }

		public virtual ICollection<Teacher> Teachers { get; set; }
	}
}

