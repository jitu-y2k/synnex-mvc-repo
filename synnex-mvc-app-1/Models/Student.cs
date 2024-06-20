using System;
using System.ComponentModel.DataAnnotations;

namespace synnex_mvc_app_1.Models;

public class Student
{
	public int Id { get; set; }
	[Required]
	public string Name { get; set; }
	[Required(ErrorMessage ="Age is mandatory")]
	[Range(18,90)]
	public int? Age { get; set; }
	public string Address { get; set; }
}


